using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Models
{
    public class Trail
    {
        public int Id { get; set; }
        public string BackgroundImage { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public string Image { get; set; }
        public decimal Distance { get; set; }
        public decimal Time { get; set; }
        public string Location { get; set; }
        public string Elevation { get; set; }
        public decimal DifficultyLevel { get; set; }
        public string Overview { get; set; }
        public bool PassRequired { get; set; }
        public bool Biking { get; set; }
        public bool Fishing { get; set; }
        public bool Camping { get; set; }
        public bool Horses { get; set; }
        public bool MyProperty { get; set; }
        public bool Lakes { get; set; }
        public bool Rivers { get; set; }
        public bool Waterfalls { get; set; }
        public bool Lookouts { get; set; }
        public bool Bears { get; set; }
        public bool Cougars { get; set; }
        public int Rating { get; set; }
        public decimal BeautyRate { get; set; }
        public decimal FamilyRate { get; set; }
        public string OpenSeason { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<TrailComment> TrailComments { get; set; }
        public ICollection<Gathering> Gatherings { get; set; }
        public ICollection<TrailRating> RatingList { get; set; }
        public ICollection<BeautyRating> BeautyRating { get; set; }
        public ICollection<FamilyRating> FamilyRating { get; set; }
        public ICollection<UserTrail> UserTrails { get; set; }
    }
}
