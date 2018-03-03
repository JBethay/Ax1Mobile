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
        private readonly string _localdb;

        /// <summary>
        /// Cost centers dataset, a table of my cost centers.
        /// </summary>
        public DbSet<CostCenter> CostCenters { get; set; }

        /// <summary>
        /// Employees table that is created.
        /// </summary>
        //public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="options"></param>
        public Ax1Context(string localdb)
        {
            _localdb = localdb;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(string.Format("Filename={0}", _localdb));
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostCenter>().ToTable("CostCenter");
            modelBuilder.Entity<Employee>().ToTable("Employee");
        } */
    }
}
