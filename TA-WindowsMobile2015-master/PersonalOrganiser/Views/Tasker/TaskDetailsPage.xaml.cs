using System;
namespace PersonalOrganiser.Views.Tasker
{
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    using ViewModels.Tasker;

    public sealed partial class TaskDetailsPage : Page
    {
        public TaskDetailsPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }

        public TaskDetailsPageViewModel ViewModel => DataContext as TaskDetailsPageViewModel;
    }
}
