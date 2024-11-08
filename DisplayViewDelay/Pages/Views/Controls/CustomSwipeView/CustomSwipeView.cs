namespace DisplayViewDelay.Pages.Views.Controls.CustomSwipeView
{
    public class CustomSwipeView : SwipeView
    {
        public static readonly BindableProperty SwipeViewOpenFlagProperty = BindableProperty.Create(nameof(SwipeViewOpenFlag), typeof(bool), typeof(CustomSwipeView), true, propertyChanged: OnPropertyChanged);

        public bool SwipeViewOpenFlag
        {
            get { return (bool)GetValue(SwipeViewOpenFlagProperty); }
            set { SetValue(SwipeViewOpenFlagProperty, value); }
        }

        private static void OnPropertyChanged(BindableObject sender, object oldValue, object newValue)
        {
            SwipeView swipeView = sender as SwipeView;
            var keepSwipeViewOpen = (bool)newValue;

            if (swipeView != null && !keepSwipeViewOpen)
            {
                swipeView.Close();

                ((CustomSwipeView)sender).SwipeViewOpenFlag = true;
            }
        }
    }
}
