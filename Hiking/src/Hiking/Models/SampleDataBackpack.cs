using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Hiking.Models
{
    public class SampleDataBackpack
    {
        public static void Initialize(IServiceProvider sp)
        {
            var db = sp.GetService<ApplicationDbContext>();

            var userIdList = db.Users.Select(u => u.Id).ToList();
            var trailIdList = db.Trails.Select(t => t.Id).ToList();

            Random rnd = new Random();

            db.UserTrails.AddRange(
                //use for loop to go through as many times as  you want
                    new UserTrail
                    {
                        TrailId = trailIdList[rnd.Next(trailIdList.Count)],
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)]
                    },
                    new UserTrail
                    {
                        TrailId = trailIdList[rnd.Next(trailIdList.Count)],
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)]
                    }
                );

            //for (int i = 0; i < 50; i++)
            //{
            //    db.UserTrails.Add(new UserTrail
            //    {
            //        TrailId = trailIdList[rnd.Next(trailIdList.Count)],
            //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)]
            //    });
            //}

            db.SaveChanges();
        }
    }
}
