using System.Collections.Generic;
using Hiking.Models;
using Hiking.ViewModels.Profile;

namespace Hiking.Services
{
    public interface IBackpackService
    {
        void CompletedTrail(int id);
        BackpackTrailViewModel GetTrail(int id);
        List<Trail> GetTrailList(string id);
        void RemoveTrail(int id);
        void AddToBackpack(UserTrail data);
    }
}