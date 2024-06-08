using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OPM0PG_MAUI.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSH_HomeAssignment.Api.Contracts.Authentication.Inputs;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs;

namespace OPM0PG_MAUI.ViewModels
{
    public partial class LoginViewModel:ObservableObject
    {
        public event EventHandler<Exception> OnError;
        private readonly AuthenticationService authenticationService;
        
        private ObservableLoginDto loginDto;
        public ObservableLoginDto LoginDto
        {
            get => loginDto;
            set => SetProperty(ref loginDto, value);
        }
        public IAsyncRelayCommand LoginCommand => new AsyncRelayCommand(LoginAsync, () => loginDto.HasErrors);
        public LoginViewModel(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
            LoginDto = new ObservableLoginDto();
        }
        private async Task LoginAsync()
        {
            try
            {
                await authenticationService.LoginAsync(new LoginDto() 
                {
                    UserName=LoginDto.UserName,
                    Password=LoginDto.Password
                });
                Shell.Current.AsAppShell().AuthenticatedNavigationMode();
                await Shell.Current.GoToAsync("//Current");
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, ex);
            }
        }

    }
}
