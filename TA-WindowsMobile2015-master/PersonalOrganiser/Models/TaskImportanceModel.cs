namespace PersonalOrganiser.Models
{
    public class TaskImportanceModel
    {
        public TaskImportanceModel(int id, string importance, string color, int importanceFactor)
        {
            this.Id = id;
            this.Importance = importance;
            this.Color = color;
            this.ImportanceFactor = importanceFactor;
        }

        public int Id { get; set; }

        public string Importance { get; set; }

        public string Color { get; set; }

        public int ImportanceFactor { get; set; }
    }
}
