namespace EventScheduler.Dialogs
{
    using System;

    using Windows.UI.Xaml.Controls;

    class ActionSelectDialog : ContentDialog
    {
        private DateTimeOffset selectedDate;

        public ActionSelectDialog(string title, string content, double maxWidth, DateTimeOffset selectedDate) : this()
        {
            this.Title = title;
            this.Content = content;
            this.MaxWidth = maxWidth;
            this.selectedDate = selectedDate;
        }

        public ActionSelectDialog()
        {

        }

        public DateTimeOffset SelectedDate
        {
            get
            {
                return this.selectedDate;
            }
        }
    }
}
