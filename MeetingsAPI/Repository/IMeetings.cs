using MeetingsAPI.Models.Domain;
using MeetingsAPI.Models.Dto;

namespace MeetingsAPI.Repository
{
    public interface IMeetings
    {

        Task<string> getEmails(string userId);
        Task<List<Models.Domain.Meetings>> GetAllAsync();
        Task<List<Meetings>> GetAllMeeting(string email,string? period, string? search);
        Task<Models.Domain.Meetings> GetByIdAsync(int id);
        Task<Models.Domain.Meetings> CreateAsync(string email,Models.Domain.Meetings Meeting);

        Task<List<ApplicationUser>> getMeetingIds(int id);

        Task<List<Meetings>> GetAllMeetingCalendar(string email,DateOnly calendarId);

        Task<Models.Domain.Meetings?> UpdateAsync(int id, string userId, string addedUser);
        Task<Models.Domain.Meetings?> DeleteAsync(int id, string userId);
        Task<string> getUserId(string email);
    }
}
