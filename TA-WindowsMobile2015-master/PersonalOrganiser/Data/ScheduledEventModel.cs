namespace PersonalOrganiser.Data
{
    using System;
    using SQLite.Net.Attributes;
    using Models;

    [Table("Events")]
    public class ScheduledEventModel
    {
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }

        [NotNull]
        public DateTimeOffset Date { get; set; }

        [NotNull]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Information { get; set; }

        [NotNull]
        public EventType Type { get; set; }
    }
}
