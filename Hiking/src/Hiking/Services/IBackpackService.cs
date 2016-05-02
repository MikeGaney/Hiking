using System.Collections.Generic;
using Hiking.Models;
using Hiking.ViewModels.Profile;

namespace Hiking.Services
{
    public interface IBackpackService
    {
        void CompletedTrail(UserTrail data);
        BackpackTrailViewModel GetTrail(int id);
        List<Trail> GetTrailList(string id);
        void RemoveTrail(UserTrail data);
        void AddToBackpack(UserTrail data);
        List<CompletedTrail> GetCompletedTrails(string id);
        void SaveCompletedTrail(UserTrail id);
        //List<Trail> GetShortTrailList(string id);
        List<Trail> BkPkPagination(int num, string id);
    }
}