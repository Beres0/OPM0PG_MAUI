using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using WSH_HomeAssignment.Api.Contracts.Authentication.Inputs;
using WSH_HomeAssignment.Api.Contracts.Authentication.Outputs;
using WSH_HomeAssignment.Domain.Contracts;

namespace OPM0PG_MAUI.Proxy
{

    public partial class AuthenticationService:ObservableObject
    {
        public const string Address =$"api/auth/";
        private readonly RestClient client;
        private readonly ValidationService validationService;

        [ObservableProperty]
        private TokenDto currentToken;


        public AuthenticationService(RestClient client,ValidationService validationService)
        {
            this.client = client;
            this.validationService = validationService;
        }
        private void SetToken(TokenDto tokenDto)
        {
            if(tokenDto is not null)
            {
                client.SetToken(tokenDto.Value);
                CurrentToken = tokenDto;
                Shell.Current.AsAppShell().IsAuthenticated = true;
            }
            else
            {
                client.SetToken(null);
                CurrentToken = null;
                Shell.Current.AsAppShell().IsAuthenticated = false;
            }

        }
        public async Task LoginAsync(LoginDto input)
        {
            var response = await client.PostAsync<LoginDto, TokenDto>
                (Address + "login", input);
            SetToken(response);
        }
        public async Task RegisterAsync(RegistrationDto input)
        {
            var response = await client.PostAsync<RegistrationDto, TokenDto>
                (Address + "register", input);
            SetToken(response);

        }
        public async Task RefreshAsync()
        {
            var response = await client.PostAsync<TokenDto>(Address + "refresh-token");
            SetToken(response);
        }
        public void Logout()
        {
            SetToken(null);
        }
    }
}
