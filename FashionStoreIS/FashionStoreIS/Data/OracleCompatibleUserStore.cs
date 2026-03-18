using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Models;

namespace FashionStoreIS.Data;

/// <summary>
/// UserStore tương thích Oracle 11g.
/// Giải pháp: dùng .ToListAsync() thay vì .AnyAsync() hay .FirstOrDefaultAsync()
/// đềEtránh EF Core sinh ra mệnh đềEFETCH FIRST (không hềEtrợ trên Oracle 11g).
/// </summary>
public class OracleCompatibleUserStore : UserStore<ApplicationUser>
{
    private readonly ApplicationDbContext _db;

    public OracleCompatibleUserStore(ApplicationDbContext context, IdentityErrorDescriber? describer = null)
        : base(context, describer)
    {
        _db = context;
    }

    public override async Task<ApplicationUser?> FindByNameAsync(
        string normalizedUserName,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (string.IsNullOrEmpty(normalizedUserName)) return null;

        // Use LINQ with ToListAsync to avoid FETCH FIRST on Oracle 11g
        var users = await _db.Users
            .Where(u => u.NormalizedUserName == normalizedUserName)
            .Take(1)
            .ToListAsync(cancellationToken);

        return users.FirstOrDefault();
    }

    public override async Task<ApplicationUser?> FindByEmailAsync(
        string normalizedEmail,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (string.IsNullOrEmpty(normalizedEmail)) return null;

        var users = await _db.Users
            .Where(u => u.NormalizedEmail == normalizedEmail)
            .Take(1)
            .ToListAsync(cancellationToken);

        return users.FirstOrDefault();
    }

    public override async Task<ApplicationUser?> FindByIdAsync(
        string userId,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (string.IsNullOrEmpty(userId)) return null;

        var users = await _db.Users
            .Where(u => u.Id == userId)
            .Take(1)
            .ToListAsync(cancellationToken);

        return users.FirstOrDefault();
    }

    public override async Task<bool> IsInRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (string.IsNullOrWhiteSpace(roleName)) throw new ArgumentNullException(nameof(roleName));

        var normalizedRoleName = roleName.ToUpper();
        
        var roles = await _db.Roles
            .Where(r => r.NormalizedName == normalizedRoleName)
            .ToListAsync(cancellationToken);
        
        var role = roles.FirstOrDefault();
        if (role == null) return false;

        var userRoles = await _db.UserRoles
            .Where(ur => ur.UserId == user.Id && ur.RoleId == role.Id)
            .ToListAsync(cancellationToken);

        return userRoles.Any();
    }

    public override async Task AddToRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (string.IsNullOrWhiteSpace(roleName)) throw new ArgumentNullException(nameof(roleName));

        var normalizedRoleName = roleName.ToUpper();
        
        var roles = await _db.Roles
            .Where(r => r.NormalizedName == normalizedRoleName)
            .ToListAsync(cancellationToken);
        
        var role = roles.FirstOrDefault();
        if (role == null) throw new InvalidOperationException($"Role {roleName} not found.");

        if (!await IsInRoleAsync(user, roleName, cancellationToken))
        {
            Console.WriteLine($"AddToRoleAsync: Adding RoleId={role.Id} to UserId={user.Id}");
            var userRole = new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = role.Id
            };
            _db.Set<IdentityUserRole<string>>().Add(userRole);
            // await _db.SaveChangesAsync(cancellationToken); // UserStore should not call SaveChanges here
        }
    }

    public override async Task<IList<string>> GetRolesAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null) throw new ArgumentNullException(nameof(user));

        // Use LINQ with JOIN and ToListAsync
        var query = from ur in _db.UserRoles
                    join r in _db.Roles on ur.RoleId equals r.Id
                    where ur.UserId == user.Id
                    select r.Name;

        var roles = await query.ToListAsync(cancellationToken);
        return roles.Where(n => n != null).Cast<string>().ToList();
    }

    public override async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (string.IsNullOrWhiteSpace(roleName)) throw new ArgumentNullException(nameof(roleName));

        var normalizedRoleName = roleName.ToUpper();

        // Use LINQ with double join and ToListAsync
        var query = from u in _db.Users
                    join ur in _db.UserRoles on u.Id equals ur.UserId
                    join r in _db.Roles on ur.RoleId equals r.Id
                    where r.NormalizedName == normalizedRoleName
                    select u;

        var users = await query.ToListAsync(cancellationToken);
        return users;
    }
    public override async Task<ApplicationUser?> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (loginProvider == null) throw new ArgumentNullException(nameof(loginProvider));
        if (providerKey == null) throw new ArgumentNullException(nameof(providerKey));

        // Use FromSqlRaw to be safe with Oracle 11g
        var sql = "SELECT u.* FROM \"ASPNETUSERS\" u " +
                  "JOIN \"ASPNETUSERLOGINS\" ul ON u.\"ID\" = ul.\"USERID\" " +
                  "WHERE ul.\"LOGINPROVIDER\" = {0} AND ul.\"PROVIDERKEY\" = {1}";
        
        var users = await _db.Users
            .FromSqlRaw(sql, loginProvider, providerKey)
            .ToListAsync(cancellationToken);

        return users.FirstOrDefault();
    }
}
