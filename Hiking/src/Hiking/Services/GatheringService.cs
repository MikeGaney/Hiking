using Hiking.Models;
using Hiking.Repositories;
using Hiking.ViewModels.Gatherings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Services
{
    public class GatheringService : IGatheringService
    {
        private IGenericRepository repo;

        public GatheringService(IGenericRepository _repo)
        {
            this.repo = _repo;
        }

        public List<Gathering> GetAllGatherings()
        {
            var list = repo.Query<Gathering>().Where(g => g.Time >= DateTime.Now).OrderBy(g => g.Time).ToList();
            return list;
        }

        public GatheringViewModel GetOneGathering(int id)
        {
            var gathering = repo.Query<Gathering>().Where(g => g.Id == id).Include(g => g.GatheringUsers).FirstOrDefault();
            var trail = repo.Query<Trail>().Where(t => t.Id == gathering.TrailId).FirstOrDefault();
            var data = new GatheringViewModel {
                Id = gathering.Id,
                Description = gathering.Description,
                Name = gathering.Name,
                OwnerId = gathering.OwnerId,
                Time = gathering.Time,
                TrailId = gathering.TrailId,
                TrailName = gathering.TrailName,
                Image = trail.Image,
                Users = repo.Query<GatheringUsers>().Where(gu => gu.GatheringID == id).Select(gu => new GatheringUserViewModel {
                    DisplayName = gu.ApplicationUser.DisplayName,
                    FirstName = gu.ApplicationUser.FirstName,
                    LastName = gu.ApplicationUser.LastName,
                    UserId = gu.ApplicationUser.Id,
                }).ToList()
            };
            return data;
        }



        public void AddGathering(AddGatheringViewModel data)
        {
            var gather = new Gathering
            {
                Name = data.Name,
                Description = data.Description,
                Time = data.Time,
                TrailId = data.TrailId,
                OwnerId = data.OwnerId,
            };
            repo.Add<Gathering>(gather);
            repo.SaveChanges();

        }

        public void UpdateGathering(AddGatheringViewModel data)
        {
            var original = repo.Query<Gathering>().FirstOrDefault(g => g.Id == data.Id);
            original.Name = data.Name;
            original.Description = data.Description;
            original.Time = data.Time;
            original.TrailId = data.TrailId;
            original.TrailName = data.TrailName;

            repo.SaveChanges();
        }

        public void DeleteGathering(int id)
        {
            var gather = repo.Query<Gathering>().Where(g => g.Id == id).FirstOrDefault();
            repo.Delete<Gathering>(gather);
            return;
        }

        public void AddToGathering(AddUserToGatherViewModel data)
        {
            repo.Add<GatheringUsers>(new GatheringUsers
            {
                ApplicationUserId = data.UserID,
                GatheringID = data.GatherID
            });
            repo.SaveChanges();
        }

        public UserInGatheringViewModel IsUserInGathering(AddUserToGatherViewModel data)
        {
            var check = new UserInGatheringViewModel
            {
                Check = false
            };
            var users = repo.Query<GatheringUsers>().ToList();
            foreach (var user in users)
            {
                if (data.GatherID == user.GatheringID && data.UserID == user.ApplicationUserId)
                {
                    check.Check = true;
                }
            }

            return check;
        }

        public void RemoveFromGathering(AddUserToGatherViewModel data)
        {
            var model = new GatheringUsers
            {
                ApplicationUserId = data.UserID,
                GatheringID = data.GatherID
            };
            repo.Delete<GatheringUsers>(model);
            repo.SaveChanges();
        }

        public List<Gathering> SearchGatherings(GatheringSearchViewModel data)
        {
            var time = DateTime.Now;
            List<Gathering> searchList = repo.Query<Gathering>().ToList();

            if (data.GatherName != null) searchList = searchList.Where(g => g.Name.ToLower().Contains(data.GatherName.ToLower())).OrderBy(g => g.Time).ToList();

            if (data.TrailName != null) searchList = searchList.Where(g => g.TrailName.ToLower().Contains(data.TrailName.ToLower())).OrderBy(g => g.Time).ToList();

            if (data.Time != 0) searchList = searchList.Where(g => g.Time <= DateTime.Now.AddDays(data.Time) && g.Time >= DateTime.Now).OrderBy(g => g.Time).ToList();

            return searchList;
        }
    }
}
