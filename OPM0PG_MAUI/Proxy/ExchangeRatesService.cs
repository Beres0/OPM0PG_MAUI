
using CommunityToolkit.Mvvm.ComponentModel;
using OPM0PG_MAUI.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Inputs;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs;
using WSH_HomeAssignment.Domain.Contracts;

namespace OPM0PG_MAUI.Proxy
{
    public class ExchangeRatesService
    {
        public const string Address = $"api/exchange-rates";
        private readonly RestClient client;
        public ExchangeRatesService(RestClient client)
        {
            this.client = client;
        }
        public async Task<SavedExchangeRateDto> GetSavedAsync(DateDto date, string currency)
        {
            return await client.GetAsync<SavedExchangeRateDto>($"{Address}/saved/{date}/{currency}");
        }
        public async Task<SavedExchangeRateDto> CreateSavedAsync(DateDto date, string currency, CreateUpdateSavedExchangeRateDto input)
        {
            return await client.PostAsync<CreateUpdateSavedExchangeRateDto, SavedExchangeRateDto>
                ($"{Address}/saved/{date}/{currency}", input);
        }

        public async Task<SavedExchangeRateDto> UpdateSavedAsync(DateDto date,string currency, CreateUpdateSavedExchangeRateDto input)
        {
            return await client.PutAsync<CreateUpdateSavedExchangeRateDto, SavedExchangeRateDto>
              ($"{Address}/saved/{date}/{currency}", input);
        }

        public async Task DeleteSavedAsync(DateDto date, string currency)
        {
            await client.DeleteAsync($"{Address}/saved/{date}/{currency}");
        }

        public async Task<DailyExchangeRatesDto> GetCurrentAsync()
        {
            return await client.GetAsync<DailyExchangeRatesDto>($"{Address}/current");
        }

        public async Task<PagedResultDto<SavedExchangeRateDto>> GetSavedListAsync(PaginationArgsDto input)
        {
            return await client.GetAsync<PagedResultDto<SavedExchangeRateDto>>
                ($"{Address}/saved?{nameof(input.Skip)}={input.Skip}&{nameof(input.Take)}={input.Take}");
        }
        public async Task<SavedDailyExchangeRatesDto> GetSavedCurrentAsync()
        {
            return await client.GetAsync<SavedDailyExchangeRatesDto>($"{Address}/saved/current");
        }
    }
}
