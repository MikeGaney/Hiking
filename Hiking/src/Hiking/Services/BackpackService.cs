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

        public List<Trail> GetTrailList()
        {

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
            return;
        }
    }
}
