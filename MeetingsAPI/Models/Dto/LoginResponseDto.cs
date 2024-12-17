namespace MeetingsAPI.Models.Dto
{
    public class LoginResponseDto
    {
        public string AuthToken { get; set; }
        public string? Email { get; set; }
        public string? Message {  get; set; }
        public string? Name { get; set; }
        //public string Role { get; set; }
    }
}
