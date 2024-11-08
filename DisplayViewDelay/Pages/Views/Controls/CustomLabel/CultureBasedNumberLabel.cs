using CommunityToolkit.Mvvm.Messaging;
using DisplayViewDelay.ViewModels.Messages;
using System.Globalization;

namespace DisplayViewDelay.Pages.Views.Controls.CustomLabel
{
    public class CultureBasedNumberLabel : Label
    {
        public CultureBasedNumberLabel()
        {
            WeakReferenceMessenger.Default.Register<LocalizationChangedMessage>(this, HandleLocalizationChangedMessage);
        }

        private void HandleLocalizationChangedMessage(object recipient, LocalizationChangedMessage message)
        {
            // Identify the incorrect decimal separator - if the current one is '.', the incorrect one would be ',' and vice versa.
            var cultureDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            var wrongSeparator = cultureDecimalSeparator == '.' ? ',' : '.';

            Text = Text?.Replace(wrongSeparator, CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0]);
        }        
    }
}
