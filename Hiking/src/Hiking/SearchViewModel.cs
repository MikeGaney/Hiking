namespace Hiking.API
{
    public class SearchViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal DifficultyLevel { get; set; }
        public bool Biking { get; set; }
        public bool Fishing { get; set; }
        public bool Camping { get; set; }
        public bool Horses { get; set; }
        public bool Lakes { get; set; }
        public bool Rivers { get; set; }
        public bool Waterfalls { get; set; }
        public bool Lookouts { get; set; }
        public int Rating { get; set; }

    }
}