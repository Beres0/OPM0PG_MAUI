using WSH_HomeAssignment.Domain.Contracts;

namespace WSH_HomeAssignment.Api.Contracts.ExchangeRates
{
    public static class DateDtoMapper
    {
        public static DateDto ToDto(this DateOnly date)
        {
            return new DateDto()
            {
                Year = date.Year,
                Month = date.Month,
                Day = date.Day
            };
        }

        public static DateOnly ToDateOnly(this DateDto dto)
        {
            try
            {
                var date = new DateOnly(dto.Year, dto.Month, dto.Day);
                if (date >= DomainConstants.DateMin)
                {
                    return date;
                }
            }
            catch { }
            return DomainConstants.DateMin;
        }
    }
}