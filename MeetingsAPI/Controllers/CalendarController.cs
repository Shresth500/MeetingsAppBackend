using AutoMapper;
using MeetingsAPI.Data;
using MeetingsAPI.Models.Domain;
using MeetingsAPI.Models.Dto;
using MeetingsAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Security.Claims;

namespace MeetingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController:ControllerBase
    {
        public IMeetings _repo;
        private IMapper _mapper;
        public CalendarController(IMeetings repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> GetMeetingsFromDate([FromQuery] DateOnly meetingDate)
        {
            var email = User?.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized("Email not found in the claims.");
            }
            var meetingsDomain = await _repo.GetAllMeetingCalendar(email, meetingDate);
            var meetingsDto = _mapper.Map<List<MeetingsRto>>(meetingsDomain);
            List<MeetingsRto> meetingList = [];
            foreach (var meeting in meetingsDto)
            {
                var meetingsAttendee = await _repo.getMeetingIds(meeting.Id);
                List<IAttendee> attendees = [];
                foreach (var temp in meetingsAttendee)
                {
                    attendees.Add(new IAttendee
                    {
                        ApplicationUserId = temp.Id,
                        Email = temp.Email,
                    });
                }
                Console.WriteLine(attendees);
                meeting.Attendees = attendees;
                meetingList.Add(new MeetingsRto
                {
                    Id = meeting.Id,
                    Name = meeting.Name,
                    startTime = meeting.startTime,
                    endTime = meeting.endTime,
                    Date = meeting.Date,
                    Description = meeting.Description,
                    Attendees = attendees
                });
            }
            return Ok(meetingList);
        }
    }
}
