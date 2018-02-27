using Ax1Mobile;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ax1.DAL
{
    /// <summary>
    /// Context class
    /// </summary>
    public class Ax1Context : DbContext
    {
        private readonly string _connection;
        
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="options"></param>
        public Ax1Context()
        {
            _connection = Connection.ConnectionString;

            Database.EnsureCreated();
        }

        /// <summary>
        /// Cost centers dataset, a table of my cost centers.
        /// </summary>
        public DbSet<CostCenter> CostCenters { get; set; }

        /// <summary>
        /// Employees table that is created.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostCenter>().ToTable("CostCenter");
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }

    }
}
