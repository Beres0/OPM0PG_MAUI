using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OPM0PG_MAUI.Proxy;
using WSH_HomeAssignment.Api.Contracts.Authentication.Inputs;

namespace OPM0PG_MAUI.ViewModels
{
    public partial class RegistrationViewModel : ObservableObject
    {
        public event EventHandler<Exception> OnError;
        private readonly AuthenticationService authenticationService;
        public ObservableRegistrationDto RegistrationDto { get; }
        public RegistrationViewModel(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
            RegistrationDto = new ObservableRegistrationDto();
        }

        [RelayCommand]
        private async Task RegisterAsync()
        {
            try
            {
                await authenticationService.RegisterAsync(new RegistrationDto()
                {
                    UserName=RegistrationDto.UserName,
                    Password=RegistrationDto.Password,
                    Email=RegistrationDto.Email
                });
                await Shell.Current.GoToAsync("//Current");
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, ex);
            }
        }
    }
}
