using MeetingsAPI.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeetingsAPI.Models.Dto
{
    public class MeetingsRto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly startTime { get; set; }
        public TimeOnly endTime { get; set; }

        public List<IAttendee>? Attendees { get; set; }
    }

    public class IAttendee
    {
        public string ApplicationUserId { get; set; }
        public string? Email { get; set; }
        public IAttendee() { }
    }
}
