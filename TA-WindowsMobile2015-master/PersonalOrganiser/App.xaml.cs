namespace PersonalOrganiser
{
    using System;
    using Windows.UI.Xaml;
    using System.Threading.Tasks;
    using PersonalOrganiser.Services.SettingsServices;
    using Windows.ApplicationModel.Activation;
    using PersonalOrganiser.Data;
    using PersonalOrganiser.ViewModels.Tasker;

    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    sealed partial class App : Template10.Common.BootStrapper
    {
        public static ContentViewModel ContentViewModel;
        ISettingsService _settings;

        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Views.Splash(e);

            #region App settings

            _settings = SettingsService.Instance;
            RequestedTheme = _settings.AppTheme;
            CacheMaxDuration = _settings.CacheMaxDuration;
            ShowShellBackButton = _settings.UseShellBackButton;

            #endregion
            if (ContentViewModel == null)
            {
                ContentViewModel = new ContentViewModel();
            }
        }

        // runs even if restored from state
        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            // setup hamburger shell
            var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);
            Window.Current.Content = new Views.Shell(nav);
            await Task.Yield();
        }

        // runs only when not restored from state
        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // perform long-running load
            await Task.Delay(0);
            DbInstance.Get();
            // navigate to first page
            NavigationService.Navigate(typeof(Views.InitializePage));
        }
    }
}

