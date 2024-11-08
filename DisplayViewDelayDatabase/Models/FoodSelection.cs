using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisplayViewDelayDatabase.Models
{
    public class FoodSelection : ObservableObject
    {
        public FoodSelection()
        {
            OnPropertyChanged(nameof(IsValid));
        }


        [Key]                                                   // Primary Key will already be indexed in a Table
        [Column(Order = 1)]
        public int Id { get; set; }


        #region SavedMealItem

        private SavedMeal _savedMeal;

        [Column(Order = 2)]
        [ForeignKey("SavedMeal")]
        public int SavedMealId { get; set; }
        public virtual SavedMeal SavedMealItem
        {
            get => _savedMeal;
            set
            {
                if (SetProperty(ref _savedMeal, value))
                {
                    if (_savedMeal != null)
                    {
                        SavedMealId = _savedMeal.Id;
                    }
                }
            }
        }

        #endregion

        #region FoodItem

        private Food _foodItem;

        [Column(Order = 3)]
        [ForeignKey("Food")]
        public int FoodId { get; set; }
        public virtual Food FoodItem
        {
            get => _foodItem;
            set
            {
                if (SetProperty(ref _foodItem, value))
                {
                    if (_foodItem != null)
                    {
                        FoodId = _foodItem.Id;

                        OnPropertyChanged(nameof(FoodNameForGrouping));
                    }
                }
            }
        }

        [NotMapped]
        public string FoodNameForGrouping => FoodItem?.Name;

        #endregion

        #region SortOrderIndex

        private int _sortOrderIndex;

        [Column(Order = 4)]
        [Range(1, int.MaxValue)]
        public int SortOrderIndex
        {
            get => _sortOrderIndex;
            set => SetProperty(ref _sortOrderIndex, value);
        }

        #endregion

        #region IsSelected

        private bool _isSelected = false;

        [NotMapped]
        [Column(Order = 5)]
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        #endregion

        #region Min

        private int _min = 0;

        [Column(Order = 6)]
        public int Min
        {
            get => _min;
            set
            {
                if (SetProperty(ref _min, value))
                {
                    OnPropertyChanged(nameof(IsValid));
                }
            }
        }

        #endregion

        #region Max

        private int _max = 0;

        [Column(Order = 7)]
        public int Max
        {
            get => _max;
            set
            {
                if (SetProperty(ref _max, value))
                {
                    OnPropertyChanged(nameof(IsValid));
                }                
            }
        }

        #endregion

        #region OptimalAmount

        private int _optimalAmount = 0;

        [Column(Order = 8)]
        public int OptimalAmount
        {
            get => _optimalAmount;
            set => SetProperty(ref _optimalAmount, value);
        }

        #endregion        

        #region IsValid

        [NotMapped]
        [Column(Order = 9)]
        public bool IsValid
        {
            get => (Min <= Max);
        }

        #endregion


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            FoodSelection other = (FoodSelection)obj;
            return SavedMealId == other.SavedMealId && FoodId == other.FoodId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + SavedMealId.GetHashCode();
                hash = hash * 23 + FoodId.GetHashCode();
                return hash;
            }
        }
    }
}
