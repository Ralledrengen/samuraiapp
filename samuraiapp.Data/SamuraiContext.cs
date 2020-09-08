using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;


namespace SamuraiApp.Data
{
    public class SamuraiContext:DbContext
    {
        //Nu til 5
        public virtual DbSet<Samurai> Samurais { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Clan> Clans { get; set; }
        public virtual DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\ MSSQLLocalDB; INITIAL CATALOG = SamuraiAppData");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
            modelBuilder.Entity<Horse>().ToTable("Horse");
        }
    }
}
