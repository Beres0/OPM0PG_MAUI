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
        private ObservableRegistrationDto registrationDto;
        public ObservableRegistrationDto RegistrationDto
        {
            get => registrationDto;
            set => SetProperty(ref registrationDto, value);
        }

        public IAsyncRelayCommand RegisterCommand => new AsyncRelayCommand(RegisterAsync, () => RegistrationDto.IsValid);

        public RegistrationViewModel(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
            RegistrationDto = new ObservableRegistrationDto();
        }

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
