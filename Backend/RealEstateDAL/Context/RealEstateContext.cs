﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RealEstateDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDAL.Context
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) 
            : base(options) { }
           
        public DbSet<Client> Clients { get; set; }
        public DbSet<ConfigurationItem> ConfigurationsItems { get; set; }
        public DbSet<ConfigurationOption> ConfigurationsOptions { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyConfiguration> PropertiesConfigurations { get; set; }
        public DbSet<PropertyConfigurationItems> PropertiesConfigurationsItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
            .HasOne(e => e.Developer)
            .WithMany(c => c.Contracts)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Property>()
            .HasOne(b => b.Contract)
            .WithOne(i => i.Property)
            .HasForeignKey<Contract>(b => b.PropertyID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
                .HasOne(b => b.Configuration)
                .WithOne(i => i.Contract)
                .HasForeignKey<PropertyConfiguration>(b => b.ContractID);

            modelBuilder.Entity<ConfigurationItem>()
                .HasOne(b => b.ConfigurationOption)
                .WithOne(i => i.ConfigurationItem)
                .HasForeignKey<ConfigurationOption>(b => b.ConfigurationItemId);

            modelBuilder.Entity<PropertyConfiguration>()
                .HasOne(b => b.PropertyConfigurationItems)
                .WithOne(i => i.PropertyConfiguration)
                .HasForeignKey<PropertyConfigurationItems>(b => b.PropertyConfigurationID);

            modelBuilder.Entity<ConfigurationItem>()
                .HasOne(b => b.PropertyConfigurationItems)
                .WithOne(i => i.ConfigurationItem)
                .HasForeignKey<PropertyConfigurationItems>(b => b.ConfigurationItemID);

            modelBuilder.Entity<ConfigurationOption>()
                .HasOne(b => b.PropertyConfigurationItems)
                .WithOne(i => i.ConfigurationOption)
                .HasForeignKey<PropertyConfigurationItems>(b => b.ConfigurationOptionID)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public class RealEstateContextFactory : IDesignTimeDbContextFactory<RealEstateContext>
        {
            public RealEstateContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<RealEstateContext>();
                optionsBuilder.UseSqlServer("Server =.; Database = RealEstateDBDev; Trusted_Connection = True");
                return new RealEstateContext(optionsBuilder.Options);
            }
        }
    }
}