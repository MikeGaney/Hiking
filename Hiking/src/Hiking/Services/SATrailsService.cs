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

        public void DeleteTrail(int id)
        {
            var TrailToDelete = _repo.Query<Trail>().FirstOrDefault(t=>t.Id==id);
            _repo.Delete<Trail>(TrailToDelete);
            _repo.SaveChanges();
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
            var list = _repo.Query<Trail>().Where(t => t.Id==id).Include(t => t.TrailComments).Include(t => t.Gatherings).Include(t => t.FamilyRating).Include(t => t.BeautyRating).Include(t => t.RatingList).FirstOrDefault();
            list.Gatherings = list.Gatherings.OrderBy(g => g.Time).ToList();
            list.BeautyRate = (int)list.BeautyRating.Average(b => b.Rating);
            list.FamilyRate = (int)list.FamilyRating.Average(r => r.Rating);
            list.Rating = (int)list.RatingList.Average(r => r.Rating);

            List<Gathering> newList = new List<Gathering>();
            foreach (var item in list.Gatherings)
            {
                if (item.Time >= DateTime.Now)
                {
                    newList.Add(item);
                }
            }
            list.Gatherings = newList;

            return list;
        }

        public List<Trail> GetTrailsList()
        {
            return _repo.Query<Trail>().ToList();
        }
    }
}
