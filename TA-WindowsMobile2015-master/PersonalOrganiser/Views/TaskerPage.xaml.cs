namespace PersonalOrganiser.Views
{
    using System.Linq;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;

    using Data;
    using Models;
    using ViewModels.Tasker;
    using Views.Tasker;

    public sealed partial class TaskerPage : Page
    {
        public TaskerPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        public TaskerPageViewModel ViewModel => this.DataContext as TaskerPageViewModel;

        private void GotoTaskDetails(object sender, TappedRoutedEventArgs e)
        {
            var task = (sender as Grid).Tag as TaskModel;
            Frame.Navigate(typeof(TaskDetailsPage), task.Id);
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            var taskToDelete = (sender as Button).Parent;
        }

        private void OnIsDoneChanged(object sender, TappedRoutedEventArgs e)
        {
            var id = (sender as CheckBox).Tag as int?;

            var finishedTask = TaskerDataRequester.GetAllTasksAsync().Result.Where(t => t.Id == id).FirstOrDefault();

            if (finishedTask != null)
            {
                finishedTask.IsDone = !finishedTask.IsDone;

                TaskerDataRequester.UpdateTask(finishedTask);
            }
            else
            {
                return;
            }
        }
    }
}
