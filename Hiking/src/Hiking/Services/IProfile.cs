using System.Collections.Generic;
using Hiking.Models;
using Hiking.ViewModels.Profile;

namespace Hiking.Services
{
    public interface IProfile
    {
        List<AdminViewModel> GetProfiles();

        //void adminToPost(string id);

        //void adminToDelete(string id);

    }
}