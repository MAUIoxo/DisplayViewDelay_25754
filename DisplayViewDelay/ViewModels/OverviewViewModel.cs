using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DevExpress.Data.Filtering;
using DisplayViewDelay.Core.Database;
using DisplayViewDelay.Helpers;
using DisplayViewDelay.ViewModels.Messages;
using DisplayViewDelayDatabase.Models;
using Microsoft.EntityFrameworkCore;
using MvvmHelpers;

namespace DisplayViewDelay.ViewModels
{
    public partial class OverviewViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private IDatabaseService _databaseService;


        [ObservableProperty]
        private ObservableRangeCollection<Food> availableItems;

        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private FunctionOperator searchFilterExpression;
                


        public OverviewViewModel()
        {
            WeakReferenceMessenger.Default.Register<RefreshFoodsOverviewMessage>(this, HandleRefreshFoodsOverviewMessage);

            _databaseService = ServiceHelper.GetService<IDatabaseService>();

            AvailableItems = new ObservableRangeCollection<Food>();

            SearchFilterExpression = new FunctionOperator(FunctionOperatorType.StartsWith, new OperandProperty(nameof(Food.Name)), new ConstantValue(""));
        }

        private async void HandleRefreshFoodsOverviewMessage(object recipient, RefreshFoodsOverviewMessage foodItemMessage)
        {
            await LoadAvailableItemsAsync();
        }

        [RelayCommand]
        private async Task DeleteFoodItem(Food foodItem)
        {
            
        }        

        [RelayCommand]
        private async Task EditFoodItem(Food foodItem)
        {
            
        }

        #region Search Filter

        /// <summary>
        /// Automatically invoked when the value of the SearchText property changes.
        /// This method directly updates the FilterExpression based on the new search text,
        /// creating a new <see cref="FunctionOperator"/> that filters entries starting with the updated SearchText.
        /// This ensures that the FilterExpression is always in sync with the current SearchText,
        /// allowing for dynamic adjustments of the filter applied to displayed data, based on user input.
        /// </summary>
        /// <param name="value">The new value of SearchText, which is used to update the SearchFilterExpression
        /// to reflect the current filter criteria.</param>
        partial void OnSearchTextChanged(string value)
        {
            SearchFilterExpression = new FunctionOperator(FunctionOperatorType.StartsWith, new OperandProperty(nameof(Food.Name)), new ConstantValue(SearchText));
        }

        #endregion

        #region Loading of FoodItems

        private async Task LoadAvailableItemsAsync()
        {
            var foodItems = await _databaseService.DatabaseContext.Foods.OrderBy(foodItem => foodItem.Name).ToListAsync();
            
            AvailableItems.ReplaceRange(foodItems);
        }

        #endregion

        #region CustomSwipeView SwipeViewOpenFlag

        private bool _swipeViewOpenFlag;
        public bool SwipeViewOpenFlag
        {
            get => !_swipeViewOpenFlag;
            set
            {
                // Close SwipeView when set to false
                _swipeViewOpenFlag = !value;

                OnPropertyChanged(nameof(SwipeViewOpenFlag));
            }
        }

        #endregion
    }
}