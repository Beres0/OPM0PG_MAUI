using System.Net.Http.Json;
using WSH_HomeAssignment.Api.Contracts;

namespace OPM0PG_MAUI.Proxy
{
    public class RestClient
    {
        public const string BaseAddress = "https://10.0.2.2:7281/";
        private HttpClient client;
        public RestClient()
        {
            var handler = new HttpClientHandler();
#if DEBUG
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
#endif
            client = new HttpClient(handler);
            client.BaseAddress =new Uri(BaseAddress);
            client.DefaultRequestHeaders.Accept.Add
                (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
            ("application/json"));
        }
        private async Task CheckStatusCodeAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var errorDto =await response.Content.ReadFromJsonAsync<ErrorDto>();
                    if(errorDto.Message is not null)
                    {
                        throw new ServerException(errorDto, response.StatusCode);
                    }
                    else
                    {
                        var validationError = await response.Content.ReadFromJsonAsync<ValidationErrorDto>();
                        if(validationError.Errors is not null)
                        {
                            throw new ServerException(validationError, response.StatusCode);
                        }
                        else
                        {
                            var message = await response.Content.ReadAsStringAsync();
                            throw new ServerException(response.StatusCode,message);
                        }
                    }
                }
                catch
                {
                    throw new ServerException(response.StatusCode,string.Empty);
                }
            }
        }
        public void SetToken(string value)
        {
            client.DefaultRequestHeaders.Remove("Authorization");
            client.DefaultRequestHeaders.Add("Authorization", $"bearer {value}");
        }
        public async Task<TResult> GetAsync<TResult>(string url)
        {
            var response = await client.GetAsync(url);
            await CheckStatusCodeAsync(response);
            return await response.Content.ReadFromJsonAsync<TResult>();
        }
        public async Task DeleteAsync(string url)
        {
            var response = await client.DeleteAsync(url);
            await CheckStatusCodeAsync(response);
        }
        public async Task<TResult> PutAsync<TInput,TResult>(string url,TInput input)
        {
            var response = await client.PutAsJsonAsync(url, input);
            await CheckStatusCodeAsync(response);
            return await response.Content.ReadFromJsonAsync<TResult>();
        }
        public async Task<TResult> PutAsync<TResult>(string url)
        { 
            var response = await client.PutAsync(url,null);
            await CheckStatusCodeAsync(response);
            return await response.Content.ReadFromJsonAsync<TResult>();
        }
        public async Task PutAsync<TInput>(string url, TInput input)
        {
            var response = await client.PutAsJsonAsync(url, input);
            await CheckStatusCodeAsync(response);
        }
        public async Task<TResult> PostAsync<TInput, TResult>(string url, TInput input)
        {
            var response = await client.PostAsJsonAsync(url, input);
            await CheckStatusCodeAsync(response);
            return await response.Content.ReadFromJsonAsync<TResult>();
        }
        public async Task<TResult> PostAsync<TResult>(string url)
        {
            var response = await client.PostAsync(url, null);
            await CheckStatusCodeAsync(response);
            return await response.Content.ReadFromJsonAsync<TResult>();
        }
        public async Task PostAsync<TInput>(string url, TInput input)
        {
            var response = await client.PostAsJsonAsync(url, input);
            await CheckStatusCodeAsync(response);
        }
    }
}
