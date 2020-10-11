using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccessUniversity.Helper.Resources
{
    [ContentProperty("Text")]
    class Translator : IMarkupExtension
    {
        const string ResourceId = "AccessUniversity.Helper.Resources.AppResources";
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return null;
            }
                ResourceManager resman = new ResourceManager(ResourceId, typeof(Translator).GetTypeInfo().Assembly);
                return resman.GetString(Text, CultureInfo.CurrentCulture);
        }
    }
}
