using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class BuildingManagementContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\ProjectsV13",
                InitialCatalog = "BuildingManagement",
                UserID = "askar",
                Password = "123456"
            };

            var connectionString = builder.ConnectionString;

            // Use connection string
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=BuildingManagement;Trusted_Connection=true");
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<CardHistory> CardHistories { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
