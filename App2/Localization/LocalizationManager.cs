using System;
using System.Globalization;
using System.Threading;
using App2;
#if __ANDROID__
namespace App2.Android
#else
namespace App2.iOS
#endif
{
    public class LocalizationManager : StringService
{
    public static CultureInfo Culture { get; set; }

#if __ANDROID__

        public static void ChangeCulture(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;

            Thread.CurrentThread.CurrentUICulture = culture;

            var locale = new Java.Util.Locale(culture.TwoLetterISOLanguageName);

            Java.Util.Locale.Default = locale;

            var resources = global::Android.App.Application.Context.Resources;

            var config = resources.Configuration;

            config.Locale = locale;

            resources.UpdateConfiguration(config, resources.DisplayMetrics);
        }

#endif

    public static string Translate(string key)
    {
#if __ANDROID__

            if (Culture != null && Thread.CurrentThread.CurrentCulture.Name != Culture.Name)
            {
                ChangeCulture(Culture);
            }
            else
            {
                var locale = Java.Util.Locale.Default;

                if (locale != null && locale.Language != null && locale.Language.ToLower() != Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower())
                {
                    ChangeCulture(Culture);
                }
            }
#endif

        string result = "[null]";

        if (!string.IsNullOrEmpty(key) && !string.IsNullOrWhiteSpace(key))
        {
#if __ANDROID__
                result =  App2.Android.Language.ResourceManager.GetString(key);
#elif __IOS__
                result =  App2.iOS.Language.ResourceManager.GetString(key);
#elif WINDOWS
                result = App2.UWP.Language.ResourceManager.GetString(key);
#endif
        }
#if DEBUG
            if (result == null)
            {
                Console.WriteLine("------------Localization: key='{0}'", key);
            }
#endif

        return result ?? "[null]";
    }

    public override void Init()
    {

        // inc  = Translate("LogIn");               
    }
}
    
}

