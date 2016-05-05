using Hiking.Models;
using Hiking.Repositories;
using Hiking.ViewModels.Profile;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hiking.Services
{
    public class Profile : IProfile
    {
        IGenericRepository _repo;
        UserManager<ApplicationUser> userManager;

        public Profile(IGenericRepository repo, UserManager<ApplicationUser> _userManager)
        {
            this._repo = repo;
            this.userManager = _userManager;
        }
        public List<AdminViewModel> GetProfiles()
        {
            var profiles = _repo.Query<ApplicationUser>().Include(u => u.Claims).Select(u => new AdminViewModel {
                FirstName = u.FirstName,
                LastName = u.LastName,
                IsAdmin = u.Claims.Any(c => c.ClaimType == "isAdmin"),
                UserName = u.UserName
            }).ToList();
            return profiles;
        }
    }
}
