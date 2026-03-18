using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Models;

namespace FashionStoreIS.Data;

/// <summary>
/// RoleStore tương thích Oracle 11g.
/// Tránh lỗi ORA-00933 do FETCH FIRST 1 ROWS ONLY.
/// </summary>
public class OracleCompatibleRoleStore : RoleStore<IdentityRole>
{
    private readonly ApplicationDbContext _db;

    public OracleCompatibleRoleStore(ApplicationDbContext context, IdentityErrorDescriber? describer = null)
        : base(context, describer)
    {
        _db = context;
    }

    public override async Task<IdentityRole?> FindByNameAsync(
        string normalizedRoleName,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (string.IsNullOrEmpty(normalizedRoleName)) return null;

        var roles = await _db.Roles
            .Where(r => r.NormalizedName == normalizedRoleName)
            .Take(1)
            .ToListAsync(cancellationToken);

        return roles.FirstOrDefault();
    }

    public override async Task<IdentityRole?> FindByIdAsync(
        string roleId,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (string.IsNullOrEmpty(roleId)) return null;

        var roles = await _db.Roles
            .Where(r => r.Id == roleId)
            .Take(1)
            .ToListAsync(cancellationToken);

        return roles.FirstOrDefault();
    }
}
