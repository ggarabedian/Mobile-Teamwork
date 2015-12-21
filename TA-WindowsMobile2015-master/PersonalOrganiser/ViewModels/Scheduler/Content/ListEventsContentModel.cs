namespace PersonalOrganiser.ViewModels.Scheduler.Content
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using Contracts;
    using Extensions;
    using Helpers;
    using Data;
    using Windows.UI.Xaml.Controls;
    using Models;

    public class ListEventsContentModel : IContentViewModel
    {
        public ObservableCollection<SingleEventVIewModel> events;
        private ICommand deleteCommand;

        public IEnumerable<SingleEventVIewModel> Events
        {
            get
            {
                if (this.events == null)
                {
                    this.events = new ObservableCollection<SingleEventVIewModel>();
                }

                return this.events;
            }
            set
            {
                if (this.events == null)
                {
                    this.events = new ObservableCollection<SingleEventVIewModel>();
                }

                this.events.Clear();
                value.ForEach(this.events.Add);
            }
        }

        public ICommand Delete
        {
            get
            {
                if (this.deleteCommand == null)
                {
                    this.deleteCommand = new DelegateCommand<SingleEventVIewModel>(async (eventRequired) =>
                    {

                        var decisionTaker = new ContentDialog();
                        decisionTaker.Title = "Are you sure?";
                        decisionTaker.Content = "This event will be deleted and there is no way back, so are you sure?";

                        decisionTaker.PrimaryButtonText = "Yes, do it";
                        decisionTaker.SecondaryButtonText = "No, go back";

                        var result = await decisionTaker.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            var connection = DbInstance.Get();
                            await connection.ExecuteAsync("DELETE FROM Events WHERE Id = ?", eventRequired.DbId);
                            this.events.Remove(eventRequired);
                        }
                    });
                }
                return this.deleteCommand;
            }
        }

        public IEnumerable<TaskModel> Tasks
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
    }
}
