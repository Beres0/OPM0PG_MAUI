using CommunityToolkit.Mvvm.ComponentModel;
using OPM0PG_MAUI.Proxy;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OPM0PG_MAUI
{
 
    public partial class AppShell : Shell
    {
        private bool isAuthenticated;

        public bool IsAuthenticated
        {
            get => isAuthenticated;
            set
            {
                isAuthenticated = value;
            }
        }
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Login", typeof(MainPage));
            Routing.RegisterRoute("Registration", typeof(RegistrationPage));
            Routing.RegisterRoute("Current", typeof(CurrentExchangeRatesPage));
            Routing.RegisterRoute("Saved", typeof(SavedExchangeRatesPage));
        }
        public void AuthenticatedNavigationMode()
        {
            Items.Clear();
            AddFlyoutItem<CurrentExchangeRatesPage>("Current");
            AddFlyoutItem<SavedExchangeRatesPage>("Saved");
            AddFlyoutItem<Logout>("Logout");
        }
        public void UnAuthenticatedNavigationMode()
        {
            Items.Clear();
            AddFlyoutItem<MainPage>("Login");
            AddFlyoutItem<RegistrationPage>("Registration");
        }
        private void AddFlyoutItem<TPage>(string title)
            where TPage : ContentPage
        {

            var flyoutItem = new FlyoutItem
            {
                Title = title,
                Route = title,
                Items =
                {
                    new ShellContent
                    {
                        Title = title,
                        ContentTemplate = new DataTemplate(typeof(TPage))
                    }
                },
                FlyoutItemIsVisible=true
            };
            Items.Add(flyoutItem);
            
        }

    }

    public static class ShellExtension
    {
        public static AppShell AsAppShell(this Shell shell)
        {
            return shell as AppShell;
        }
    }
}