using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using System.Reflection.Emit;
using CosmosTestPublic.Models;

//using Northwind.Models;

namespace CosmosTestPublic.Data;
public class testcosmos101context : DbContext
{

    public DbSet<GlobalSettings> GlobalSettings { get; set; }
    public DbSet<Template> Templates { get; set; }

    //method to cinfigure our project with cosmos db
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(
            //"accountEndpoint" to connect to db,
           //"accountKey" is primary key to perform read/write
          //"databaseName"
            );
    }

    //help to configure our entities to our containers
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        #region configuring Template
        modelBuilder.Entity<Template>()
                .ToContainer("Templates") // ToContainer
                .HasPartitionKey(o => o.Id); // Partition Key
        #endregion

        #region configuring Global settings
        modelBuilder.Entity<GlobalSettings>()
                .ToContainer("GlobalSettings") // ToContainer
                .HasPartitionKey(o => o.Id); // Partition Key
        #endregion

    }
}