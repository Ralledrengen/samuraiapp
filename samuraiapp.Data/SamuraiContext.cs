﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SamuraiApp.Domain;


namespace SamuraiApp.Data
{
    public class SamuraiContext:DbContext
    {
        private DbContextOptions options;

        public SamuraiContext() {}
        public SamuraiContext(DbContextOptions<SamuraiContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public SamuraiContext(DbContextOptions options)
        {
            this.options = options;
        }

        //Nu til 8
        public virtual DbSet<Samurai> Samurais { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Clan> Clans { get; set; }
        public virtual DbSet<Battle> Battles { get; set; }
        public virtual DbSet<SamuraiBattleStat> SamuraiBattleStats { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
            modelBuilder.Entity<Horse>().ToTable("Horse");
            modelBuilder.Entity<SamuraiBattleStat>().HasNoKey().ToView("SamuraiBattleStats");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    //.UseLoggerFactory(ConsoleLoggerFactory)
                    //.EnableSensitiveDataLogging()
                    .UseSqlServer(
                    "Data Source = (localdb)\\ MSSQLLocalDB; INITIAL CATALOG = SamuraiAppData");
            }

        }
    }
}
