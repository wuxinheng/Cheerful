using Cheerful.Repository.Entitys;

using Microsoft.EntityFrameworkCore;

namespace Cheerful.Repository
{
    public class CheerfulContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0,17));
            optionsBuilder.UseMySql(@$"Server=localhost;Database=cheerful;Uid=root;Pwd=123456;", serverVersion);
        }

    }
}
