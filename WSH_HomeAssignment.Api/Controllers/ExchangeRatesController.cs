using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Inputs;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs;
using WSH_HomeAssignment.Api.Filters;
using WSH_HomeAssignment.Api.Services.ExchangeRates;
using WSH_HomeAssignment.Api.Services.ExchangeRates.Inputs;

namespace WSH_HomeAssignment.Api.Controllers
{


    [Route("api/exchange-rates")]
    [ApiController]
    [ExceptionToHttpErrorFilter]
    public class ExchangeRatesController : ControllerBase, IExchangeRatesAppService
    {
        private readonly IExchangeRatesAppService service;
        public ExchangeRatesController(IExchangeRatesAppService service)
        {
            this.service = service;
        }

        [HttpGet("saved/{date}/{currency}")]
        public async Task<SavedExchangeRateDto> GetSavedAsync([FromRoute]DateDto date, [FromRoute]string currency)
        {
            return await service.GetSavedAsync(date, currency);
        }

        [HttpPost("saved/{date}/{currency}")]
        public async Task<SavedExchangeRateDto> CreateSavedAsync([FromRoute] DateDto date, [FromRoute] string currency, [FromBody] CreateUpdateSavedExchangeRateDto input)
        {
            return await service.CreateSavedAsync(date, currency, input);
        }

        [HttpPut("saved/{date}/{currency}")]
        public async Task<SavedExchangeRateDto> UpdateSavedAsync(DateDto date, string currency, [FromBody] CreateUpdateSavedExchangeRateDto input)
        {
            return await service.UpdateSavedAsync(date, currency, input);
        }

        [HttpDelete("saved/{date}/{currency}")]
        public async Task DeleteSavedAsync(DateDto date, string currency)
        {
            await service.DeleteSavedAsync(date, currency);
        }


        [HttpGet("current")]
        public async Task<DailyExchangeRatesDto> GetCurrentAsync()
        {
            return await service.GetCurrentAsync();
        }

        [HttpGet("saved")]
        public async Task<PagedResultDto<SavedExchangeRateDto>> GetSavedListAsync([FromQuery] PaginationArgsDto input)
        {
            return await service.GetSavedListAsync(input);
        }

        [HttpGet("saved/current")]
        public Task<SavedDailyExchangeRatesDto> GetSavedCurrentAsync()
        {
            return service.GetSavedCurrentAsync();
        }
    }
}