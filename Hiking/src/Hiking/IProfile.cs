using System.Collections.Generic;
using Hiking.Models;

namespace Hiking.Services
{
    public interface IProfile
    {
        List<ApplicationUser> GetProfiles();
    }
}