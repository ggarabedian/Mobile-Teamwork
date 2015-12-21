using PersonalOrganiser.ViewModels;
using Windows.UI.Xaml.Controls;

namespace PersonalOrganiser.Views
{
    public sealed partial class InitializePage : Page
    {
        public InitializePage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public MainPageViewModel ViewModel => this.DataContext as MainPageViewModel;
    }
}
