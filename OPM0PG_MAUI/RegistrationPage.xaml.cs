using OPM0PG_MAUI.ViewModels;

namespace OPM0PG_MAUI;

public partial class RegistrationPage : ContentPage
{
    private readonly RegistrationViewModel viewModel;
    public RegistrationPage(RegistrationViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
        this.viewModel = viewModel;
    }
    protected override void OnAppearing()
    {
        viewModel.RegistrationDto = new Proxy.ObservableRegistrationDto();
        viewModel.OnError += ViewModel_OnError;
    }
    protected override void OnDisappearing()
    {
        viewModel.OnError -= ViewModel_OnError;
    }
    private void ViewModel_OnError(object sender, Exception e)
    {
        DisplayAlert("Error", e.Message, "Ok");
    }
}