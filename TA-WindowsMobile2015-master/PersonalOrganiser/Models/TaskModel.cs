namespace PersonalOrganiser.Models
{
    using System;
    using System.Collections.ObjectModel;

    using Windows.UI.Xaml.Media.Imaging;

    using Mvvm;

    public class TaskModel : ViewModelBase
    {
        private int id;
        private string title;
        private bool isDone;
        private DateTime taskDateTime;
        private TaskImportanceModel taskImportance;
        private string imageUrl;

        public TaskModel()
            : this(string.Empty, DateTime.Now, null, null)
        {
        }

        public TaskModel(string title, DateTime taskDateTime, TaskImportanceModel taskImportance, string imageUrl)
        {
            this.Title = title;
            this.TaskDateTime = taskDateTime;
            this.TaskImportance = taskImportance;
            this.IsDone = false;
            this.ImageUrl = imageUrl;
        }

        public TaskModel(TaskModel newTask)
            : this(newTask.Title, newTask.TaskDateTime, newTask.taskImportance, newTask.imageUrl)
        {
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                Set(ref id, value);
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                Set(ref title, value);
            }
        }

        public string ImageUrl
        {
            get
            {
                return this.imageUrl;
            }
            set
            {
                Set(ref imageUrl, value, "ImageUrl");
            }
        }

        public TaskImportanceModel TaskImportance
        {
            get
            {
                return this.taskImportance;
            }
            set
            {
                if (value == null)
                {
                    value = importances[0];
                }
                Set(ref taskImportance, value);
            }
        }

        public bool IsDone
        {
            get
            {
                return this.isDone;
            }
            set
            {

                Set(ref isDone, value);
            }
        }

        public DateTime TaskDateTime
        {
            get
            {
                return this.taskDateTime;
            }
            set
            {
                Set(ref taskDateTime, value);
            }
        }

        public TimeSpan TaskDateTimeTimeSpanProxy
        {
            get
            {
                return taskDateTime - taskDateTime.Date;
            }
            set
            {
                if (TaskDateTimeTimeSpanProxy != value)
                {
                    TaskDateTime = taskDateTime.Date.Add(value);
                    RaisePropertyChanged("TaskDateTimeTimeSpanProxy");
                }
            }
        }

        public BitmapImage Image { get; set; }

        public ObservableCollection<TaskImportanceModel> Importances
        {
            get
            {
                return this.importances;
            }
        }

        public ObservableCollection<TaskImportanceModel> importances = new ObservableCollection<TaskImportanceModel>()
        {
            new TaskImportanceModel(1, "Trivial", "DodgerBlue", 5),
            new TaskImportanceModel(2, "Can Wait", "GreenYellow", 4),
            new TaskImportanceModel(3, "Soon", "Gold", 3),
            new TaskImportanceModel(4, "Important", "OrangeRed", 2),
            new TaskImportanceModel(5, "Urgent", "Red", 1)
        };
    }
}