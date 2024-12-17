using Microsoft.AspNetCore.Identity;

namespace MeetingsAPI.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Attendee>? Attendees { get; set; }
    }
}
