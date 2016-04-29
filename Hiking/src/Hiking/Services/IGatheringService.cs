using System.Collections.Generic;
using Hiking.Models;
using Hiking.ViewModels.Gatherings;

namespace Hiking.Services
{
    public interface IGatheringService
    {
        void DeleteGathering(int id);
        List<Gathering> GetAllGatherings();
        GatheringViewModel GetOneGathering(int id);
        void AddGathering(AddGatheringViewModel data);
        void UpdateGathering(AddGatheringViewModel data);

        void AddToGathering(AddUserToGatherViewModel data);
        UserInGatheringViewModel IsUserInGathering(AddUserToGatherViewModel data);
        void RemoveFromGathering(AddUserToGatherViewModel data);
    }
}