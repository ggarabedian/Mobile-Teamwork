namespace PersonalOrganiser.Views.Scheduler
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Windows.UI.Xaml.Controls;
    using PersonalOrganiser.ViewModels.Scheduler;
    using ViewModels.Scheduler.Content;
    using Windows.UI.Xaml.Navigation;
    using Data;
    using System.Threading.Tasks;    /// <summary>
                                     /// An empty page that can be used on its own or navigated to within a Frame.
                                     /// </summary>
                                     /// 
    public sealed partial class ListEvents : Page
    {
        private DateTimeOffset date;

        private void GoBackHandler(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.InitializeComponent();
            var contentViewModel = new ListEventsContentModel();

            DateTimeOffset? selectedDate = e.Parameter as DateTimeOffset?;
            if (selectedDate == null)
            {
                return;
            }
            this.date = (DateTimeOffset)selectedDate;

            List<SingleEventVIewModel> toAdd = new List<SingleEventVIewModel>();

            var fromDb = await this.GetEventsFromDb(date);

            foreach (var item in fromDb)
            {
                toAdd.Add(new SingleEventVIewModel(item.Title, item.Type.ToString(), item.Id));
            }

            contentViewModel.Events = toAdd;

            this.DataContext = new ListEventsViewModel(contentViewModel, date);
        }

        private async Task<List<ScheduledEventModel>> GetEventsFromDb(DateTimeOffset date)
        {
            var contentViewModel = new ListEventsContentModel();

            var eventsAsList = await DbInstance
                .Get()
                .Table<ScheduledEventModel>()
                .Where(e => e.Date == date)
                .ToListAsync();

            return eventsAsList;
        }
    }
}
