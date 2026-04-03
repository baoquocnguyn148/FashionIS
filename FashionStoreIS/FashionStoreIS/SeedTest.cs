using System;
using System.Linq;
using System.Threading.Tasks;
using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace FashionStoreIS
{
    public class SeedTest
    {
        public static async Task TestSeed()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            
            // Wait, I don't know the connection string exactly, let's just use the IHost to get the services!
        }
    }
}
