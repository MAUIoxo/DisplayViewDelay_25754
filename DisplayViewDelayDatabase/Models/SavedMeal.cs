using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisplayViewDelayDatabase.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class SavedMeal : ObservableObject
    {
        [Key]                                                               // Primary Key will already be indexed in a Table
        [Column(Order = 1)]
        public int Id { get; set; }


        #region Name

        private string _name;

        [Required]
        [Column(Order = 2, TypeName = "TEXT COLLATE NOCASE")]               // Ignore case sensitivity for the Unique Constraint
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        #endregion

        #region Max allowed Macro Nutrients

        #region Max Proteins

        private int _macroNutrientRatio_MaxProteins;

        [Column(Order = 3)]
        public int MacroNutrientRatio_MaxProteins
        {
            get => _macroNutrientRatio_MaxProteins;
            set => SetProperty(ref _macroNutrientRatio_MaxProteins, value);
        }

        #endregion

        #region Max Carbohydrates

        private int _macroNutrientRatio_MaxCarbohydrates;

        [Column(Order = 4)]
        public int MacroNutrientRatio_MaxCarbohydrates
        {
            get => _macroNutrientRatio_MaxCarbohydrates;
            set => SetProperty(ref _macroNutrientRatio_MaxCarbohydrates, value);
        }

        #endregion

        #region Max Fats

        private int _macroNutrientRatio_MaxFats;

        [Column(Order = 5)]
        public int MacroNutrientRatio_MaxFats
        {
            get => _macroNutrientRatio_MaxFats;
            set => SetProperty(ref _macroNutrientRatio_MaxFats, value);
        }

        #endregion

        #region Max Calories

        private int _macroNutrientRatio_MaxCalories;

        [Column(Order = 6)]
        public int MacroNutrientRatio_MaxCalories
        {
            get => _macroNutrientRatio_MaxCalories;
            set => SetProperty(ref _macroNutrientRatio_MaxCalories, value);
        }

        #endregion

        #endregion

        #region Calculated Optimal Amounts for Macro Nutrients

        #region Optimal Amount Proteins

        private double _macroNutrientRatio_OptimalAmountProteins;

        [Column(Order = 7)]
        public double MacroNutrientRatio_OptimalAmountProteins
        {
            get => _macroNutrientRatio_OptimalAmountProteins;
            set => SetProperty(ref _macroNutrientRatio_OptimalAmountProteins, value);
        }

        #endregion

        #region Optimal Amount Proteins

        private double _macroNutrientRatio_OptimalAmountCarbohydrates;

        [Column(Order = 8)]
        public double MacroNutrientRatio_OptimalAmountCarbohydrates
        {
            get => _macroNutrientRatio_OptimalAmountCarbohydrates;
            set => SetProperty(ref _macroNutrientRatio_OptimalAmountCarbohydrates, value);
        }

        #endregion

        #region Optimal Amount Proteins

        private double _macroNutrientRatio_OptimalAmountFats;

        [Column(Order = 9)]
        public double MacroNutrientRatio_OptimalAmountFats
        {
            get => _macroNutrientRatio_OptimalAmountFats;
            set => SetProperty(ref _macroNutrientRatio_OptimalAmountFats, value);
        }

        #endregion

        #region Optimal Amount Proteins

        private double _macroNutrientRatio_OptimalAmountCalories;

        [Column(Order = 10)]
        public double MacroNutrientRatio_OptimalAmountCalories
        {
            get => _macroNutrientRatio_OptimalAmountCalories;
            set => SetProperty(ref _macroNutrientRatio_OptimalAmountCalories, value);
        }

        #endregion

        #endregion

        #region ModifiedSinceLastSave

        private bool _modifiedSinceLastSave;

        [Column(Order = 11)]
        public bool ModifiedSinceLastSave
        {
            get => _modifiedSinceLastSave;
            set => SetProperty(ref _modifiedSinceLastSave, value);
        }

        #endregion

        #region LastSavedDate

        private DateTime _lastSavedDate = DateTime.Now;

        [Column(Order = 12)]
        public DateTime LastSavedDate
        {
            get => _lastSavedDate;
            set => SetProperty(ref _lastSavedDate, value);
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