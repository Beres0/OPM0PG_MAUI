using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OPM0PG_MAUI.Proxy;
using OPM0PG_MAUI.ViewModels;

namespace OPM0PG_MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.AddSingleton<RestClient>();
            builder.Services.AddSingleton<ValidationService>();
            builder.Services.AddSingleton<AuthenticationService>();
            builder.Services.AddSingleton<ExchangeRatesService>();

            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<RegistrationViewModel>();
            builder.Services.AddSingleton<ExchangeRatesViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<RegistrationPage>();
            builder.Services.AddSingleton<CurrentExchangeRatesPage>();
            builder.Services.AddSingleton<SavedExchangeRatesPage>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}