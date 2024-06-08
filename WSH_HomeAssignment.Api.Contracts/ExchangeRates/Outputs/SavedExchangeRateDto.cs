namespace WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs
{
    public class SavedExchangeRateDto
    {
        public DateDto Date { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public int Unit { get; set; }
        public double Value { get; set; }
        public string? Note { get; set; }
    }
}