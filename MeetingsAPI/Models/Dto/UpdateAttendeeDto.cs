using MeetingsAPI.Models.Domain;

namespace MeetingsAPI.Models.Dto
{
    public class UpdateAttendeeDto
    {
        public string ApplicationUserId { get; set; }

        //public string Email { get; set; }

        public int MeetingId { get; set; }
    }
}
