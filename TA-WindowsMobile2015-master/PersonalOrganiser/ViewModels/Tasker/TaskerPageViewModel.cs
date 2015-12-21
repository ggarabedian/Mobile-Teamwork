namespace PersonalOrganiser.ViewModels.Tasker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Mvvm;
    using Models;

    public class TaskerPageViewModel : ViewModelBase
    {
        public MainPageAllTasksViewModel MainPageAllTasksViewModel { get; set; } = new MainPageAllTasksViewModel();
        public MainPageTodayTasksViewModel MainPageTodayTasksViewModel { get; set; } = new MainPageTodayTasksViewModel();
        public MainPageTomorrowTasksViewModel MainPageTomorrowTasksViewModel { get; set; } = new MainPageTomorrowTasksViewModel();

        public void GotoAddNewTaskPage()
        {
            NavigationService.Navigate(typeof(Views.Tasker.AddNewTaskPage));
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

    public class MainPageAllTasksViewModel : ViewModelBase
    {
        public IEnumerable<TaskModel> Tasks
        {
            get
            {
                return TaskerDataRequester.GetAllTasksAsync().Result
                    .OrderBy(t => t.TaskImportance.ImportanceFactor);
            }
        }
    }

    public class MainPageTodayTasksViewModel : ViewModelBase
    {
        public IEnumerable<TaskModel> Tasks
        {
            get
            {
                var tempViewModel = TaskerDataRequester.GetAllTasksAsync().Result
                    .Where(t => t.TaskDateTime.DayOfYear == DateTime.Now.DayOfYear)
                    .OrderBy(t => t.TaskImportance.ImportanceFactor)
                    .ToList();
                return tempViewModel;
            }
        }
    }

    public class MainPageTomorrowTasksViewModel : ViewModelBase
    {
        public IEnumerable<TaskModel> Tasks
        {
            get
            {
                var tempViewModel = TaskerDataRequester.GetAllTasksAsync().Result
                    .Where(t => t.TaskDateTime.DayOfYear == DateTime.Now.DayOfYear + 1)
                    .OrderBy(t => t.TaskImportance.ImportanceFactor)
                    .ToList();
                return tempViewModel;
            }
        }
    }
}
