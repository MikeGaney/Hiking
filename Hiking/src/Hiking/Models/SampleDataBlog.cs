using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Hiking.Models
{
    public class SampleDataBlog
    {
        public static void Initialize(IServiceProvider sp)
        {
            var db = sp.GetService<ApplicationDbContext>();
            var userIdList = db.Users.Select(u => u.Id).ToList();
            Random rnd = new Random();

            if (!db.Blogs.Any())
            {
                db.AddRange(
                    new Blog
                    {
                        Title = "What gloves would you recommend for staying dry?",
                        Message = "With detachable waterproof shells for extra protection, OR’s sleek VersaLiner gloves (6) will be your new favorites. Stash the liners in the zippered pockets or, if it’s extra-chilly, put hand warmer packets in there instead—the pockets are the perfect size. Hanz waterproof gloves (7) are perfect for photographers or anyone who’s had to set up a tent in the rain. Grippy and flexible, their three layer construction keeps your hands dry while giving you the dexterity you need when the weather goes south. $52 /$35",
                        UserID = userIdList[rnd.Next(userIdList.Count)],
                        Comments = new List<Comment>
                        {
                            new Comment {
                                Message = "ok... my experience is different. i took it on jmt last summer. only 2 days of light precip. but it handled that for me. plus it also helped keep heat in on cold nights at freezing. it gave me wind and solar protection too. i can recommend if showers are a possibility... especially on just day hikes. it dried fast and it's lightweight if you are counting grams like i did that trip. i wore it every day for a month. that said, it seems to hold onto a special smell even after a couple washings... oh well.. keeps bears away at night i suppose.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                            new Comment {
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur posuere nibh velit, in tincidunt nibh dapibus et. Vestibulum rutrum, justo sed ullamcorper vulputate, enim massa consequat neque, sit amet vehicula ex mauris id elit. Mauris id mauris eget sapien sagittis finibus. Nam risus magna, sagittis nec urna in, iaculis pretium ex. Morbi et posuere orci. Duis placerat viverra felis a maximus. Aliquam pretium ultrices augue, non egestas mi tincidunt at. Phasellus non ex elementum, bibendum risus ac, maximus est. Donec vitae hendrerit ante, sit amet eleifend dui. Aliquam pharetra orci justo, ac lobortis urna vulputate id. Aliquam lectus leo, laoreet.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                            new Comment {
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis eget orci ante. Cras varius leo justo, at ultricies enim facilisis quis. Donec in lectus a erat ultrices sodales. Curabitur lacus nisi, laoreet et fringilla aliquet, eleifend nec velit. Proin bibendum dapibus tellus sit amet facilisis.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            }
                        },
                        CreationDate = DateTime.Now,
                        Views = 5
                    },
                    new Blog
                    {
                        Title = "What Jackets would you recomment for staying dry?",
                        Message = "It’s the number one rule of survival and the easiest way to prevent hypothermia during cold weather hikes. When the temp dips, even a light sprinkle can suck heat from your body. So no matter which side of the state you’re on, precip protection is one of the most important collections in your gear closet—year-round.",
                        UserID = userIdList[rnd.Next(userIdList.Count)],
                        Comments = new List<Comment>
                        {
                            new Comment {
                                Message = "For the info. and suggestions. It was the 1st time I'd ever worn a puffy coat in those conditions (I generally go with fleece over the base layer), and I agree with your assessment - save the puffy for the tent! I was taking it pretty easy that day, so the puffy only got wet on the outside, not the inside. I'm glad the Helium has worked out for your purposes.I agree it's great for keeping heat in, and blocking wind. I didn't notice the smell with mine, go figure. I'm still really happy with the OR Clarivoyant. Isn't it nice when everyone's happy? :) Thanks again for the suggestions, and happy hiking!",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                            new Comment {
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis eget orci ante. Cras varius leo justo, at ultricies enim facilisis quis. Donec in lectus a erat ultrices sodales. Curabitur lacus nisi, laoreet et fringilla aliquet, eleifend nec velit. Proin bibendum dapibus tellus sit amet facilisis.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                            new Comment {
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur posuere nibh velit, in tincidunt nibh dapibus et. Vestibulum rutrum, justo sed ullamcorper vulputate, enim massa consequat neque, sit amet vehicula ex mauris id elit. Mauris id mauris eget sapien sagittis finibus. Nam risus magna, sagittis nec urna in, iaculis pretium ex. Morbi et posuere orci. Duis placerat viverra felis a maximus. Aliquam pretium ultrices augue, non egestas mi tincidunt at. Phasellus non ex elementum, bibendum risus ac, maximus est. Donec vitae hendrerit ante, sit amet eleifend dui. Aliquam pharetra orci justo, ac lobortis urna vulputate id. Aliquam lectus leo, laoreet.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                        },
                        CreationDate = DateTime.Now,
                        Views = 4
                    },
                    new Blog
                    {
                        Title = "What is the best age to start hiking as a kid?",
                        Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent vitae odio felis. Etiam malesuada pharetra nulla in convallis. Donec hendrerit, enim eu interdum pulvinar, lectus turpis semper risus, quis vulputate est sapien at diam. Mauris faucibus, erat et scelerisque volutpat, ligula diam sollicitudin massa, sed pretium eros sem eget justo. Aliquam erat volutpat. Vivamus lobortis, ex vel vehicula blandit, nisl ex bibendum erat, in suscipit urna mi posuere mi. Quisque dictum arcu eu pellentesque ullamcorper. Integer porttitor ultricies hendrerit. Praesent quis luctus augue. Sed accumsan augue at accumsan tristique. Maecenas nulla turpis, viverra eu ligula ut, volutpat tempor neque. Donec condimentum erat vitae magna sollicitudin ornare. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nulla in vulputate libero.",
                        UserID = userIdList[rnd.Next(userIdList.Count)],
                        Comments = new List<Comment>
                        {
                            new Comment {
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur posuere nibh velit, in tincidunt nibh dapibus et. Vestibulum rutrum, justo sed ullamcorper vulputate, enim massa consequat neque, sit amet vehicula ex mauris id elit. Mauris id mauris eget sapien sagittis finibus. Nam risus magna, sagittis nec urna in, iaculis pretium ex. Morbi et posuere orci. Duis placerat viverra felis a maximus. Aliquam pretium ultrices augue, non egestas mi tincidunt at. Phasellus non ex elementum, bibendum risus ac, maximus est. Donec vitae hendrerit ante, sit amet eleifend dui. Aliquam pharetra orci justo, ac lobortis urna vulputate id. Aliquam lectus leo, laoreet.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                            new Comment {
                                Message = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Etiam lobortis, lacus a fringilla scelerisque, ligula eros condimentum leo, eu ultricies dui lorem interdum tellus. Morbi placerat justo ac urna tincidunt, ut lacinia purus volutpat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nam efficitur, purus vel porta varius, leo sem.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                            new Comment {
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis eget orci ante. Cras varius leo justo, at ultricies enim facilisis quis. Donec in lectus a erat ultrices sodales. Curabitur lacus nisi, laoreet et fringilla aliquet, eleifend nec velit. Proin bibendum dapibus tellus sit amet facilisis.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                        },
                        CreationDate = DateTime.Now,
                        Views = 3
                    },
                    new Blog
                    {
                        Title = "What kind of backpack should couples get for overnight backpacking?",
                        Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent vitae odio felis. Etiam malesuada pharetra nulla in convallis. Donec hendrerit, enim eu interdum pulvinar, lectus turpis semper risus, quis vulputate est sapien at diam. Mauris faucibus, erat et scelerisque volutpat, ligula diam sollicitudin massa, sed pretium eros sem eget justo. Aliquam erat volutpat. Vivamus lobortis, ex vel vehicula blandit, nisl ex bibendum erat, in suscipit urna mi posuere mi. Quisque dictum arcu eu pellentesque ullamcorper. ",
                        UserID = userIdList[rnd.Next(userIdList.Count)],
                        Comments = new List<Comment>
                        {
                            new Comment {
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur posuere nibh velit, in tincidunt nibh dapibus et. Vestibulum rutrum, justo sed ullamcorper vulputate, enim massa consequat neque, sit amet vehicula ex mauris id elit. Mauris id mauris eget sapien sagittis finibus. Nam risus magna, sagittis nec urna in, iaculis pretium ex. Morbi et posuere orci. Duis placerat viverra felis a maximus. Aliquam pretium ultrices augue, non egestas mi tincidunt at. Phasellus non ex elementum, bibendum risus ac, maximus est. Donec vitae hendrerit ante, sit amet eleifend dui. Aliquam pharetra orci justo, ac lobortis urna vulputate id. Aliquam lectus leo, laoreet.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                            new Comment {
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis eget orci ante. Cras varius leo justo, at ultricies enim facilisis quis. Donec in lectus a erat ultrices sodales. Curabitur lacus nisi, laoreet et fringilla aliquet, eleifend nec velit. Proin bibendum dapibus tellus sit amet facilisis.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                            new Comment {
                                Message = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Etiam lobortis, lacus a fringilla scelerisque, ligula eros condimentum leo, eu ultricies dui lorem interdum tellus. Morbi placerat justo ac urna tincidunt, ut lacinia purus volutpat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nam efficitur, purus vel porta varius, leo sem.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                        },
                        CreationDate = DateTime.Now,
                        Views = 2
                    },
                    new Blog
                    {
                        Title = "Where can I purchase a discover pass for Washington State Parks?",
                        Message = "Integer porttitor ultricies hendrerit. Praesent quis luctus augue. Sed accumsan augue at accumsan tristique. Maecenas nulla turpis, viverra eu ligula ut, volutpat tempor neque. Donec condimentum erat vitae magna sollicitudin ornare. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nulla in vulputate libero.",
                        UserID = userIdList[rnd.Next(userIdList.Count)],
                        Comments = new List<Comment>
                        {
                            new Comment {
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis eget orci ante. Cras varius leo justo, at ultricies enim facilisis quis. Donec in lectus a erat ultrices sodales. Curabitur lacus nisi, laoreet et fringilla aliquet, eleifend nec velit. Proin bibendum dapibus tellus sit amet facilisis.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                            new Comment {
                                Message = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Etiam lobortis, lacus a fringilla scelerisque, ligula eros condimentum leo, eu ultricies dui lorem interdum tellus. Morbi placerat justo ac urna tincidunt, ut lacinia purus volutpat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nam efficitur, purus vel porta varius, leo sem.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                            new Comment {
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur posuere nibh velit, in tincidunt nibh dapibus et. Vestibulum rutrum, justo sed ullamcorper vulputate, enim massa consequat neque, sit amet vehicula ex mauris id elit. Mauris id mauris eget sapien sagittis finibus. Nam risus magna, sagittis nec urna in, iaculis pretium ex. Morbi et posuere orci. Duis placerat viverra felis a maximus. Aliquam pretium ultrices augue, non egestas mi tincidunt at. Phasellus non ex elementum, bibendum risus ac, maximus est. Donec vitae hendrerit ante, sit amet eleifend dui. Aliquam pharetra orci justo, ac lobortis urna vulputate id. Aliquam lectus leo, laoreet.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                        },
                        CreationDate = DateTime.Now,
                        Views = 1
                    },
                    new Blog
                    {
                        Title = "How can you pack a tent back into the little bag that they come in when they are originally purchased?",
                        Message = "Praesent vitae odio felis. Etiam malesuada pharetra nulla in convallis. Donec hendrerit, enim eu interdum pulvinar, lectus turpis semper risus, quis vulputate est sapien at diam. Mauris faucibus, erat et scelerisque volutpat, ligula diam sollicitudin massa, sed pretium eros sem eget justo. ",
                        UserID = userIdList[rnd.Next(userIdList.Count)],
                        Comments = new List<Comment>
                        {
                            new Comment {
                                Message = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Etiam lobortis, lacus a fringilla scelerisque, ligula eros condimentum leo, eu ultricies dui lorem interdum tellus. Morbi placerat justo ac urna tincidunt, ut lacinia purus volutpat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nam efficitur, purus vel porta varius, leo sem.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                            new Comment {
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur posuere nibh velit, in tincidunt nibh dapibus et. Vestibulum rutrum, justo sed ullamcorper vulputate, enim massa consequat neque, sit amet vehicula ex mauris id elit. Mauris id mauris eget sapien sagittis finibus. Nam risus magna, sagittis nec urna in, iaculis pretium ex. Morbi et posuere orci. Duis placerat viverra felis a maximus. Aliquam pretium ultrices augue, non egestas mi tincidunt at. Phasellus non ex elementum, bibendum risus ac, maximus est. Donec vitae hendrerit ante, sit amet eleifend dui. Aliquam pharetra orci justo, ac lobortis urna vulputate id. Aliquam lectus leo, laoreet.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                            new Comment {
                                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis eget orci ante. Cras varius leo justo, at ultricies enim facilisis quis. Donec in lectus a erat ultrices sodales. Curabitur lacus nisi, laoreet et fringilla aliquet, eleifend nec velit. Proin bibendum dapibus tellus sit amet facilisis.",
                                UserID = userIdList[rnd.Next(userIdList.Count)],
                                CreationDate = DateTime.Now
                            },
                        },
                        CreationDate = DateTime.Now,
                        Views = 0
                    }
                    );
                db.SaveChanges();
            }
        }
    }
}
