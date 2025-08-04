using System.ComponentModel;
using System.Globalization;

namespace Vos.Models.Document
{
    public class TextLocationConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) 
                => sourceType == typeof(string);

        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
                => destinationType == typeof(TextLocation);

        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            var s = value as string;

            var parts = s?.Split(';', ',');

            if (parts?.Length == 2)
            {
                return new TextLocation(int.Parse(parts[0], culture), int.Parse(parts[1], culture));
            }

            throw new InvalidOperationException();
        }

        public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (value is TextLocation loc && destinationType == typeof(string))
            {
                return loc.Line.ToString(culture) + ";" + loc.Column.ToString(culture);
            }

            throw new InvalidOperationException();
        }
    }
}
