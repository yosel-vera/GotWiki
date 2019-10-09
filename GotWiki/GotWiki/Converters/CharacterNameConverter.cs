using GotWiki.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using System.Linq;
namespace GotWiki.Converters
{
    public class CharacterNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var character = (Characters)value;
            if (value != null)
            {
                var name = string.IsNullOrEmpty(character.Name)
                    ? character.Aliases?.FirstOrDefault() : character.Name;
                return name;
            }
            else
                return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
