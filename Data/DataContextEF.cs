using ConsoleApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Data
{
    public class DataContextEF: DbContext
    {
        private readonly string _connectionString;
        
        public DataContextEF(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(_connectionString, 
                    options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MyAppSchema");
            modelBuilder.Entity<Computer>();
        }
    }
}
