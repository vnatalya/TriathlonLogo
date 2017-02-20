#if __ANDROID__
namespace App2.Android
#elif __IOS__
namespace App2.iOS
#else
namespace App2.UWP
#endif
{
    using System;

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Language
    {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;

        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Language()
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.Equals(null, resourceMan))
                {
#if __ANDROID__
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("App2.Android.Language", typeof(Language).Assembly);
#elif __IOS__
					System.Resources.ResourceManager temp = new System.Resources.ResourceManager("App2.iOS.Language", typeof(Language).Assembly);
#else
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("App2.Shared.Language", typeof(Language).Assembly);
#endif
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static string key
        {
            get
            {
                return ResourceManager.GetString("key", resourceCulture);
            }
        }
    }
}
