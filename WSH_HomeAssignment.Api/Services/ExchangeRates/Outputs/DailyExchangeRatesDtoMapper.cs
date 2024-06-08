using WSH_HomeAssignment.Api.Contracts.ExchangeRates;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs
{
    internal static class DailyExchangeRatesDtoMapper
    {
        public static DailyExchangeRatesDto ToDto(this DailyExchangeRateCollection exchangeRates)
        {
            return new DailyExchangeRatesDto()
            {
                Date = exchangeRates.Date.ToDto(),
                ExchangeRates = exchangeRates.ToDictionary(r => r.Key, r => r.Value.ToDto())
            };
        }
    }
}