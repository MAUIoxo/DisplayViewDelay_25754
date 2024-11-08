using CommunityToolkit.Mvvm.Messaging.Messages;

namespace DisplayViewDelay.ViewModels.Messages
{
    public class RefreshFoodsOverviewMessage : ValueChangedMessage<bool>
    {
        public RefreshFoodsOverviewMessage(bool value) : base(value)
        {
            
        }
    }
}
