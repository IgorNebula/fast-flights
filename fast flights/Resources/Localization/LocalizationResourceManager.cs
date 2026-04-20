using System.Globalization;
using System.Resources;
using System.Reflection;

namespace fast_flights.Resources.Localization
{
    public class LocalizationResourceManager
    {
        private static readonly Lazy<LocalizationResourceManager> _current = new Lazy<LocalizationResourceManager>(() => new LocalizationResourceManager());

        public static LocalizationResourceManager Current => _current.Value;

        private ResourceManager? _resourceManager;

        private LocalizationResourceManager()
        {
            _resourceManager = new ResourceManager("fast_flights.Resources.Localization.AppResources", Assembly.GetExecutingAssembly());
        }

        public void SetCulture(CultureInfo culture)
        {
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            Invalidate();
        }

        public string? GetString(string key)
        {
            return _resourceManager?.GetString(key, CultureInfo.CurrentUICulture);
        }

        public object? GetObject(string key)
        {
            return _resourceManager?.GetObject(key, CultureInfo.CurrentUICulture);
        }

        public event EventHandler? LanguageChanged;

        public void Invalidate()
        {
            LanguageChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    // Расширение для упрощенного доступа к локализованным строкам
    public static class LocalizationExtensions
    {
        public static string? Localize(this string key)
        {
            return LocalizationResourceManager.Current.GetString(key);
        }
    }
}
