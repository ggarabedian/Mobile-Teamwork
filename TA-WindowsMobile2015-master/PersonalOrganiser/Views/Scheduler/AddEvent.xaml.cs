namespace PersonalOrganiser.Views.Scheduler
{
    using System;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    using Data;
    using Models;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddEvent : Page
    {
        private DateTimeOffset date;

        public void Initialization()
        {
            this.InitializeComponent();
            this.Type.ItemsSource = Enum.GetValues(typeof(EventType));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Initialization();

            DateTimeOffset? selectedDate = e.Parameter as DateTimeOffset?;
            if (selectedDate == null)
            {
                return;
            }

            this.date = (DateTimeOffset)selectedDate;

            if (this.Type.Items.Count == 0)
            {
                this.Type.ItemsSource = Enum.GetValues(typeof(EventType));
            }
        }

        private async void AddEventHandler(object sender, RoutedEventArgs e)
        {
            var title = this.Title.Text;
            var info = this.Info.Text;
            var type = this.Type.SelectedIndex;

            var candidate = new ScheduledEventModel()
            {
                Date = this.date,
                Type = (EventType)type,
                Title = title,
                Information = info
            };

            var connection = DbInstance.Get();

            var result = await connection.InsertAsync(candidate);
            if (result == 1)
            {
                var modal = new ContentDialog();
                modal.MaxWidth = this.ActualWidth;
                modal.Title = "Everything is set";
                modal.Content = "Your event has been successfully added!";

                modal.PrimaryButtonText = "Ok";
                //modal.PrimaryButtonClick += Modal_PrimaryButtonClick;

                var answer = await modal.ShowAsync();
                if (answer == ContentDialogResult.Primary)
                {
                    this.Frame.GoBack();
                }
            }
        }

        private void GoBackHandler(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}