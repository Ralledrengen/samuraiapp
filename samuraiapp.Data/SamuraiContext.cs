using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;


namespace SamuraiApp.Data
{
    public class SamuraiContext:DbContext
    {
        //Nu til 4
        public virtual DbSet<Samurai> Samurais { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Clan> Clans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\ MSSQLLocalDB; INITIAL CATALOG = SamuraiAppData");
        }
    }
}
