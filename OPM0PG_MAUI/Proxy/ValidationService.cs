using WSH_HomeAssignment.Api.Contracts;

namespace OPM0PG_MAUI.Proxy
{
    public class ValidationService
    {
        ValidationDto validationDto;
        private readonly RestClient client;
        public ValidationService(RestClient client)
        {
            this.client = client;
        }
        public async Task<ValidationDto> GetValidationValuesAsync()
        {
            return validationDto??= await client.GetAsync<ValidationDto>("api/validation/values");
        }

    }
}
