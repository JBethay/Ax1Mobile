using Microsoft.EntityFrameworkCore;
using System;

namespace Ax1Mobile
{
    /// <summary>
    /// Context class
    /// </summary>
    public class Ax1Context : DbContext
    {
        #region Private implementation
        private readonly string _localdb;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="options"></param>
        protected Ax1Context(string localdb)
        {
            _localdb = localdb;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(string.Format("Filename={0}", _localdb));
        }
        #endregion

        /// <summary>
        /// Cost centers dataset, a table of my cost centers.
        /// </summary>
        public DbSet<CostCenter> CostCenters { get; set; }

        /// <summary>
        /// Employees table that is created.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        public static Ax1Context Create(string localdb)
        {
            var dbContext = new Ax1Context(localdb);
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
            return dbContext;
        }
    }
}
