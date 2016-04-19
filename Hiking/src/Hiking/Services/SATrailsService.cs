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
        public List<Trail> GetTrailsList()
        {
            return _repo.Query<Trail>().ToList();
        }
    }
}
