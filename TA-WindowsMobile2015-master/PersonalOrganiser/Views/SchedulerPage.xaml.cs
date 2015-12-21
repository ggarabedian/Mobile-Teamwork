namespace PersonalOrganiser.Views
{
    using System;
    using System.Linq;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using EventScheduler.Dialogs;
    using Scheduler;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SchedulerPage : Page
    {
        public SchedulerPage()
        {
            this.InitializeComponent();
        }

        private async void OnSelectedDate(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            if (sender.SelectedDates == null)
            {
                return;
            }

            if (sender.SelectedDates.Count == 0)
            {
                return;
            }

            var selectedDate = sender.SelectedDates.First();

            var decisionTaker = new ActionSelectDialog(
                "Select action",
                "Do you want to add event for this date or see existing?",
                this.ActualWidth,
                selectedDate);

            decisionTaker.PrimaryButtonText = "Add new";
            decisionTaker.PrimaryButtonClick += this.AddEvent;

            decisionTaker.SecondaryButtonText = "Check signed";
            decisionTaker.SecondaryButtonClick += this.ViewExistingEvents;

            var result = await decisionTaker.ShowAsync();
        }

        private void AddEvent(ContentDialog dialog, ContentDialogButtonClickEventArgs args)
        {
            var myDialog = dialog as ActionSelectDialog;
            var date = myDialog.SelectedDate;
            this.Frame.Navigate(typeof(AddEvent), date);
        }

        private void ViewExistingEvents(ContentDialog dialog, ContentDialogButtonClickEventArgs args)
        {
            var myDialog = dialog as ActionSelectDialog;
            var date = myDialog.SelectedDate;
            this.Frame.Navigate(typeof(ListEvents), date);
        }

        private void GoBackHandler(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }
    }
}
