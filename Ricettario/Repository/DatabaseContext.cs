using Ricettario.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricettario.Repository
{

   

        public class DatabaseContext : DbContext
        {
            public DbSet<RecipeModel> Recipes { get; set; }

            public DatabaseContext() : base(GetConnection(), false)
            {

            }

            public static DbConnection GetConnection()
            {
            //    var connection = ConfigurationManager.ConnectionStrings["SQLiteConnection"];

                var connection = ConfigurationManager.ConnectionStrings["Data Source=c:\\test2.db"];


            var factory = DbProviderFactories.GetFactory(connection.ProviderName);
                var dbCon = factory.CreateConnection();
                dbCon.ConnectionString = connection.ConnectionString;
                return dbCon;
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                modelBuilder.Configurations.Add(new RecipeMap());
                base.OnModelCreating(modelBuilder);
            }
        }

        public class RecipeMap : EntityTypeConfiguration<RecipeModel>
        {
            public RecipeMap()
            {
                ToTable("Recipe");

                Property(p => p.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
                Property(p => p.Name).IsRequired();
                Property(p => p.Minutes).IsRequired();
                Property(p => p.People).IsRequired();
                Property(p => p.Level).IsRequired();
                Property(p => p.PubDate).IsRequired();


            }
        }
    }

