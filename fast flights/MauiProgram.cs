using Microsoft.Extensions.Logging;
using fast_flights.Resources.Localization;
using System.Globalization;

namespace fast_flights
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Настройка локализации
            var cultureInfo = new CultureInfo(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);
            LocalizationResourceManager.Current.SetCulture(cultureInfo);

            return builder.Build();
        }
    }
}
