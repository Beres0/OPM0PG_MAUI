using OPM0PG_MAUI.Proxy;

namespace OPM0PG_MAUI;

public partial class Logout : ContentPage
{
    private readonly AuthenticationService service;

    public Logout(AuthenticationService service)
	{
		InitializeComponent();
        this.service = service;
    }
    protected override void OnAppearing()
    {
        service.Logout();
        Shell.Current.AsAppShell().UnAuthenticatedNavigationMode();
        Dispatcher.DispatchAsync(()=>Shell.Current.GoToAsync("//Login"));
    }
}