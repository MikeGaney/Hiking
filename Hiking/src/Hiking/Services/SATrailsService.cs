using Hiking.Models;
using Hiking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Services
{
    public class SATrailsService : ISATrailsService
    {
        private IGenericRepository _repo;
        public SATrailsService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        public void AddTrail(Trail trail)
        {
            _repo.Add(trail);
            return;
        }

        public void EditTrail(Trail trail)
        {
            var HoldTrail = _repo.Query<Trail>().Where(t => t.Id == trail.Id).FirstOrDefault();
            HoldTrail.Name = trail.Name;
            HoldTrail.Bears = trail.Bears;
            HoldTrail.Biking = trail.Biking;
            HoldTrail.Camping = trail.Camping;
            HoldTrail.Cougars = trail.Cougars;
            HoldTrail.DifficultyLevel = trail.DifficultyLevel;
            HoldTrail.Distance = trail.Distance;
            HoldTrail.Elevation = trail.Elevation;
            HoldTrail.Fishing = trail.Fishing;
            HoldTrail.Horses = trail.Horses;
            HoldTrail.Image = trail.Image;
            HoldTrail.Lakes = trail.Lakes;
            HoldTrail.Location = trail.Location;
            HoldTrail.Lookouts = trail.Lookouts;
            HoldTrail.Map = trail.Map;
            HoldTrail.OpenSeason = trail.OpenSeason;
            HoldTrail.Overview = trail.Overview;
            HoldTrail.PassRequired = trail.PassRequired;
            HoldTrail.Rating = trail.Rating;
            HoldTrail.Rivers = trail.Rivers;
            HoldTrail.Time = trail.Time;
            HoldTrail.Waterfalls = trail.Waterfalls;
            
            _repo.SaveChanges();
            return;
        }

        public Trail GetOneTrail(int id)
        {
            return _repo.Query<Trail>().Where(t => t.Id==id).FirstOrDefault();
        }

        public List<Trail> GetTrailsList()
        {
            return _repo.Query<Trail>().ToList();
        }
    }
}
