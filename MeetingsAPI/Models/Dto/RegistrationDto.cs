using MeetingsAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeetingsAPI.Models.Dto;

public class RegistrationDto
{
    //[Required]
    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //int Id { get; set; }
    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    // For simplicity we are adding roles as part of request DTO
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    //[JsonIgnore]
    //public ICollection<Attendee>? Attendees { get; set; }

}