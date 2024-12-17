using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingsAPI.Models.Domain
{
    public class Attendee
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        //public string Email { get; set; }

        public int MeetingId { get; set; }
        public Meetings Meeting { get; set; }

    }
}
