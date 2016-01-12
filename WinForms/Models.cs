using System.Collections.Generic;

namespace com.jussipalo.tahti
{
    public class Skater
    {
        public Skater()
        {
            PointsJudge1 = new List<int>();
            PointsJudge2 = new List<int>();
            PointsJudge3 = new List<int>();
            AveragePointsPerArea = new List<decimal>();
            CircledPoints = new List<int>();
            Deductions = new List<decimal>();
            Mention = "";
        }
        
        public string Name { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }
        public decimal TotalPoints { get; set; }
        public List<int> PointsJudge1 { get; set; }
        public List<int> PointsJudge2 { get; set; }
        public List<int> PointsJudge3 { get; set; }
        public List<decimal> AveragePointsPerArea { get; set; }
        public List<int> CircledPoints { get; set; }
        public List<decimal> Deductions { get; set; }
        public string Mention { get; set; }
    }

    public class Event
    {
        public Event()
        {
            Skaters = new List<Skater>();
        }
        public string NameAndSeries { get; set; }
        public string TimeAndPlace { get; set; }
        public string Type { get; set; }
        public List<Skater> Skaters { get; set; }
    }
}