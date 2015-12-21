namespace PersonalOrganiser.ViewModels.Tasker
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    using Contracts;
    using Data;
    using Extensions;
    using Helpers;
    using Models;
    using Mvvm;

    public class ContentViewModel : ViewModelBase, IContentViewModel
    {
        private ObservableCollection<TaskModel> tasks;

        private ICommand saveCommand;
        private ICommand deleteCommand;

        public ContentViewModel()
        {
            this.tasks = new ObservableCollection<TaskModel>();
        }

        public IEnumerable<TaskModel> Tasks
        {
            get
            {
                if (this.tasks == null)
                {
                    this.tasks = new ObservableCollection<TaskModel>();
                }

                return this.tasks.OrderBy(t => t.TaskImportance.ImportanceFactor);
            }
            set
            {
                if (this.tasks == null)
                {
                    this.tasks = new ObservableCollection<TaskModel>();
                }

                this.tasks.Clear();
                value.ForEach(this.tasks.Add);
            }
        }

        public ICommand Save
        {
            get
            {
                if (this.saveCommand == null)
                {
                    saveCommand = new DelegateCommand<TaskModel>(async (newTask) =>
                    {
                        var candidate = new TaskDataModel()
                        {
                            Date = newTask.TaskDateTime,
                            Title = newTask.Title,
                            TaskImportanceId = newTask.TaskImportance.Id,
                            IsDone = newTask.IsDone,
                            ImageUrl = newTask.ImageUrl
                        };

                        var connection = DbInstance.Get();

                        var result = await connection.InsertAsync(candidate);
                    });
                }

                return this.saveCommand;
            }
        }

        public ICommand Delete
        {
            get
            {
                if (this.deleteCommand == null)
                {
                    this.deleteCommand = new DelegateCommand<TaskModel>(async (taskToDelete) =>
                    {
                        var candidate = new TaskDataModel()
                        {
                            Id = taskToDelete.Id,
                            Date = taskToDelete.TaskDateTime,
                            Title = taskToDelete.Title,
                            TaskImportanceId = taskToDelete.TaskImportance.Id,
                            IsDone = taskToDelete.IsDone,
                            ImageUrl = taskToDelete.ImageUrl
                        };

                        if (candidate != null)
                        {
                            var connection = DbInstance.Get();

                            var result = await connection.DeleteAsync(candidate);
                        }
                    });
                }

                return this.deleteCommand;
            }
        }
    }
}
