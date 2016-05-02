using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Hiking.Models;

namespace Hiking.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160502205159_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hiking.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("Age");

                    b.Property<string>("Bio");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("Expertise");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePic");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Hiking.Models.BeautyRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Rating");

                    b.Property<int?>("TrailId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hiking.Models.Blog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Message");

                    b.Property<string>("Title");

                    b.Property<string>("UserID");

                    b.Property<int>("Views");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hiking.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BlogID");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Message");

                    b.Property<int?>("TrailId");

                    b.Property<string>("UserID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hiking.Models.CompletedTrail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Name");

                    b.Property<string>("TrailImage");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hiking.Models.FamilyRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Rating");

                    b.Property<int?>("TrailId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hiking.Models.Gathering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerId");

                    b.Property<DateTime>("Time");

                    b.Property<int>("TrailId");

                    b.Property<string>("TrailName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hiking.Models.GatheringUsers", b =>
                {
                    b.Property<int>("GatheringID");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("GatheringID", "ApplicationUserId");
                });

            modelBuilder.Entity("Hiking.Models.Trail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BackgroundImage");

                    b.Property<bool>("Bears");

                    b.Property<decimal>("BeautyRate");

                    b.Property<bool>("Biking");

                    b.Property<bool>("Camping");

                    b.Property<bool>("Cougars");

                    b.Property<decimal>("DifficultyLevel");

                    b.Property<decimal>("Distance");

                    b.Property<string>("Elevation");

                    b.Property<decimal>("FamilyRate");

                    b.Property<bool>("Fishing");

                    b.Property<bool>("Horses");

                    b.Property<string>("Image");

                    b.Property<bool>("Lakes");

                    b.Property<double>("Latitude");

                    b.Property<string>("Location");

                    b.Property<double>("Longitude");

                    b.Property<bool>("Lookouts");

                    b.Property<string>("Map");

                    b.Property<bool>("MyProperty");

                    b.Property<string>("Name");

                    b.Property<string>("OpenSeason");

                    b.Property<string>("Overview");

                    b.Property<bool>("PassRequired");

                    b.Property<int>("Rating");

                    b.Property<bool>("Rivers");

                    b.Property<decimal>("Time");

                    b.Property<bool>("Waterfalls");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hiking.Models.TrailComment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Message");

                    b.Property<int?>("TrailId");

                    b.Property<string>("UserID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hiking.Models.TrailRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Rating");

                    b.Property<int?>("TrailId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hiking.Models.UserTrail", b =>
                {
                    b.Property<int>("TrailId");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("TrailId", "ApplicationUserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("Hiking.Models.BeautyRating", b =>
                {
                    b.HasOne("Hiking.Models.Trail")
                        .WithMany()
                        .HasForeignKey("TrailId");
                });

            modelBuilder.Entity("Hiking.Models.Comment", b =>
                {
                    b.HasOne("Hiking.Models.Blog")
                        .WithMany()
                        .HasForeignKey("BlogID");

                    b.HasOne("Hiking.Models.Trail")
                        .WithMany()
                        .HasForeignKey("TrailId");
                });

            modelBuilder.Entity("Hiking.Models.CompletedTrail", b =>
                {
                    b.HasOne("Hiking.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Hiking.Models.FamilyRating", b =>
                {
                    b.HasOne("Hiking.Models.Trail")
                        .WithMany()
                        .HasForeignKey("TrailId");
                });

            modelBuilder.Entity("Hiking.Models.Gathering", b =>
                {
                    b.HasOne("Hiking.Models.Trail")
                        .WithMany()
                        .HasForeignKey("TrailId");
                });

            modelBuilder.Entity("Hiking.Models.GatheringUsers", b =>
                {
                    b.HasOne("Hiking.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Hiking.Models.Gathering")
                        .WithMany()
                        .HasForeignKey("GatheringID");
                });

            modelBuilder.Entity("Hiking.Models.TrailComment", b =>
                {
                    b.HasOne("Hiking.Models.Trail")
                        .WithMany()
                        .HasForeignKey("TrailId");
                });

            modelBuilder.Entity("Hiking.Models.TrailRating", b =>
                {
                    b.HasOne("Hiking.Models.Trail")
                        .WithMany()
                        .HasForeignKey("TrailId");
                });

            modelBuilder.Entity("Hiking.Models.UserTrail", b =>
                {
                    b.HasOne("Hiking.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Hiking.Models.Trail")
                        .WithMany()
                        .HasForeignKey("TrailId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Hiking.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Hiking.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Hiking.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
