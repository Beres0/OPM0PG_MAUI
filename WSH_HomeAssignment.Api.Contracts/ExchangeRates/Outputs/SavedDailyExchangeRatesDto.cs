using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs;

namespace WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs
{
    public class SavedDailyExchangeRatesDto
    {
        public DateDto Date { get; set; } = null!;
        public Dictionary<string, ExchangeRateDto> ExchangeRates { get; set; } = new();
        public Dictionary<string, string?> Notes { get; set; } = new();
    }
}