namespace PersonalOrganiser.Models
{
    using System;

    public class EventModel
    {
        public string Title { get; set; }

        public string Information { get; set; }

        public DateTimeOffset Date { get; set; }

        public EventType Type { get; set; }
    }
}
