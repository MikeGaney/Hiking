using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Hiking.Models
{
    public class SampleDataGatheringUsers
    {
        public static void Initialize(IServiceProvider sp)
        {
            var db = sp.GetService<ApplicationDbContext>();

            var userIdList = db.Users.Select(u => u.Id).ToList();
            var gatheringIdList = db.Gatherings.Select(g => g.Id).ToList();
            Random rnd = new Random();

            if (!db.GatheringUsers.Any())
            {

                //var userTrails = new List<UserTrail>();

                for (int i = 0; i < 50; i++)
                {
                    var rndUserId = userIdList[rnd.Next(userIdList.Count)];
                    var rndgatherId = gatheringIdList[rnd.Next(gatheringIdList.Count)];
                    //var rndUserTrail = db.UserTrails.FirstOrDefault(ut => ut.ApplicationUserId == rndUserId && ut.TrailId == rndTrailId);
                    var rndGatherUser = db.GatheringUsers.FirstOrDefault(gu => gu.ApplicationUserId == rndUserId && gu.GatheringID == rndgatherId);

                    if (rndGatherUser == null)
                    {
                        var gatherUser = new GatheringUsers
                        {
                            ApplicationUserId = rndUserId,
                            GatheringID = rndgatherId
                        };
                        //userTrails.Add(userTrail);

                        db.GatheringUsers.Add(gatherUser);
                        db.SaveChanges();
                    }


                }

                //for (int i = 0; i < 30; i++)
                //{
                //    db.GatheringUsers.Add(new GatheringUsers
                //    {
                //        GatheringID = gatheringIdList[rnd.Next(gatheringIdList.Count)],
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //    });
                //}

                //db.GatheringUsers.AddRange(
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    },
                //    new GatheringUsers
                //    {
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                //    }
                //    );
            }
            db.SaveChanges();
        }
    }
}
