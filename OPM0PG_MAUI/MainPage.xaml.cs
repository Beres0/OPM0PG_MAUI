using OPM0PG_MAUI.ViewModels;

namespace OPM0PG_MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly LoginViewModel viewModel;

        public MainPage(LoginViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
            this.viewModel = viewModel;
        }
        protected override void OnAppearing()
        {
            viewModel.LoginDto = new Proxy.ObservableLoginDto();
            viewModel.OnError += ViewModel_OnError;
        }
        protected override void OnDisappearing()
        {
            viewModel.OnError -= ViewModel_OnError;
        }
        private void ViewModel_OnError(object sender, Exception e)
        {
            DisplayAlert("Error", e.Message,"Ok");
        }

    }
}