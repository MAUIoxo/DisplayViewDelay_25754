using CommunityToolkit.Mvvm.Messaging;
using DisplayViewDelay.ViewModels;
using DisplayViewDelay.ViewModels.Messages;

namespace DisplayViewDelay.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel mainPageViewModel;
        private byte SelectedViewIndex { get; set; }


        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();

            mainPageViewModel = viewModel;
            BindingContext = viewModel;

            WeakReferenceMessenger.Default.Register<SelectedViewChangedMessage>(this, HandleSelectedViewChangedMessage);
        }

        private void HandleSelectedViewChangedMessage(object recipient, SelectedViewChangedMessage message)
        {
            SelectedViewIndex = message.Value;
            
            if (SelectedViewIndex == 0)
            {
                UpdatePageTitleForSelectedView();

                ToolbarItems.Clear();
            }
            else if (SelectedViewIndex == 1)
            {
                UpdatePageTitleForSelectedView();

                WeakReferenceMessenger.Default.Send(new RefreshFoodsOverviewMessage(true));
            }
        }

        private void UpdatePageTitleForSelectedView()
        {
            switch (SelectedViewIndex)
            {
                case 0:
                    mainPageViewModel.MainPageTitle = "Calculate";
                    break;

                case 1:
                    mainPageViewModel.MainPageTitle = "Overview";
                    break;
            }
        }

        protected override void OnAppearing()
        {
            Shell.SetTabBarIsVisible(this, false);
        }
    }
}