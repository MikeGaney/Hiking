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
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        TrailId = trailIdList[rnd.Next(trailIdList.Count)]
                //    });
                //    db.SaveChanges();
                //}

                var userTrails = new List<UserTrail>();

                for (int i = 0; i < 50; i++)
                {
                    var rndUserId = userIdList[rnd.Next(userIdList.Count)];
                    var rndTrailId = trailIdList[rnd.Next(trailIdList.Count)];
                    var rndUserTrail = db.UserTrails.FirstOrDefault(ut => ut.ApplicationUserId == rndUserId && ut.TrailId == rndTrailId);

                    if (rndUserTrail == null)
                    {
                        var userTrail = new UserTrail
                        {
                            ApplicationUserId = rndUserId,
                            TrailId = rndTrailId
                        };
                        userTrails.Add(userTrail);

                        db.UserTrails.Add(userTrail);
                        db.SaveChanges();
                    }
                    

                }

                //db.UserTrails.AddRange(userTrails);

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
