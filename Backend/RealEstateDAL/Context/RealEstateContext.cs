using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RealEstateDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDAL.Context
{
    public class RealEstateContext : IdentityDbContext<AppUser>
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
        public DbSet<AppUser> AppUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasOne(e => e.Developer)
                .WithOne(c => c.AppUser)
                .HasForeignKey<Developer>(i => i.AppUserID);

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

            modelBuilder.Entity<ConfigurationOption>()
                .HasOne(b => b.ConfigurationItem)
                .WithMany(i => i.ConfigurationOption)
                .OnDelete(DeleteBehavior.Restrict); ;
                //.HasForeignKey<ConfigurationOption>(b => b.ConfigurationItemId);

            modelBuilder.Entity<PropertyConfigurationItems>()
                .HasOne(b => b.PropertyConfiguration)
                .WithMany(i => i.PropertyConfigurationItems)
                .OnDelete(DeleteBehavior.Restrict); ;
                //.HasForeignKey<PropertyConfigurationItems>(b => b.PropertyConfigurationID);

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
                optionsBuilder.UseSqlServer("Server =.; Database = RealEstateDB; Trusted_Connection = True");
                return new RealEstateContext(optionsBuilder.Options);
            }
        }
    }
}