using Microsoft.Maui.Dispatching;
using OPM0PG_MAUI.Models;
using OPM0PG_MAUI.ViewModels;

namespace OPM0PG_MAUI;

public partial class CurrentExchangeRatesPage : ContentPage
{
    private readonly ExchangeRatesViewModel viewModel;

    public CurrentExchangeRatesPage()
    {
        InitializeComponent();
    }
    public CurrentExchangeRatesPage(ExchangeRatesViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        this.BindingContext = viewModel;
    }
    protected override void OnAppearing()
    {
        Dispatcher.DispatchAsync(viewModel.LoadAsync);
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var dto = (sender as CheckBox).BindingContext as ObservableDailyExchangeRateDto;
        if(dto is not null)
        {
            if (e.Value)
            {
                Dispatcher.DispatchAsync(() => viewModel.SaveAsync(dto));
            }
            else
            {
                Dispatcher.DispatchAsync(() => viewModel.DeleteAsync(dto));
            }
        }
    }
}