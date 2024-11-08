using DisplayViewDelayDatabase.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DisplayViewDelayDatabase.Core
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }

        public DbSet<SavedMeal> SavedMeals { get; set; }

        public DbSet<FoodSelection> FoodSelections { get; set; }

        ///// <summary>
        ///// Use this for the creation of new Database Migrations
        ///// </summary>
        //public DatabaseContext()
        //{

        //}

        /// <summary>
        /// Comment out this method for "dotnet ef migrations add <...>" command
        /// </summary>
        /// <param name="options"></param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //DeleteDatabase();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Use $"Data Source={""} ..." for "dotnet ef migrations add <...>" command
                //string connectionString = $"Data Source={""}";
                //optionsBuilder.UseSqlite(connectionString);


                var connectionStringBuilder = new SqliteConnectionStringBuilder
                {
                    DataSource = DatabaseConstants.DatabasePath,
                    Mode = SqliteOpenMode.ReadWriteCreate,
                    Cache = SqliteCacheMode.Shared,
                };

                optionsBuilder.UseSqlite(connectionStringBuilder.ToString());
                optionsBuilder.EnableDetailedErrors(true);

                base.OnConfiguring(optionsBuilder);
            }
        }

        public void DeleteDatabase()
        {
            if (File.Exists(DatabaseConstants.DatabasePath))
            {
                File.Delete(DatabaseConstants.DatabasePath);
            }
        }
    }
}
