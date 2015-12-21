namespace PersonalOrganiser.ViewModels.Scheduler
{
    public class SingleEventVIewModel : ViewModelBase
    {
        public string Title { get; set; }

        public string Type { get; set; }

        public int DbId { get; set; }

        public SingleEventVIewModel(string title, string type, int id)
        {
            this.Title = title;
            this.Type = type;
            this.DbId = id;
        }
    }
}