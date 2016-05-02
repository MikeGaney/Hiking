using Hiking.Models;
using Hiking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Services
{
    public class Profile : IProfile
    {
        IGenericRepository _repo;

        public Profile(IGenericRepository repo)
        {
            this._repo = repo;
        }
        public List<ApplicationUser> GetProfiles()
        {
            var profiles = _repo.Query<ApplicationUser>().Include(u => u.Claims).ToList();
            return profiles;
        }
    }
}
