using AutoMapper;
using MeetingsAPI.Data;
using MeetingsAPI.Models.Domain;
using MeetingsAPI.Models.Dto;
using MeetingsAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Security.Claims;

namespace MeetingsAPI.Controllers
{
    public class UserQueryParams
    {
        public string? Period { get; set; }
        public string? Search { get; set; }
    }
    public class UpdateQuery
    {
        public int? Id { get; set; }
        public string action { get; set; }
        public string? userId { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController:ControllerBase
    {
        public IMeetings _repo;
        private IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        //public MeetingsController(IMeetings repo, IMapper mapper)
        //{
        //    _repo = repo;
        //    //_mapper = mapper;
        //}
        public MeetingsController(IMeetings repo, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }



        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> GetMeetingsFromDate([FromQuery] UserQueryParams? userQuery)
        {
            var email = User?.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized("Email not found in the claims.");
            }
            var meetingsDomain = await _repo.GetAllMeeting(email,userQuery.Period,userQuery.Search);
            var meetingsDto = _mapper.Map<List<MeetingsRto>>(meetingsDomain);
            List<MeetingsRto> meetingList = [];
            foreach(var meeting in meetingsDto)
            {
                var meetingsAttendee = await _repo.getMeetingIds(meeting.Id);
                List<IAttendee> attendees = [];
                foreach(var temp in meetingsAttendee)
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

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public async Task<IActionResult> CreateMeeting([FromBody] AddMeetingRequestDto meetingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 response (Errors will be there)
            }

            var email = User?.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized("Email not found in the claims.");
            }

            AddMeetingRequestRto meetingRto = new AddMeetingRequestRto();
            meetingRto.Name = meetingDto.Name;
            meetingRto.Description = meetingDto.Description; 
            meetingRto.endTime = meetingDto.endTime;
            meetingRto.startTime = meetingDto.startTime;
            meetingRto.Date = meetingDto.Date;

            foreach(var meet in meetingDto.Attendees)
            {
                var temp = meet.Email;
                var user = await _userManager.FindByEmailAsync(temp);
                if (user != null)
                {
                    meetingRto.Attendees = new List<IAddMeetingRequestAttendee>();
                    var temp2 = new IAddMeetingRequestAttendee
                    {
                        ApplicationUserId = user.Id.ToString(),
                        Email = temp
                    };
                    meetingRto.Attendees.Add(temp2);
                }
            }
            var meetingsDomain = _mapper.Map<Meetings>(meetingRto);
            meetingsDomain = await _repo.CreateAsync(email,meetingsDomain);
            var meetingsDto = _mapper.Map<MeetingsRto>(meetingsDomain);
            foreach (var item in meetingsDto.Attendees)
            {
                item.Email = await _repo.getEmails(item.ApplicationUserId);
                
            }
            return Ok(meetingsDto);
        }

        [HttpPatch]
        [Route("{Id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateAttendee([FromRoute] int Id,[FromQuery] UpdateQuery AddAttendee)
        {
            int meetingId = Id;
            string addedUserId = AddAttendee.userId;
            if(AddAttendee.action != "add_attendee")
            {
                return NotFound();
            }


            var email = User?.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            var userId = user.Id;
            var updateMeet = await _repo.UpdateAsync(meetingId,userId, addedUserId);
            var meetingsDto = _mapper.Map<MeetingsRto>(updateMeet);
            foreach (var item in meetingsDto.Attendees)
            {
                item.Email = await _repo.getEmails(item.ApplicationUserId);

            }

            return Ok(meetingsDto);
        }
        [HttpDelete]
        [Route("{Id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteAttendee([FromRoute] int Id,[FromQuery] UpdateQuery DeleteAttendee)
        {
            var email = User?.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            var userId = user.Id;
            var data = await _repo.DeleteAsync(Id,userId);
            var meetingsDto = _mapper.Map<MeetingsRto>(data);
            foreach (var item in meetingsDto.Attendees)
            {
                item.Email = await _repo.getEmails(item.ApplicationUserId);

            }

            return Ok(meetingsDto);
        }
    }
}
