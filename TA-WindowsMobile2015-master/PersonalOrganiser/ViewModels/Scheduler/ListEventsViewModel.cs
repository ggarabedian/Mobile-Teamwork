namespace PersonalOrganiser.ViewModels.Scheduler
{
    using System;
    using Windows.UI.Xaml.Controls;

    using Contracts;

    public class ListEventsViewModel : ViewModelBase, IPageViewModel
    {
        private Frame frame;
        private string title;

        public IContentViewModel ContentViewModel { get; set; }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                this.title = value;
            }
        }

        public ListEventsViewModel(IContentViewModel contentViewModel, DateTimeOffset date)
        {
            this.ContentViewModel = contentViewModel;
            this.Title = string.Format("{0}/{1}/{2}", date.Day, date.Month, date.Year);
        }
    }
}