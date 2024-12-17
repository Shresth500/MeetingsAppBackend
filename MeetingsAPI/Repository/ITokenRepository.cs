using MeetingsAPI.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace MeetingsAPI.Repository
{
    public interface ITokenRepository
    {
        string CreateJWTToken(ApplicationUser user);
    }
}




