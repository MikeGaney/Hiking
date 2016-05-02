using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Hiking.Models
{
    public class SampleDataTrail
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();

            var userIdList = db.Users.Select(u => u.Id).ToList();
            Random rnd = new Random();

            if (!db.Trails.Any())
            {
                db.Trails.AddRange(

                new Trail
                {
                    BackgroundImage = "",
                    Name = "Lake Philippa",
                    Map = "http://www.niffgurd.com/mark/parks/washington/cascades/northforksnoqualmie/lakephilippa/lakephilippa_tpo.jpg",
                    Image = "http://wdfw.wa.gov/fishing/washington/graphics/lakes/1250.jpg",
                    Distance = 9.0m,
                    Time = 4.0m,
                    Location = "Snoqualmie Region, North Bend Area",
                    Elevation = "Gain: 1800 ft. Highest Point: 3362 ft.",
                    DifficultyLevel = 3,
                    Overview = "Lake Philippa is a big, beautiful alpine lake, one of the finest in the North Fork Snoqualmie River area. But getting there definitely falls into the realm of Lake Bagging, the sport of hiking to off - trail lakes that can be as mentally and physically challenging as peak bagging.There is a trail of sorts to Lake Philippa, but it is not for the inexperienced.",
                    PassRequired = true,
                    Biking = true,
                    Fishing = true,
                    Camping = true,
                    Horses = false,
                    Lakes = true,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = true,
                    Bears = true,
                    Cougars = true,
                    Rating = 4,
                    OpenSeason = "Open",
                    Latitude = 47.6493,
                    Longitude = -121.6456,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },

                new Trail
                {
                    BackgroundImage = "",
                    Name = "Wallace Falls - Greg Ball Trail",
                    Map = "http://www.mappery.com/maps/Wallace-Falls-State-Park-Map.mediumthumb.pdf.png",
                    Image = "http://www.northwest-landscapes.com/images/waterfalls/Upper-Wallace-Falls.jpg",
                    Distance = 8.3m,
                    Time = 3.5m,
                    Location = "Central cascades, Stevens Pass",
                    Elevation = "Gain: 1300 ft. Highest Point: 1500 ft.",
                    DifficultyLevel = 3,
                    Overview = "The Greg Ball Trail is a trail envisioned by and honoring one of the greatest trail advocates this state has ever had. Ball was a former board member and director of the WTA. In 1993 he launched the organization’s volunteer trail maintenance program which has since grown into the largest state-based program of its kind. In 2004 at the age of 60, tragically, Greg passed away after battling cancer. He designed this trail to Wallace Lake and it was finished in his memory by volunteers from WTA and through support from the Spring Trail Trust.Start your hike by following the crowds on the main trail toward Wallace Falls.Soon come to a junction.Turning left, follow the Old Railroad Grade Trail 2.2 miles before arriving at a large toilet facility and the beginning of the Greg Ball Trail to your left.A right turn leads hikers 1.1 miles along the Wallace River before arriving at a junction with the Wallace Falls Trail-- a beautiful hike to three major waterfalls in Wallace Falls State Park. Your route follows the Greg Ball Trail.Pass the toilet facility and follow the trail alongside and above the North Fork of the Wallace River, climbing gently and meandering through maturing second growth.About three miles from the trailhead, catch glimpses of the river cascading down a narrow chasm.About a half mile farther on, the trail terminates at a DNR Road. Turn right on the road and proceed for 0.1 mile to a junction with an old road taking off to the left.Follow this near level forested way for 0.5 mile to the southern tip of Wallace Lake. This is a pretty spot in heavy timber with picnic tables and an attractive bridge, but the northern end of the lake at Pebble Beach is much nicer.To reach it, head left, following another old road.After a half mile arrive at the beach, a gravelly outwash at the base of a small talus slope.Find yourself a nice sun - warmed log and enjoy the view across the placid lake to what is colloquially referred to as Zeke’s Hill and Mount Index peeking in the distance.Savor the serenity here away from the thundering falls and their crowded trails. Camping is allowed around Wallace Lake and further on at Jay Lake, so you can prolong your stay at this tranquil sanctuary.",
                    PassRequired = true,
                    Biking = false,
                    Fishing = true,
                    Camping = true,
                    Horses = false,
                    Lakes = false,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = true,
                    Bears = true,
                    Cougars = true,
                    Rating = 4,
                    OpenSeason = "Open",
                    Latitude = 47.8669,
                    Longitude = -121.6820,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                        UserId = userIdList[rnd.Next(userIdList.Count)],
                        Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                        UserId = userIdList[rnd.Next(userIdList.Count)],
                        Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                        UserId = userIdList[rnd.Next(userIdList.Count)],
                        Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                        UserId = userIdList[rnd.Next(userIdList.Count)],
                        Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Goat Lake",
                    Map = "http://www.nwhiker.com/hikemaps/gifford/map14.png",
                    Image = "http://jeaster.net/wp-content/uploads/2013/10/CIMG5679.jpg",
                    Distance = 10.4m,
                    Time = 6.5m,
                    Location = "North Cascades, Mountain Loop Highway",
                    Elevation = "Gain: 1400 ft. Highest Point: 3161 ft.",
                    DifficultyLevel = 4,
                    Overview = "A nice hike with plenty of variety. Beautiful forest, a rushing creek, waterfalls of all shapes and sizes, history, and of course a large blue-green lake surrounded by snowy peaks. At 10.4 miles, it can be either a day-hike or a quick early season overnight. You won’t be alone, though – this is a popular trail with both hikers and backpackers. The trail starts at the far end of the large parking lot.In just a few minutes, come to a well signed junction for the Upper Elliot and Lower Elliot trails.They’ll rejoin in approximately three miles, so the choice is yours.Consider taking one trail to the lake, and the other one on the trip back to your car. The trail to the right drops down to the creek.You will be on a twisty trail surrounded by conifers, alders, ferns and skunk cabbage.The first mile or so is close enough to hear the creek and periodically enjoy peek - a - boo views of it.The tread is soft, and the stream crossings are small with stepping stones that may be partially submerged in the early season. The trail to the left follows an old road.It is straight and wide, with a mild but constant uphill and then downhill grade.The trail consists of an old layer of packed gravel, and is lined with alders.Stream crossings are more difficult early season, but still manageable.There is an eroded culvert in one of the streams that is a little tricky to navigate, so take it slow and if you feel unsafe, don't go beyond your ability level. ",
                    PassRequired = true,
                    Biking = false,
                    Fishing = true,
                    Camping = true,
                    Horses = false,
                    Lakes = true,
                    Rivers = true,
                    Waterfalls = true,
                    Lookouts = true,
                    Bears = true,
                    Cougars = true,
                    Rating = 4,
                    OpenSeason = "Open",
                    Latitude = 48.0537,
                    Longitude = -121.4113,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },

                new Trail
                {
                    BackgroundImage = "",
                    Name = "Rattlesnake Mountain",
                    Map = "http://www.willhiteweb.com/puget_sound_hiking/rattlesnake_mountain/rattlesnake_mountain_map.jpg",
                    Image = "http://www.ci.snoqualmie.wa.us/Portals/0/Parks/Mount%20Si%20Sunset_Snoqualmie%20Valley%20Historical%20Society.jpg",
                    Distance = 10.9m,
                    Time = 6.0m,
                    Location = "Snoqualmie Region, North Bend Area",
                    Elevation = "Gain: 2520 ft. Hignest point: 3500 ft.",
                    DifficultyLevel = 4,
                    Overview = "If you've hiked to Rattlesnake Ledges and beyond from Rattlesnake Lake, this is a delightful alternative. Thanks to the handiwork of various groups in the outdoor community, hikers can now reach Rattlesnake Mountain from the west, starting from a trailhead at Snoqualmie Point. Expect fewer hikers on this approach, and enjoy fantastic views out over the Snoqualmie Valley, Mount Si, Mount Teneriffe, North Bend and more.Hike to one of the pleasant viewpoints along the way, to Rattlesnake Mountain, or do a traverse all the way to Rattlesnake Lake, clocking in at 11 miles.The views are some of the best in the Cascade foothills and the trail can be hiked year-round, though it can be snowy in winter. The trail was officially dedicated in June 2007, though people had hiked this route using a mix of trail and logging roads for years before. Now the trail winds its way through mostly second - growth forest, crossing a few logging roads and requiring just a few stints on old roads. ",
                    PassRequired = true,
                    Biking = false,
                    Fishing = false,
                    Camping = false,
                    Horses = true,
                    Lakes = false,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = true,
                    Bears = true,
                    Cougars = true,
                    Rating = 4,
                    OpenSeason = "Closed",
                    Latitude = 47.5092,
                    Longitude = -121.8434,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },

                new Trail
                {
                    BackgroundImage = "",
                    Name = "Second Beach",
                    Map = "http://www.willhiteweb.com/washington/second_beach/second_beach_map.jpg",
                    Image = "http://www.natezeman.com/images/large/0438_Second_Beach_Sunrise_Nate_Zeman.jpg",
                    Distance = 4.0m,
                    Time = 1.5m,
                    Location = "Olympic Peninsula, Pacific Coast",
                    Elevation = "Gain: 350 ft. Highest Point: 250 ft. ",
                    DifficultyLevel = 1,
                    Overview = "Just south of the village of La Push are three Olympic Coast charms: First, Second, and Third Beaches. Each one is sandy and broad and hemmed in by dramatic bluffs and headlands. And while they're in close proximity to each other, you can't hike from one to the next because those headlands block the way. With roadside access, First Beach is the easiest to get to and so can be crowded. Third Beach requires a 1.2-mile slog down a forested trail. But Second Beach is just right: a hike just long enough to discourage crowds, yet short enough to encourage all who want to see this beautiful beach. Well - constructed and well - maintained, the trail starts on the Quileute Indian Reservation.Immediately cross a small creek lined with imposing Sitka spruce before beginning a short climb.At the height of the land enter Olympic National Park, and then begin a short, steep descent to the beach, the distant surf growing louder with each step you take.Soon, start catching glimpses of offshore sea stacks through the surrounding towering spruce.Before you know it, emerge on the log - lined shore.Take a deep breath.The beauty of this place just may leave you short of breath.",
                    PassRequired = false,
                    Biking = true,
                    Fishing = true,
                    Camping = true,
                    Horses = false,
                    Lakes = false,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = true,
                    Bears = true,
                    Cougars = true,
                    Rating = 4,
                    OpenSeason = "Open",
                    Latitude = 47.8982,
                    Longitude = -124.6238,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Hoh River Trail to Five Mile Island",
                    Map = "http://www.ourlifeoutside.com/site/wp-content/uploads/2014/06/Screen-Shot-2014-06-08-at-10.29.53-PM.png",
                    Image = "http://ngjyra.com/wp-content/uploads/2016/03/Hall-of-Mosses-0011.jpg",
                    Distance = 10.6m,
                    Time = 5.0m,
                    Location = "Olympic Peninsula, Pacific Coast",
                    Elevation = "Gain: 300 ft. Highest Point: 800 ft.",
                    DifficultyLevel = 3,
                    Overview = "A classic hike in any season, but come in winter and you’ll find that the hordes of tourists, hikers, and climbers who use this trail in the summer have dwindled to just a trickle. You can’t escape a sense of magic at the Hoh.The huge trees, the cascading moss, the birds and Roosevelt elk, the Olympic Mountains rising above and the broad river valley extending up and downstream all add up to make this a hike that must be done at least once in a lifetime.The trail is easy, too, with minimal elevation gain, excellent tread, and an open understory. Hike as far as you’d like; there are great spots to stop all along the way. Five Mile Island offers a sunny lunch spot with views of Bogachiel Peak.If it is raining, and you want to find a sheltered location, you can press on another half mile to the Happy Four Shelter.",
                    PassRequired = true,
                    Biking = true,
                    Fishing = true,
                    Camping = true,
                    Horses = true,
                    Lakes = true,
                    Rivers = true,
                    Waterfalls = true,
                    Lookouts = true,
                    Bears = true,
                    Cougars = true,
                    Rating = 5,
                    OpenSeason = "Open",
                    Latitude = 47.8597,
                    Longitude = -123.9337,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Deception Pass State Park",
                    Map = "http://www.mappery.com/maps/Deception-Pass-State-Park-Map-2.mediumthumb.pdf.png",
                    Image = "https://c2.staticflickr.com/8/7127/7727776492_8683e7bfc3_b.jpg",
                    Distance = 5.0m,
                    Time = 2.5m,
                    Location = "Puget Sound and Islands",
                    Elevation = "Gain: 350 ft. Highest Point: 110 ft.",
                    DifficultyLevel = 3,
                    Overview = "On your next trip to Deception Pass State Park, don’t cross over the Deception Pass bridge. Instead, take the road down to Bowman Bay for some fine hiking along the rugged cliffs. Great views of the bridge over Deception and Canoe Pass, calm Lottie Bay, a woodland walk through hemlock, fir and Pacific Madrone, plus the legend of the Maiden of Deception Pass are what await you here. Begin your journey by walking out on the fishing pier to see what people are catching and snap a few pictures of the seagulls hanging around hoping for a handout. Unless you have a line in the water, walk back and head south along the shore of Bowman Bay to the trail to Lottie and Lighthouse Point.Pick up the trail as it crosses over a marshy area and up a small steep rocky cliff.Drop down to sea level and come to a signed intersection.Left takes you up to Highway 20 and Pass Lake, but you'll hang a right and shortly come to another intersection. ",
                    PassRequired = true,
                    Biking = true,
                    Fishing = true,
                    Camping = true,
                    Horses = false,
                    Lakes = false,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = true,
                    Bears = false,
                    Cougars = false,
                    Rating = 4,
                    OpenSeason = "Open",
                    Latitude = 48.4169,
                    Longitude = -122.6512,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Huntoon Point",
                    Map = "http://www.putz-in-boots.com/trips_hiking/trip_hiking_2014/huntoon_pt_dec/25%20Huntoon%20Point%20Map.jpg",
                    Image = "http://www.weltyphotography.com/sets/home-range/img/24.JPG",
                    Distance = 6.0m,
                    Time = 3.0m,
                    Location = "North Cascades, Mount Baker Area",
                    Elevation = "Gain: 12 ft. Highest point: 5200 ft.",
                    DifficultyLevel = 3,
                    Overview = "With a starting elevation of 4,300, this tour is your best guarantee of good snow, even in a lean year. The sojourn to Huntoon Point is a study in contrasts.It starts amid the hustle and bustle of the Mount Baker Ski Area and ends in the silence of Kulshan Ridge, where icy winds blowing off glaciers will cleanse your soul and refresh your spirit. Park at the enormous lot adjoining the upper lodge of the ski area(4, 300 feet) and head up from the southeast corner of the lot.The route is straightforward, but not without some minor huffing and puffing.You’ll be swimming against the current of downhill skiers and snowboarders, but the snow - covered high meadows will compensate for the traffic. ",
                    PassRequired = false,
                    Biking = false,
                    Fishing = false,
                    Camping = true,
                    Horses = false,
                    Lakes = false,
                    Rivers = false,
                    Waterfalls = true,
                    Lookouts = true,
                    Bears = false,
                    Cougars = false,
                    Rating = 5,
                    OpenSeason = "Open",
                    Latitude = 48.8467,
                    Longitude = -121.6910,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Red Mountain Lookout",
                    Map = "http://www.willhiteweb.com/teanawayriver/red_top_mountain/red-top-mountain-lookout-map.jpg",
                    Image = "http://www.willhiteweb.com/teanawayriver/red_top_mountain/red-top-lookout.jpg",
                    Distance = 2.0m,
                    Time = 1.0m,
                    Location = "North Cascades, Mountain Loop Highway",
                    Elevation = "Gain: 700 ft. Highest Point: 2800 ft. ",
                    DifficultyLevel = 3,
                    Overview = "This seldom-used trail within Glacier Peak Wilderness leads through an old-growth forest with magnificent, large trees to the site of an old fire lookout build in the 1930s. Some of the firs in the deep forest on both sides of the trail measure six feet thick at their base.The former lookout site has excellent views of the Pride Basin glaciers and land to the south. The trail ends at a rock outcropping a short distance beyond the former lookout site.There is no structure here, all that remains of the former fire lookout is the spectacular views of the surrounding valley and craggy mountains.",
                    PassRequired = true,
                    Biking = true,
                    Fishing = false,
                    Camping = false,
                    Horses = false,
                    Lakes = false,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = true,
                    Bears = true,
                    Cougars = true,
                    Rating = 3,
                    OpenSeason = "Closed",
                    Latitude = 48.0584,
                    Longitude = -121.2878,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Church Mountain",
                    Map = "https://nwgeology.files.wordpress.com/2015/09/hidden-lakes-trail-topo.jpg",
                    Image = "http://d7bmbwiglir4w.cloudfront.net/sites/default/files/photos/routes/ChurchMountainFromFalseSummit.jpg",
                    Distance = 8.5m,
                    Time = 3.5m,
                    Location = "North Cascades, Mount Baker Area",
                    Elevation = "Gain: 3750 ft. Highest Point 6100 ft.",
                    DifficultyLevel = 5,
                    Overview = "The rewards for this strenuous hike are a bouquet of fall colors and a vast panorama of North Cascades mountains. From the trailhead, the route up Church Mountain starts deceptively easy with a 0.5 - mile stroll up an old forest road.Then it gets right down to business with lots of switchbacks winding up and around the west side of the mountain.The trees are fairly dense, which you'll actually appreciate on warmer days, though they obstruct any big views until later—look for the occasional peek of Mount Baker above or the North Fork Nooksack River below as you continue to climb. At 3 miles, the trail finally eases its grade and opens up into sprawling meadows.This is your first chance to glance back at the spectacular view of Mount Baker. As you meander through the meadow, you will not see any of those notable golden larch trees, but the vibrant fall colors brought out by the abundance of huckleberry bushes that blanket the meadow and the ridge above in hues of green, red, purple and gold.",
                    PassRequired = true,
                    Biking = false,
                    Fishing = false,
                    Camping = false,
                    Horses = false,
                    Lakes = false,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = true,
                    Bears = true,
                    Cougars = true,
                    Rating = 4,
                    OpenSeason = "Closed",
                    Latitude = 48.9123,
                    Longitude = -121.8578,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "John Wayne Trail - Army West",
                    Map = "",
                    Image = "",
                    Distance = 8.0m,
                    Time = 4.0m,
                    Location = "Central Washington, Yakima",
                    Elevation = "Gain: 500 ft. ",
                    DifficultyLevel = 2,
                    Overview = "A sign-in permit is required due to the fact that the trail passes through the highly active U.S. Army's Yakima Training Center. You must not leave the trail.",
                    PassRequired = true,
                    Biking = false,
                    Fishing = false,
                    Camping = false,
                    Horses = false,
                    Lakes = false,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = false,
                    Bears = true,
                    Cougars = true,
                    Rating = 1,
                    OpenSeason = "Closed",
                    Latitude = 46.9595,
                    Longitude = -120.2952,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Hoodoo Canyon",
                    Map = "",
                    Image = "",
                    Distance = 6.5m,
                    Time = 3.0m,
                    Location = "Eastern Washington, Okanogan Highlands/Kettle River Range",
                    Elevation = "Gain: 1430 ft. Highest Point 3740 ft.",
                    DifficultyLevel = 1,
                    Overview = "The hike up Hoodoo Canyon from Trout Lake to Emerald Lake is a classic, low-elevation Inland Northwest hike through one of the largest remaining low-elevation roadless areas in the Kettle Range.",
                    PassRequired = false,
                    Biking = false,
                    Fishing = false,
                    Camping = true,
                    Horses = false,
                    Lakes = true,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = false,
                    Bears = false,
                    Cougars = false,
                    Rating = 2,
                    OpenSeason = "Open",
                    Latitude = 48.6242,
                    Longitude = -118.2398,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Big Rock",
                    Map = "",
                    Image = "",
                    Distance = 2.5m,
                    Time = 1.5m,
                    Location = "Eastern Washington, Spokane Area/Coeur d'Alene",
                    Elevation = "Gain: 600 ft. Highest Point: 3500 ft.",
                    DifficultyLevel = 1,
                    Overview = "From the Steven's Creek parking lot, head up the road to the right. Follow the old road for a bit less than half a mile to where you reach an opening.",
                    PassRequired = false,
                    Biking = false,
                    Fishing = false,
                    Camping = false,
                    Horses = false,
                    Lakes = false,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = true,
                    Bears = true,
                    Cougars = true,
                    Rating = 3,
                    OpenSeason = "Open",
                    Latitude = 47.5720,
                    Longitude = -117.2897,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Amber Lake",
                    Map = "",
                    Image = "",
                    Distance = 15.0m,
                    Time = 9.5m,
                    Location = "Eastern Washington, Spokane Area/Coeur d'Alene",
                    Elevation = "Gain: 200 ft. Highest Point: 2300 ft.",
                    DifficultyLevel = 2,
                    Overview = " For a longer day hike, start at the popular angling waters of Amber Lake, amble north through aspens and plateau shrubs—dogwood, sumac and currant. In contrast to much of the rest of its length, the Columbia Plateau Trail here passes through the ponderosa pine belt of Eastern Washington; these spicy-scented evergreens provide cover for mule deer and a large population of elk.",
                    PassRequired = true,
                    Biking = false,
                    Fishing = false,
                    Camping = false,
                    Horses = false,
                    Lakes = true,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = false,
                    Bears = true,
                    Cougars = true,
                    Rating = 5,
                    OpenSeason = "Open",
                    Latitude = 47.3512,
                    Longitude = -117.7106,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Similkameen Trail",
                    Map = "",
                    Image = "",
                    Distance = 7.0m,
                    Time = 5.5m,
                    Location = "Eastern Washington, Okanogan Highlands/Kettle River Range",
                    Elevation = "Gain: 40 ft. Highest Point: 940 ft.",
                    DifficultyLevel = 3,
                    Overview = "The trail follows the Similkameen River into the river gorge for incredible views. A 375-foot bridge is 86 feet above the river and provides excellent viewing for salmon and steelhead runs.",
                    PassRequired = false,
                    Biking = false,
                    Fishing = false,
                    Camping = false,
                    Horses = false,
                    Lakes = false,
                    Rivers = true,
                    Waterfalls = true,
                    Lookouts = true,
                    Bears = true,
                    Cougars = true,
                    Rating = 5,
                    OpenSeason = "Closed",
                    Latitude = 48.9390,
                    Longitude = -119.4430,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Wapaloosie Mountain",
                    Map = "",
                    Image = "",
                    Distance = 75.0m,
                    Time = 3.5m,
                    Location = "Eastern Washington, Okanogan Highlands/Kettle River Range",
                    Elevation = "Gain: 1850 ft. Highest Point: 6850 ft.",
                    DifficultyLevel = 3,
                    Overview = "Don’t let the lower portion fool you – the monotonous lodgepole pine forest gives way to huge open spaces up above, with a tremendous flower explosion in early summer.",
                    PassRequired = false,
                    Biking = false,
                    Fishing = false,
                    Camping = true,
                    Horses = false,
                    Lakes = false,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = true,
                    Bears = false,
                    Cougars = false,
                    Rating = 3,
                    OpenSeason = "Open",
                    Latitude = 48.6751,
                    Longitude = -118.5005,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Pend Oreille County Park",
                    Map = "",
                    Image = "",
                    Distance = 7.0m,
                    Time = 4.5m,
                    Location = "Eastern Washington, Spokane Area/Coeur d'Alene",
                    Elevation = "",
                    DifficultyLevel = 3,
                    Overview = "Before you go, visit the Pend Oreille county website at and print a hard copy of the trail system, as on-site signage is poor.",
                    PassRequired = false,
                    Biking = false,
                    Fishing = false,
                    Camping = false,
                    Horses = false,
                    Lakes = false,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = true,
                    Bears = true,
                    Cougars = true,
                    Rating = 4,
                    OpenSeason = "Open",
                    Latitude = 48.0808,
                    Longitude = -117.3240,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Liberty Lake Regional Park",
                    Map = "",
                    Image = "",
                    Distance = 8.0m,
                    Time = 4.5m,
                    Location = "Eastern Washington, Spokane Area/Coeur d'Alene",
                    Elevation = "",
                    DifficultyLevel = 3,
                    Overview = "This hike is best completed in a clockwise direction. Follow the valley floor for two miles and cross Liberty Creek twice on foot bridges before reaching the cedar grove. ",
                    PassRequired = false,
                    Biking = false,
                    Fishing = false,
                    Camping = false,
                    Horses = false,
                    Lakes = false,
                    Rivers = false,
                    Waterfalls = true,
                    Lookouts = true,
                    Bears = true,
                    Cougars = true,
                    Rating = 4,
                    OpenSeason = "Closed",
                    Latitude = 47.6105,
                    Longitude = -117.0409,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Big Four Ice Caves Snowshoe",
                    Map = "",
                    Image = "",
                    Distance = 7.0m,
                    Time = 5.5m,
                    Location = "North Cascades, Mountain Loop Highway",
                    Elevation = "Gain: 250 ft. Highest Point: 1800 ft.",
                    DifficultyLevel = 3,
                    Overview = "Leave the parking area and trek up the snowbound Mountain Loop Highway as it follows the Stillaguamish River upstream. The road is lined with towering cedar and fir trees--many of which sport long, flowing beards of green.",
                    PassRequired = true,
                    Biking = false,
                    Fishing = false,
                    Camping = false,
                    Horses = false,
                    Lakes = false,
                    Rivers = true,
                    Waterfalls = false,
                    Lookouts = true,
                    Bears = false,
                    Cougars = false,
                    Rating = 3,
                    OpenSeason = "Closed",
                    Latitude = 48.0651,
                    Longitude = -121.5068,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Big Four Ice Caves",
                    Map = "",
                    Image = "",
                    Distance = 2.2m,
                    Time = 1.5m,
                    Location = "North Cascades, Mountain Loop Highway",
                    Elevation = "Gain: 220 ft. Highest Point: 1938 ft.",
                    DifficultyLevel = 3,
                    Overview = "Start at the trailhead parking lot and follow the paved pathway through the woods. Marvel at a large stump laying on its side, roots facing the trail. Soon you will come to an intersection.",
                    PassRequired = true,
                    Biking = false,
                    Fishing = false,
                    Camping = false,
                    Horses = false,
                    Lakes = false,
                    Rivers = true,
                    Waterfalls = true,
                    Lookouts = true,
                    Bears = false,
                    Cougars = false,
                    Rating = 4,
                    OpenSeason = "Closed",
                    Latitude = 48.0659,
                    Longitude = -121.5107,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                },
                new Trail
                {
                    BackgroundImage = "",
                    Name = "Quartzite Mountain",
                    Map = "",
                    Image = "",
                    Distance = 3.0m,
                    Time = 1.5m,
                    Location = "Eastern Washington, Selkirk Range",
                    Elevation = "Highest Point 3714 ft.",
                    DifficultyLevel = 1,
                    Overview = "Wild strawberries ripen in the summer all along the trail, along with lupine blooming. The trail is clearly maintained and easy to follow.",
                    PassRequired = false,
                    Biking = false,
                    Fishing = false,
                    Camping = false,
                    Horses = false,
                    Lakes = false,
                    Rivers = false,
                    Waterfalls = false,
                    Lookouts = true,
                    Bears = false,
                    Cougars = false,
                    Rating = 4,
                    OpenSeason = "Open",
                    Latitude = 48.2738,
                    Longitude = -117.6562,
                    RatingList = new List<TrailRating>
                    {
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new TrailRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    BeautyRating = new List<BeautyRating>
                    {
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new BeautyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    FamilyRating = new List<FamilyRating>
                    {
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        },
                        new FamilyRating
                        {
                            UserId = userIdList[rnd.Next(userIdList.Count)],
                            Rating = rnd.Next(1, 5)
                        }
                    },
                    TrailComments = new List<TrailComment>
                    {
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        },
                        new TrailComment
                        {
                            CreationDate = DateTime.Now,
                            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum quis gravida ligula. Praesent eros diam, fringilla vel lacinia sit amet, porta at magna. Suspendisse quis ullamcorper ante. Morbi eu velit tempus, lobortis metus at, accumsan ligula. Pellentesque sed magna a nibh elementum venenatis.",
                            UserID = userIdList[rnd.Next(userIdList.Count)],
                        }
                    }
                }
                );



                db.SaveChanges();
            }

            //var trails = db.Trails.ToList();
            //Random rnd = new Random();

            //var trl = trails[rnd.Next(trails.Count)];

            //foreach (var trail in trails)
            //{

            //}

        }
    }
}
