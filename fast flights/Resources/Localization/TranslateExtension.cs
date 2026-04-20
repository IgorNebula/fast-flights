using System.Globalization;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;

namespace fast_flights.Resources.Localization
{
    [ContentProperty(nameof(Text))]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            var translation = LocalizationResourceManager.Current.GetString(Text);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    $"Key '{Text}' was not found in resources for culture '{CultureInfo.CurrentUICulture.Name}'.",
                    nameof(Text));
#else
                translation = Text; // Returns the key, which GETS DISPLAYED TO THE USER
#endif
            }

            return translation;
        }
    }
}
