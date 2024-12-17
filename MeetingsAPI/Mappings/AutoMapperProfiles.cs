using AutoMapper;
using MeetingsAPI.Models.Domain;
using MeetingsAPI.Models.Dto;
using MeetingsAPI.Repository;
namespace MeetingsAPI.Mappings
{

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Meetings, MeetingsRto>();
            CreateMap<MeetingsRto,Meetings>()
                .ForMember(dest => dest.Attendees, opt => opt.MapFrom(src => src.Attendees));

            CreateMap<IAttendee, Attendee>().ReverseMap();
            //.ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.ApplicationUser, opt => opt.Ignore());
            //CreateMap<Meetings, MeetingsRto>().ReverseMap();
            
            CreateMap<AddMeetingRequestRto, Meetings>().ReverseMap();
            CreateMap<IAddMeetingRequestAttendee, Attendee>().ReverseMap();
        }
    }

}
