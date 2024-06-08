using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace WSH_HomeAssignment.Api.Contracts.ExchangeRates
{
    public class DateDtoConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            if (sourceType==typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
        {
            if (destinationType == typeof(DateDto))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }
        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            var dto = value as DateDto;
            if(dto is not null)
            {
                return dto.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            var str = value as string;
            if (DateOnly.TryParseExact(str, DateDto.Format, out DateOnly result))
            {
                return result.ToDto();
            }

            return new DateDto();
        }
    }
}