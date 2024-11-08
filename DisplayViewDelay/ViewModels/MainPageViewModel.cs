using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DisplayViewDelay.ViewModels.Messages;

namespace DisplayViewDelay.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public string mainPageTitle;

        

        private byte _selectedViewModelIndex;
        public byte SelectedViewModelIndex
        {
            get => _selectedViewModelIndex;
            set
            {
                _selectedViewModelIndex = value;

                WeakReferenceMessenger.Default.Send(new SelectedViewChangedMessage(_selectedViewModelIndex));
            }
        }


        public MainPageViewModel()
        {
            MainPageTitle = "Tab 1";

            SelectedViewModelIndex = 0;
        }
    }
}
