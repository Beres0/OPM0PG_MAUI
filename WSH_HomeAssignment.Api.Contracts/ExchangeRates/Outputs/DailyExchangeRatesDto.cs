namespace WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs
{
    public class DailyExchangeRatesDto
    {
        public DateDto Date { get; set; } = null!;
        public Dictionary<string, ExchangeRateDto> ExchangeRates { get; set; } = new();
    }
}