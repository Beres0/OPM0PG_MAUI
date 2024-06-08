using WSH_HomeAssignment.Api.Contracts.ExchangeRates;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Inputs;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs;
using WSH_HomeAssignment.Api.Services.ExchangeRates.Inputs;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates
{
    public interface IExchangeRatesAppService
    {
        Task<DailyExchangeRatesDto> GetCurrentAsync();

        Task<SavedDailyExchangeRatesDto> GetSavedCurrentAsync();

        Task<SavedExchangeRateDto> GetSavedAsync(DateDto date, string currency);

        Task<PagedResultDto<SavedExchangeRateDto>> GetSavedListAsync(PaginationArgsDto input);

        Task<SavedExchangeRateDto> CreateSavedAsync(DateDto date, string currency, CreateUpdateSavedExchangeRateDto input);

        Task<SavedExchangeRateDto> UpdateSavedAsync(DateDto date, string currency, CreateUpdateSavedExchangeRateDto input);

        Task DeleteSavedAsync(DateDto date, string currency);
    }
}