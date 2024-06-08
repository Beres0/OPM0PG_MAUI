using WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs
{
    public static class SavedDailyExchangeRatesDtoMapper
    {
        public static SavedDailyExchangeRatesDto ToDto(this SavedDailyExchangeRateCollection exchangeRates)
        {
            return new SavedDailyExchangeRatesDto()
            {
                Date = exchangeRates.Date.ToDto(),
                ExchangeRates = exchangeRates.ToDictionary(r => r.Key, r => r.Value.ToDto()),
                Notes = new Dictionary<string, string?>(exchangeRates.GetNotes())
            };
        }
    }
}