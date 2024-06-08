using OPM0PG_MAUI.Models;
using OPM0PG_MAUI.ViewModels;

namespace OPM0PG_MAUI;

public partial class SavedExchangeRatesPage : ContentPage
{
    private readonly SavedExchangeRateViewModel viewModel;

    public SavedExchangeRatesPage(SavedExchangeRateViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        this.BindingContext = viewModel;
    }
    protected override void OnAppearing()
    {
        Dispatcher.DispatchAsync(viewModel.RefreshAsync);
    }

    private void UpdateButton_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        var item=btn.BindingContext as ObservableDailyExchangeRateDto;
        Dispatcher.DispatchAsync(()=>viewModel.UpdateAsync(item));
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        var item = btn.BindingContext as ObservableDailyExchangeRateDto;
        Dispatcher.DispatchAsync(() => viewModel.DeleteAsync(item));
    }
}