using MeetingsAPI.Data;
using MeetingsAPI.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using MeetingsAPI.Repository;
using Microsoft.EntityFrameworkCore;
using MeetingsAPI.Models.Dto;

namespace MeetingsAPI.Repository
{
    public class SqlWorkshopRepository : IMeetings
    {
        private ApplicationDbContext _db;

        public SqlWorkshopRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<string> getEmails(string userId)
        {
            var data = await _db.Users.Where(a => a.Id == userId).FirstOrDefaultAsync();
            return data.Email;
        }

        public async Task<string> getUserId(string email)
        {
            var data = await _db.Users.Where(a => a.Email == email).FirstOrDefaultAsync();
            return data.Id;
        }

        async Task<Meetings> IMeetings.CreateAsync(string email,Meetings Meeting)
        {
            var data = _db.Users.Where(a => a.Email == email).FirstOrDefault();
            Meeting.Attendees.Add(new Attendee { ApplicationUserId = data.Id });
            await _db.Meetings.AddAsync(Meeting);
            await _db.SaveChangesAsync();
            return Meeting;
        }

        public async Task<Meetings?> DeleteAsync(int id,string userId)
        {
            var query = await _db.Attendee.Where(x => x.ApplicationUserId == userId).Where(a => a.MeetingId == id).FirstOrDefaultAsync();
            //if(query == null)
            //    throw new Invalid;
            _db.Attendee.RemoveRange(query);
            await _db.SaveChangesAsync();
            var data = await _db.Meetings.Where(x => x.Id == id).ToListAsync();
            return data[0];
        }

        Task<List<Meetings>> IMeetings.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        async Task<List<Meetings>> IMeetings.GetAllMeeting(string email,string? period, string? search)
        {
            //var query = _db.Meetings.Include(u => u.Attendees).FirstOrDefault(u => u.ema == ).AsQueryable();
            var data = _db.Users.Where(a => a.Email == email).FirstOrDefault();
            var query = _db.Attendee.Where(a => a.ApplicationUserId == data.Id).Select(m => m.Meeting).AsQueryable();
            var currentDate = DateOnly.FromDateTime(DateTime.Now);
            if (!string.IsNullOrEmpty(period))
            {

                if(period.Equals("past", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(x => x.Date < currentDate);
                }
                else if(period.Equals("present", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(x => x.Date == currentDate);
                }
                else if (period.Equals("future", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(x => x.Date > currentDate);
                }
            }
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }
            var meetings = await query.ToListAsync();
            
            return meetings;
        }

        public async Task<List<Meetings>> GetAllMeetingCalendar(string email,DateOnly calendarId)
        {

            var data = _db.Users.Where(a => a.Email == email).FirstOrDefault();
            var query = _db.Attendee.Where(a => a.ApplicationUserId == data.Id).Select(m => m.Meeting).AsQueryable();
            query = query.Where(x => x.Date == calendarId);
            var meetings = await query.ToListAsync();

            return meetings;
        }

        public async Task<List<ApplicationUser>> getMeetingIds(int id)
        {
            var getData = _db.Attendee
                .Where(a => a.MeetingId == id)
                .Select(d => d.ApplicationUser)
                .AsQueryable();
            var data = await getData.ToListAsync();
            return data;
        }

        Task<Meetings> IMeetings.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Meetings?> UpdateAsync(int id, string userId,string addedUser)
        {
            var query = await _db.Meetings.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (query.Attendees == null)
            {
                query.Attendees = new List<Attendee>(); // Initialize the list if it's null
            }
            var meetings =  await _db.Meetings.Where(t => t.Id == id).Where(m => m.Attendees.Any(a => a.ApplicationUserId == userId)).FirstOrDefaultAsync();
            meetings.Attendees.Add(new Attendee
            {
                ApplicationUserId = addedUser,
            });

            await _db.SaveChangesAsync();
            var data = await _db.Meetings.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }
    }
}
