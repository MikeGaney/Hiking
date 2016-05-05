using System.Collections.Generic;
using Hiking.Models;
using Hiking.ViewModels.Trails;

namespace Hiking.Services
{
    public interface ISATrailsService
    {
        List<Trail> GetTrailsList();
        void AddTrail(Trail trail);
        Trail GetOneTrail(int id);
        void EditTrail(Trail trail);
        void DeleteTrail(int id);
        void AddCommentToTrail(TrailCommentViewModel data);
        List<MapTrailViewModel> GetMapTrails();
        List<MapTrailViewModel> GetSearchMapTrails(string area);
        CheckBackpackViewModel CheckBackpack(string id, int trailId); 
    }
}