using System;
using System.Collections.Generic;
using System.Text;

namespace Ax1.DAL
{
    public static class Connection
    {
        private static readonly string user = ""; //This user name only has read/write privileges for the database and is not the master username. This username is restricted and can be deleted or changed at anytime.

        private static readonly string pw = "";

        private static string connectionString = $"Server=tcp:ax1managment-1.database.windows.net,1433;Initial Catalog=Ax1webdb;Persist Security Info=False;User ID={user};Password={pw};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static string ConnectionString { get => connectionString; set => connectionString = value; }
    }
}
