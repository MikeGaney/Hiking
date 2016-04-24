using Hiking.Models;
using Hiking.Repositories;
using Hiking.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Services
{
    public class BackpackService : IBackpackService
    {
        private IGenericRepository repo;

        public BackpackService(IGenericRepository _repo)
        {
            this.repo = _repo;
        }

        public List<Trail> GetTrailList(string id)
        {
            //var user = repo.Query<ApplicationUser>().Where(u => u.Id == id).Include(u => u.UserTrails).FirstOrDefault();
            //var test = repo.Query<ApplicationUser>().Where(u => u.Id == id).Select(u => new UserTrailsModel
            //{
            //    Trails = u.UserTrails.Select(ut => ut.Trail).ToList()
            //});
            //var list = test
            //return test;
            return new List<Trail>();
        }

        public BackpackTrailViewModel GetTrail(int id)
        {
            var trail = repo.Query<Trail>().Where(t => t.Id == id).Select(t => new BackpackTrailViewModel {
                Id = t.Id,
                Distance = t.Distance,
                Elevation = t.Elevation,
                Name = t.Name,
                TrailImage = t.Image
            }).FirstOrDefault();
            return trail;
        }

        public void CompletedTrail(int id)
        {
            var trailCompleted = repo.Query<Trail>().Where(t => t.Id == id).FirstOrDefault();
            repo.Delete(trailCompleted);
            repo.SaveChanges();
            //trailCompleted = ** need to remove from one and add to another (field)
            return;
        }

        public void RemoveTrail(int id)
        {
            var trailInBkPk = repo.Query<Trail>().Where(t => t.Id == id).FirstOrDefault();
            repo.Delete(trailInBkPk);
            repo.SaveChanges();
            return;
        }
    }
}
