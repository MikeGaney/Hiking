using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Hiking.Models
{
    public class SampleDataUserTrails
    {
        public static void Initialize(IServiceProvider sp)
        {
            var db = sp.GetService<ApplicationDbContext>();
            var userIdList = db.Users.Select(u => u.Id).ToList();
            var trailIdList = db.Trails.Select(t => t.Id).ToList();
            Random rnd = new Random();

            if (!db.UserTrails.Any())
            {
                //for (int i = 0; i < 10; i++)
                //{
                //    db.UserTrails.Add(new UserTrail
                //    {
                //        //ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        //TrailId = trailIdList[rnd.Next(trailIdList.Count)]
                //        ApplicationUserId = "helloWorld",
                //        TrailId = 10
                //    });
                //}

                db.UserTrails.Add(new UserTrail
                {
                    //ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                    //TrailId = trailIdList[rnd.Next(trailIdList.Count)]
                    ApplicationUserId = "helloWorld",
                    TrailId = 10
                });

                db.UserTrails.Add(new UserTrail
                {
                    //ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                    //TrailId = trailIdList[rnd.Next(trailIdList.Count)]
                    ApplicationUserId = "hello World",
                    TrailId = 11
                });

                //db.UserTrails.AddRange( new List<UserTrail> {
                //    new UserTrail
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        TrailId = trailIdList[rnd.Next(trailIdList.Count)]
                //    },
                //    new UserTrail
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        TrailId = trailIdList[rnd.Next(trailIdList.Count)]
                //    }
                //}
                //);
            }

            db.SaveChanges();
        }
    }
}
