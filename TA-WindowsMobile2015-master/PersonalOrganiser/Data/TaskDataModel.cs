namespace PersonalOrganiser.Data
{
    using System;
    using SQLite.Net.Attributes;

    [Table("Tasks")]
    public class TaskDataModel
    {
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }

        [NotNull]
        public DateTime Date { get; set; }

        [NotNull]
        [MaxLength(50)]
        public string Title { get; set; }

        [NotNull]
        public int TaskImportanceId { get; set; }

        public bool IsDone { get; set; }

        public string ImageUrl { get; set; }
    }
}
