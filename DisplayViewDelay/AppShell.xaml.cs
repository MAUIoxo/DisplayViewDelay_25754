using DisplayViewDelay.Core.Database;
using DisplayViewDelay.Helpers;
using DisplayViewDelayDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace DisplayViewDelay
{
    public partial class AppShell : Shell
    {
        private readonly IDatabaseService _databaseService;

        public AppShell()
        {
            InitializeComponent();

            _databaseService = ServiceHelper.GetService<IDatabaseService>();

            // Initialize and load sample data
            InitializeDataAsync();
        }



        private async Task InitializeDataAsync()
        {
            // Deletes all existing data and adds sample data
            await DeleteAllFoodsAsync();
            await AddSampleFoodsAsync();
        }

        private async Task DeleteAllFoodsAsync()
        {
            // Retrieve all foods and delete them from the table
            var allFoods = await _databaseService.DatabaseContext.Foods.ToListAsync();
            _databaseService.DatabaseContext.Foods.RemoveRange(allFoods);
            await _databaseService.DatabaseContext.SaveChangesAsync();
        }

        private async Task AddSampleFoodsAsync()
        {
            // Define a list of sample food data
            var sampleFoods = new List<Food>
            {
                new Food
                {
                    Name = "Apple",
                    Brand = "Fresh Farm",
                    Fats = 0.2,
                    Carbohydrates = 13.8,
                    Proteins = 0.3
                },
                new Food
                {
                    Name = "Banana",
                    Brand = "Tropical Delight",
                    Fats = 0.3,
                    Carbohydrates = 22.8,
                    Proteins = 1.1
                },
                new Food
                {
                    Name = "Chicken Breast",
                    Brand = "Farm Fresh",
                    Fats = 3.6,
                    Carbohydrates = 0.0,
                    Proteins = 31.0
                }
            };

            // Add sample foods to the database and save changes
            _databaseService.DatabaseContext.Foods.AddRange(sampleFoods);
            await _databaseService.DatabaseContext.SaveChangesAsync();
        }
    }
}
