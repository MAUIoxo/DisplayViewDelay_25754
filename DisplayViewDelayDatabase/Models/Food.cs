using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisplayViewDelayDatabase.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Food : ObservableObject
    {
        [Key]                                                               // Primary Key will already be indexed in a Table
        [Column(Order = 1)]
        public int Id { get; set; }


        #region Name

        private string _name;

        [Required]
        [Column(Order = 2, TypeName = "TEXT COLLATE NOCASE")]              // Ignore case sensitivity for the Unique Constraint
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        #endregion

        #region Brand

        private string? _brand;

        [Column(Order = 3)]
        public string? Brand
        {
            get => _brand;
            set => SetProperty(ref _brand, value);
        }

        #endregion

        #region Fats

        private double _fats;

        [Column(Order = 4)]
        public double Fats
        {
            get => _fats;
            set => SetProperty(ref _fats, value);
        }

        #endregion

        #region Carbohydrates

        private double _carbohydrates;

        [Column(Order = 5)]
        public double Carbohydrates
        {
            get => _carbohydrates;
            set => SetProperty(ref _carbohydrates, value);
        }

        #endregion

        #region Proteins

        private double _proteins;

        [Column(Order = 6)]
        public double Proteins
        {
            get => _proteins;
            set => SetProperty(ref _proteins, value);
        }

        #endregion

        #region FoodSelections

        private List<FoodSelection> _foodSelections;
        public virtual List<FoodSelection> FoodSelections
        {
            get => this._foodSelections ?? (this._foodSelections = new List<FoodSelection>());
            set => SetProperty(ref _foodSelections, value);
        }

        #endregion
    }
}