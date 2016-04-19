using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hiking.Models
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            context.Database.Migrate();

            // Ensure Sarah (isAdmin)
            var sarah = await userManager.FindByNameAsync("Sarah@CoderCamps.com");
            if (sarah == null)
            {
                // create user
                sarah = new ApplicationUser
                {
                    UserName = "Sarah@CoderCamps.com",
                    Email = "Sarah@CoderCamps.com",
                    FirstName = "Sarah",
                    LastName = "Andrea",
                    Age = 26,
                    ProfilePic = "http://images.nationalgeographic.com/wpf/media-live/photos/000/707/overrides/alberta-canada-hiking-bugaboos_70729_600x450.jpg",
                    Expertise = 1,
                    Bio = "Love the outside.",
                    DisplayName = "HelloKitty"
                };
                await userManager.CreateAsync(sarah, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(sarah, new Claim("IsAdmin", "true"));
            }

            // Ensure Nathan (isAdmin)
            var nathan = await userManager.FindByNameAsync("Nathan@CoderCamps.com");
            if (nathan == null)
            {
                // create user
                nathan = new ApplicationUser
                {
                    UserName = "Nathan@CoderCamps.com",
                    Email = "Nathan@CoderCamps.com",
                    FirstName = "Nathan",
                    LastName = "Gordon",
                    Age = 28,
                    ProfilePic = "http://images.nationalgeographic.com/wpf/media-live/photos/000/707/overrides/alberta-canada-hiking-bugaboos_70729_600x450.jpg",
                    Expertise = 1,
                    Bio = "Love the outside.",
                    DisplayName = "Grizzly"

                };
                await userManager.CreateAsync(nathan, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(nathan, new Claim("IsAdmin", "true"));
            }

            //// Ensure Mike (isAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com",
                    FirstName = "Mike",
                    LastName = "Ganey",
                    Age = 28,
                    ProfilePic = "http://images.nationalgeographic.com/wpf/media-live/photos/000/707/overrides/alberta-canada-hiking-bugaboos_70729_600x450.jpg",
                    Expertise = 1,
                    Bio = "Love the outside.",
                    DisplayName = "Trekker"
                };
                await userManager.CreateAsync(mike, "Secret123!");

                //    // add claims
                await userManager.AddClaimAsync(mike, new Claim("IsAdmin", "true"));
            }


            //// Ensure Mandy (IsAdmin)
            var mandy = await userManager.FindByNameAsync("Mandy.hawn@yahoo.com");
            if (mandy == null)
            {
                // create user
                mandy = new ApplicationUser
                {
                    UserName = "Mandy.hawn@yahoo.com",
                    Email = "Mandy.hawn@yahoo.com",
                    FirstName = "Mandy",
                    LastName = "Hawn",
                    Age = 39,
                    ProfilePic = "http://images.nationalgeographic.com/wpf/media-live/photos/000/707/overrides/alberta-canada-hiking-bugaboos_70729_600x450.jpg",
                    Expertise = 1,
                    Bio = "Love the outside.",
                    DisplayName = "ArcherMadden"
                };
                await userManager.CreateAsync(mandy, "Secret123!");

                //    // add claims
                await userManager.AddClaimAsync(mandy, new Claim("IsAdmin", "true"));
            }

            ////Ensure Michael (isAdmin)
            var michael = await userManager.FindByNameAsync("michael@codercamps.com");
            if (michael == null)
            {
                // create user
                michael = new ApplicationUser
                {
                    UserName = "michael@codercamps.com",
                    Email = "michael@codercamps.com",
                    FirstName = "Michael",
                    LastName = "Graden",
                    Age = 28,
                    ProfilePic = "http://images.nationalgeographic.com/wpf/media-live/photos/000/707/overrides/alberta-canada-hiking-bugaboos_70729_600x450.jpg",
                    Expertise = 1,
                    Bio = "love the outside.",
                    DisplayName = "PolarBear"
                };
                await userManager.CreateAsync(michael, "Secret123!");

                //    // add claims
                await userManager.AddClaimAsync(michael, new Claim("IsAdmin", "true"));
            }

            // Ensure Kris (not IsAdmin)
            var kris = await userManager.FindByNameAsync("Kris@CoderCamps.com");
            if (kris == null)
            {
                // create user
                kris = new ApplicationUser
                {
                    UserName = "Kris@CoderCamps.com",
                    Email = "Kris@CoderCamps.com",
                    FirstName = "Kris",
                    LastName = "Lane",
                    Age = 35,
                    ProfilePic = "http://www.active.com/Assets/Outdoors/hiking-checklist-460.jpg",
                    Expertise = 3,
                    Bio = "I love rock climbing, trail biking, and pretty much anything outdoors!",
                    DisplayName = "PoisonIvy"

                };
                await userManager.CreateAsync(kris, "Secret123!");
            }

            // ALICE GOODING (not IsAdmin)
            var alice = await userManager.FindByNameAsync("Alice@CoderCamps.com");
            if (alice == null)
            {
                // create user
                alice = new ApplicationUser
                {
                    UserName = "Alice@CoderCamps.com",
                    Email = "Alice@CoderCamps.com",
                    FirstName = "Alice",
                    LastName = "Gooding",
                    Age = 34,
                    ProfilePic = "http://cdn2-www.liveoutdoors.com/assets/uploads/2015/08/hiking-girl.jpg",
                    Expertise = 1,
                    Bio = "The mountains are calling and I must go.",
                    DisplayName = "Petals"
                };
                await userManager.CreateAsync(alice, "Secret123!");
            }

            // DON WHITMAN  (not IsAdmin)
            var don = await userManager.FindByNameAsync("Don@CoderCamps.com");
            if (don == null)
            {
                // create user
                don = new ApplicationUser
                {
                    UserName = "Don@CoderCamps.com",
                    Email = "Don@CoderCamps.com",
                    FirstName = "Don",
                    LastName = "Whitman",
                    Age = 45,
                    ProfilePic = "http://i1.wp.com/socalhiker.net/wp-content/uploads/jeff-at-starlight-beach_Snapseed.jpg",
                    Expertise = 1,
                    Bio = "I never feel as close to God as I do when I'm in nature.",
                    DisplayName = "Zamboni"

                };
                await userManager.CreateAsync(don, "Secret123!");
            }

            // JOYCE HOWARD  (not IsAdmin)
            var joyce = await userManager.FindByNameAsync("Joyce@CoderCamps.com");
            if (joyce == null)
            {
                // create user
                joyce = new ApplicationUser
                {
                    UserName = "Joyce@CoderCamps.com",
                    Email = "Joyce@CoderCamps.com",
                    FirstName = "Joyce",
                    LastName = "Howard",
                    Age = 52,
                    ProfilePic = "https://ericmurtaugh.files.wordpress.com/2011/12/jnb-near-mt-jefferson-oregon.jpg",
                    Expertise = 3,
                    Bio = "I took the path less traveled.",
                    DisplayName = "Rollyerown"
                };
                await userManager.CreateAsync(joyce, "Secret123!");
            }

            // MARCUS DIFRANCO  (not IsAdmin)
            var marcus = await userManager.FindByNameAsync("Marcus@CoderCamps.com");
            if (marcus == null)
            {
                // create user
                marcus = new ApplicationUser
                {
                    UserName = "Marcus@CoderCamps.com",
                    Email = "Marcus@CoderCamps.com",
                    FirstName = "Marcus",
                    LastName = "DiFranco",
                    Age = 32,
                    ProfilePic = "http://yashaswihimalayas.com/wp-content/uploads/2014/11/maiktoli-800x333.jpg",
                    Expertise = 3,
                    Bio = "GO OUTSIDE!!!",
                    DisplayName = "Mumble"
                };
                await userManager.CreateAsync(marcus, "Secret123!");
            }

            // ERIC DILLINGHAM  (not IsAdmin)
            var eric = await userManager.FindByNameAsync("Eric@CoderCamps.com");
            if (eric == null)
            {
                // create user
                eric = new ApplicationUser
                {
                    UserName = "Eric@CoderCamps.com",
                    Email = "Eric@CoderCamps.com",
                    FirstName = "Eric",
                    LastName = "Dillingham",
                    Age = 40,
                    ProfilePic = "http://yashaswihimalayas.com/wp-content/uploads/2014/11/maiktoli-800x333.jpg",
                    Expertise = 1,
                    Bio = "I'm a photographer, and I enjoy taking photos of Nature. Is there anything better in life?",
                    DisplayName = "RainDance"

                };
                await userManager.CreateAsync(eric, "Secret123!");

                //SAVANNAH O'QUINN  (not IsAdmin)
                var savannah = await userManager.FindByNameAsync("Savannah@CoderCamps.com");
                if (savannah == null)
                {
                    // create user
                    savannah = new ApplicationUser
                    {
                        UserName = "Savannah@CoderCamps.com",
                        Email = "Savannah@CoderCamps.com",
                        FirstName = "Savannah",
                        LastName = "O'Quinn",
                        Age = 23,
                        ProfilePic = "http://media.backpacker.com/wp-content/uploads/2015/03/Hike-your-own-hike-4_BriannaGraves.jpg",
                        Expertise = 2,
                        Bio = "I'm a web designer. I enjoy coffee, hiking my ass off, and being with my besties.",
                        DisplayName = "Sunshine"
                    };
                    await userManager.CreateAsync(savannah, "Secret123!");
                }

            }

        }
    }
}
