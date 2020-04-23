using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tony.SimpleDB
{
    public class MyDbContext : DbContext
    {

        public DbSet<Item> Items { get; set; }
        public DbSet<SubItem> Grades { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Check the server name in SQL Server Object Explorer
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DemoDB;Trusted_Connection=True;");
        }

    }


}
