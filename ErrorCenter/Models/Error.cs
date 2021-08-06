using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ErrorCenter.Models
{
    public class Error
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EventsCount { get; set; }
        public string Level { get; set; }
        public virtual User User { get; set; }

        public Error()
        {
        }

        public Error(string title, string description, int eventsCount, string level, User user)
        {
            //Id = id;
            Title = title;
            Description = description;
            EventsCount = eventsCount;
            Level = level;
            User = user;
        }
    }
}
