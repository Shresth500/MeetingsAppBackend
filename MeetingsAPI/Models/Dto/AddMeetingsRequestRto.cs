using MeetingsAPI.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeetingsAPI.Models.Dto
{
    public class AddMeetingRequestRto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly startTime { get; set; }
        public TimeOnly endTime { get; set; }

        public List<IAddMeetingRequestAttendee>? Attendees { get; set; }
    }

    public class IAddMeetingRequestAttendee
    {
        public string ApplicationUserId { get; set; }
        public string? Email { get; set; }
    }

    public class AddMeetingRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly startTime { get; set; }
        public TimeOnly endTime { get; set; }

        public List<IAddMeetingAttendee>? Attendees { get; set; }
    }
    public class IAddMeetingAttendee
    {
        public string? Email { get; set; }
    }
}
