using CommunityToolkit.Mvvm.Messaging.Messages;

namespace DisplayViewDelay.ViewModels.Messages
{
    public class LocalizationChangedMessage : ValueChangedMessage<bool>
    {
        public LocalizationChangedMessage(bool value) : base(value)
        {
            
        }
    }
}
