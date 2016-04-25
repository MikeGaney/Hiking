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
                //for (int i = 0; i < 30; i++)
                //{
                //    db.GatheringUsers.Add(new GatheringUsers
                //    {
                //        GatheringID = gatheringIdList[rnd.Next(gatheringIdList.Count)],
                //        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                //    });
                //}

                db.GatheringUsers.AddRange(
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    },
                    new GatheringUsers
                    {
                        ApplicationUserId = userIdList[rnd.Next(userIdList.Count)],
                        GatheringID = gatheringIdList[rnd.Next(userIdList.Count)]
                    }
                    );
            }
            db.SaveChanges();
        }
    }
}
