using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Hiking.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Trail> Trails { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<TrailComment> TrailComments { get; set; }
        public DbSet<Gathering> Gatherings { get; set; }
        public DbSet<GatheringUsers> GatheringUsers { get; set; }
        public DbSet<BeautyRating> BeautyRatings { get; set; }
        public DbSet<FamilyRating> FamilyRatings { get; set; }
        public DbSet<TrailRating> TrailRatings { get; set; }
        public DbSet<UserTrail> UserTrails { get; set; }
        public DbSet<CompletedTrail> CompletedTrails { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<UserTrail>().HasKey(x => new { x.TrailId, x.ApplicationUserId });


            builder.Entity<GatheringUsers>().HasKey(x => new { x.GatheringID, x.ApplicationUserId });

            //builder.Entity<UserTrail>().HasKey(x => new { x.TrailID, x.UserID });

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
