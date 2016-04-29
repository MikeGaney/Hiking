using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Hiking.Models
{
    public class SampleDataGatherings
    {
        public static void Initialize(IServiceProvider sp)
        {
            var db = sp.GetService<ApplicationDbContext>();

            var userIdList = db.Users.Select(u => u.Id).ToList();
            var titleList = new List<string> { "Waterfall hike", "Falls day hike", "Sunny Outing", "Leisurely stroll", "Hilltop Adventure", "Extreme Excursion", "Elite Climb", "Fun in the Sun", "Railfall water-fall", "Outdoor escape"};
            var trailIdList = db.Trails.Select(t => t.Id).ToList();
            var trailList = db.Trails.ToList();
            Random rnd = new Random();

            if (!db.Gatherings.Any())
            {
                var gatherings = new List<Gathering>();

                for (int i = 0; i < 30; i++)
                {
                    var rndUserId = userIdList[rnd.Next(userIdList.Count)];
                    var rndTrailId = trailIdList[rnd.Next(trailIdList.Count)];
                    var trailName = trailList.Where(t => t.Id == rndTrailId).Select(t => t.Name).FirstOrDefault();

                    var gather = new Gathering
                    {
                        Name = titleList[rnd.Next(titleList.Count)],
                        OwnerId = rndUserId,
                        Time = DateTime.Now.AddDays(rnd.Next(1, 30)),
                        TrailId = rndTrailId,
                        TrailName = trailName,
                        Description = "Mauris auctor commodo aliquet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean convallis turpis consequat erat ultricies finibus. Suspendisse non placerat mi, ac ultrices nulla. Etiam mattis erat augue, eget vestibulum purus viverra sed. Fusce blandit justo eu enim accumsan hendrerit. Aliquam congue interdum quam vulputate sollicitudin. Donec egestas scelerisque dui, ac pharetra elit ullamcorper ut. Suspendisse pellentesque sapien ac massa tincidunt tincidunt. Vestibulum dolor lectus, mattis interdum gravida non."
                    };

                    db.Gatherings.Add(gather);

                    db.SaveChanges();
                }

                //db.Gatherings.AddRange(
                //    new Gathering
                //    {
                //        Name = titleList[rnd.Next(titleList.Count)],
                //        Description = "Mauris auctor commodo aliquet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean convallis turpis consequat erat ultricies finibus. Suspendisse non placerat mi, ac ultrices nulla. Etiam mattis erat augue, eget vestibulum purus viverra sed. Fusce blandit justo eu enim accumsan hendrerit. Aliquam congue interdum quam vulputate sollicitudin. Donec egestas scelerisque dui, ac pharetra elit ullamcorper ut. Suspendisse pellentesque sapien ac massa tincidunt tincidunt. Vestibulum dolor lectus, mattis interdum gravida non.",
                //        OwnerId = userIdList[rnd.Next(userIdList.Count)],
                //        Time = DateTime.Now.AddDays(rnd.Next(1, 30)),
                //        TrailId = trailList[rnd.Next(trailList.Count)]
                //    },
                //    new Gathering
                //    {
                //        Name = titleList[rnd.Next(titleList.Count)],
                //        Description = "Mauris auctor commodo aliquet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean convallis turpis consequat erat ultricies finibus. Suspendisse non placerat mi, ac ultrices nulla. Etiam mattis erat augue, eget vestibulum purus viverra sed. Fusce blandit justo eu enim accumsan hendrerit. Aliquam congue interdum quam vulputate sollicitudin. Donec egestas scelerisque dui, ac pharetra elit ullamcorper ut. Suspendisse pellentesque sapien ac massa tincidunt tincidunt. Vestibulum dolor lectus, mattis interdum gravida non.",
                //        OwnerId = userIdList[rnd.Next(userIdList.Count)],
                //        Time = DateTime.Now.AddDays(rnd.Next(1, 30)),
                //        TrailId = trailList[rnd.Next(trailList.Count)]
                //    },
                //    new Gathering
                //    {
                //        Name = titleList[rnd.Next(titleList.Count)],
                //        Description = "Mauris auctor commodo aliquet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean convallis turpis consequat erat ultricies finibus. Suspendisse non placerat mi, ac ultrices nulla. Etiam mattis erat augue, eget vestibulum purus viverra sed. Fusce blandit justo eu enim accumsan hendrerit. Aliquam congue interdum quam vulputate sollicitudin. Donec egestas scelerisque dui, ac pharetra elit ullamcorper ut. Suspendisse pellentesque sapien ac massa tincidunt tincidunt. Vestibulum dolor lectus, mattis interdum gravida non.",
                //        OwnerId = userIdList[rnd.Next(userIdList.Count)],
                //        Time = DateTime.Now.AddDays(rnd.Next(1, 30)),
                //        TrailId = trailList[rnd.Next(trailList.Count)]
                //    },
                //    new Gathering
                //    {
                //        Name = titleList[rnd.Next(titleList.Count)],
                //        Description = "Mauris auctor commodo aliquet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean convallis turpis consequat erat ultricies finibus. Suspendisse non placerat mi, ac ultrices nulla. Etiam mattis erat augue, eget vestibulum purus viverra sed. Fusce blandit justo eu enim accumsan hendrerit. Aliquam congue interdum quam vulputate sollicitudin. Donec egestas scelerisque dui, ac pharetra elit ullamcorper ut. Suspendisse pellentesque sapien ac massa tincidunt tincidunt. Vestibulum dolor lectus, mattis interdum gravida non.",
                //        OwnerId = userIdList[rnd.Next(userIdList.Count)],
                //        Time = DateTime.Now.AddDays(rnd.Next(1, 30)),
                //        TrailId = trailList[rnd.Next(trailList.Count)]
                //    },
                //    new Gathering
                //    {
                //        Name = titleList[rnd.Next(titleList.Count)],
                //        Description = "Mauris auctor commodo aliquet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean convallis turpis consequat erat ultricies finibus. Suspendisse non placerat mi, ac ultrices nulla. Etiam mattis erat augue, eget vestibulum purus viverra sed. Fusce blandit justo eu enim accumsan hendrerit. Aliquam congue interdum quam vulputate sollicitudin. Donec egestas scelerisque dui, ac pharetra elit ullamcorper ut. Suspendisse pellentesque sapien ac massa tincidunt tincidunt. Vestibulum dolor lectus, mattis interdum gravida non.",
                //        OwnerId = userIdList[rnd.Next(userIdList.Count)],
                //        Time = DateTime.Now.AddDays(rnd.Next(1, 30)),
                //        TrailId = trailList[rnd.Next(trailList.Count)]
                //    },
                //    new Gathering
                //    {
                //        Name = titleList[rnd.Next(titleList.Count)],
                //        Description = "Mauris auctor commodo aliquet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean convallis turpis consequat erat ultricies finibus. Suspendisse non placerat mi, ac ultrices nulla. Etiam mattis erat augue, eget vestibulum purus viverra sed. Fusce blandit justo eu enim accumsan hendrerit. Aliquam congue interdum quam vulputate sollicitudin. Donec egestas scelerisque dui, ac pharetra elit ullamcorper ut. Suspendisse pellentesque sapien ac massa tincidunt tincidunt. Vestibulum dolor lectus, mattis interdum gravida non.",
                //        OwnerId = userIdList[rnd.Next(userIdList.Count)],
                //        Time = DateTime.Now.AddDays(rnd.Next(1, 30)),
                //        TrailId = trailList[rnd.Next(trailList.Count)]
                //    },
                //    new Gathering
                //    {
                //        Name = titleList[rnd.Next(titleList.Count)],
                //        Description = "Mauris auctor commodo aliquet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean convallis turpis consequat erat ultricies finibus. Suspendisse non placerat mi, ac ultrices nulla. Etiam mattis erat augue, eget vestibulum purus viverra sed. Fusce blandit justo eu enim accumsan hendrerit. Aliquam congue interdum quam vulputate sollicitudin. Donec egestas scelerisque dui, ac pharetra elit ullamcorper ut. Suspendisse pellentesque sapien ac massa tincidunt tincidunt. Vestibulum dolor lectus, mattis interdum gravida non.",
                //        OwnerId = userIdList[rnd.Next(userIdList.Count)],
                //        Time = DateTime.Now.AddDays(rnd.Next(1, 30)),
                //        TrailId = trailList[rnd.Next(trailList.Count)]
                //    },
                //    new Gathering
                //    {
                //        Name = titleList[rnd.Next(titleList.Count)],
                //        Description = "Mauris auctor commodo aliquet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean convallis turpis consequat erat ultricies finibus. Suspendisse non placerat mi, ac ultrices nulla. Etiam mattis erat augue, eget vestibulum purus viverra sed. Fusce blandit justo eu enim accumsan hendrerit. Aliquam congue interdum quam vulputate sollicitudin. Donec egestas scelerisque dui, ac pharetra elit ullamcorper ut. Suspendisse pellentesque sapien ac massa tincidunt tincidunt. Vestibulum dolor lectus, mattis interdum gravida non.",
                //        OwnerId = userIdList[rnd.Next(userIdList.Count)],
                //        Time = DateTime.Now.AddDays(rnd.Next(1, 30)),
                //        TrailId = trailList[rnd.Next(trailList.Count)]
                //    },
                //    new Gathering
                //    {
                //        Name = titleList[rnd.Next(titleList.Count)],
                //        Description = "Mauris auctor commodo aliquet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean convallis turpis consequat erat ultricies finibus. Suspendisse non placerat mi, ac ultrices nulla. Etiam mattis erat augue, eget vestibulum purus viverra sed. Fusce blandit justo eu enim accumsan hendrerit. Aliquam congue interdum quam vulputate sollicitudin. Donec egestas scelerisque dui, ac pharetra elit ullamcorper ut. Suspendisse pellentesque sapien ac massa tincidunt tincidunt. Vestibulum dolor lectus, mattis interdum gravida non.",
                //        OwnerId = userIdList[rnd.Next(userIdList.Count)],
                //        Time = DateTime.Now.AddDays(rnd.Next(1, 30)),
                //        TrailId = trailList[rnd.Next(trailList.Count)]
                //    },
                //    new Gathering
                //    {
                //        Name = titleList[rnd.Next(titleList.Count)],
                //        Description = "Mauris auctor commodo aliquet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean convallis turpis consequat erat ultricies finibus. Suspendisse non placerat mi, ac ultrices nulla. Etiam mattis erat augue, eget vestibulum purus viverra sed. Fusce blandit justo eu enim accumsan hendrerit. Aliquam congue interdum quam vulputate sollicitudin. Donec egestas scelerisque dui, ac pharetra elit ullamcorper ut. Suspendisse pellentesque sapien ac massa tincidunt tincidunt. Vestibulum dolor lectus, mattis interdum gravida non.",
                //        OwnerId = userIdList[rnd.Next(userIdList.Count)],
                //        Time = DateTime.Now.AddDays(rnd.Next(1, 30)),
                //        TrailId = trailList[rnd.Next(trailList.Count)]
                //    },
                //    new Gathering
                //    {
                //        Name = titleList[rnd.Next(titleList.Count)],
                //        Description = "Mauris auctor commodo aliquet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean convallis turpis consequat erat ultricies finibus. Suspendisse non placerat mi, ac ultrices nulla. Etiam mattis erat augue, eget vestibulum purus viverra sed. Fusce blandit justo eu enim accumsan hendrerit. Aliquam congue interdum quam vulputate sollicitudin. Donec egestas scelerisque dui, ac pharetra elit ullamcorper ut. Suspendisse pellentesque sapien ac massa tincidunt tincidunt. Vestibulum dolor lectus, mattis interdum gravida non.",
                //        OwnerId = userIdList[rnd.Next(userIdList.Count)],
                //        Time = DateTime.Now.AddDays(rnd.Next(1, 30)),
                //        TrailId = trailList[rnd.Next(trailList.Count)]
                //    },
                //    new Gathering
                //    {
                //        Name = titleList[rnd.Next(titleList.Count)],
                //        Description = "Mauris auctor commodo aliquet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean convallis turpis consequat erat ultricies finibus. Suspendisse non placerat mi, ac ultrices nulla. Etiam mattis erat augue, eget vestibulum purus viverra sed. Fusce blandit justo eu enim accumsan hendrerit. Aliquam congue interdum quam vulputate sollicitudin. Donec egestas scelerisque dui, ac pharetra elit ullamcorper ut. Suspendisse pellentesque sapien ac massa tincidunt tincidunt. Vestibulum dolor lectus, mattis interdum gravida non.",
                //        OwnerId = userIdList[rnd.Next(userIdList.Count)],
                //        Time = DateTime.Now.AddDays(rnd.Next(1, 30)),
                //        TrailId = trailList[rnd.Next(trailList.Count)]
                //    }


                //);
            }
            db.SaveChanges();
        }
    }
}
