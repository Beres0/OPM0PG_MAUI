using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WSH_HomeAssignment.Domain.Contracts;

namespace WSH_HomeAssignment.Api.Contracts.ExchangeRates
{
    [TypeConverter(typeof(DateDtoConverter))]
    public class DateDto
    {
        public const string Format = "yyyy-MM-dd";
        public int Year { get; set; } = DomainConstants.DateMin.Year;

        [Range(1, 12)]
        public int Month { get; set; } = DomainConstants.DateMin.Month;

        [Range(1, 31)]
        public int Day { get; set; } = DomainConstants.DateMin.Day;

        public override string ToString()
        {
            return new DateOnly(Year, Month, Day).ToString(Format);
        }
    }
}