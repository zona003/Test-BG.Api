using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthServer.Models;

namespace AuthServer.Data
{
    public class DataContext : IdentityDbContext<AppUser , IdentityRole<long>, long>
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
               Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=root");
        }
    }
}
