namespace PersonalOrganiser.ViewModels.Tasker
{
    using Contracts;
    using Mvvm;

    public class AddNewTaskPageViewModel : ViewModelBase
    {
        IContentViewModel contentViewModel;
        public IContentViewModel ContentViewModel
        {
            get
            {
                return contentViewModel;
            }
            set
            {
                Set(ref contentViewModel, value);
            }
        }

        public AddNewTaskPageViewModel()
        {
            this.contentViewModel = App.ContentViewModel;
        }

        public string Title
        {
            get
            {
                return "Add Task";
            }
        }

        public void AddNewTask()
        {
            NavigationService.Navigate(typeof(Views.TaskerPage));
        }

        public void GotoPrivacy()
        {
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);
        }

        public void GotoAbout()
        {
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
        }
    }
}
