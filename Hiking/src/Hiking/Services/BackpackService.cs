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

            //var trails = repo.Query<UserTrail>().Where(ut => ut.ApplicationUser.Id == id).Select(u => u.Trail).Take        (4).ToList();
            var trails = repo.Query<UserTrail>().Where(ut => ut.ApplicationUser.Id == id).Select(u => u.Trail).ToList();
            return trails;
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

        public void CompletedTrail(UserTrail data)
        {
            // var trailCompleted = repo.Query<UserTrail>().Where(ut => ut.TrailId == id).FirstOrDefault();
            //repo.Delete<UserTrail>(data);
            //trailCompleted = ** need to remove from one and add to another (field)
            //repo.Add<CompletedTrail>(data);
            var hiker = repo.Query<ApplicationUser>().Where(u => u.Id == data.ApplicationUserId).FirstOrDefault();
            var completedTrail = repo.Query<Trail>().Where(t => t.Id == data.TrailId).FirstOrDefault();
            var CompletedTrail = new CompletedTrail
            {
                Name = completedTrail.Name,
                TrailImage = completedTrail.Image
            };
            hiker.CompletedTrails.Add(CompletedTrail);
            repo.SaveChanges();
            return;
        }

        public void RemoveTrail(UserTrail data)
        {
           // var trailInBkPk = repo.Query<UserTrail>().Where(ut => ut.TrailId == id).FirstOrDefault();
            repo.Delete<UserTrail>(data);          
            repo.SaveChanges();
            return;
        }

        public void AddToBackpack(UserTrail data)
        {
            repo.Add<UserTrail>(data);
            repo.SaveChanges();
            return;
        }

        public List<CompletedTrail> GetCompletedTrails(string id)
        {
            var completedTrailsList = repo.Query<ApplicationUser>().Where(u => u.Id == id).Include(u => u.CompletedTrails).FirstOrDefault();
            var list = completedTrailsList.CompletedTrails.ToList();
            return list;
        }

        public void SaveCompletedTrail(UserTrail id)
        {
            var user = repo.Query<ApplicationUser>().Where(u => u.Id == id.ApplicationUserId).Include( u => u.CompletedTrails).FirstOrDefault();
            var trail = repo.Query<Trail>().Where(t => t.Id == id.TrailId).FirstOrDefault();
            var completed = new CompletedTrail
            {
                Name = trail.Name,
                TrailImage = trail.Image
            };
            user.CompletedTrails.Add(completed);
            repo.SaveChanges();
        }
    }
}
