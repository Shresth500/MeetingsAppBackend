using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeetingsAPI.Models.Domain
{
    public class Meetings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly startTime { get; set; }
        public TimeOnly endTime { get; set; }

        public List<Attendee>? Attendees { get; set; }

    }

}
