/*
    Taitoluistelun tähtiarviointi
    Copyright(C) 2016 Jussi Palo, jussi@jussipalo.com

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.If not, see<http://www.gnu.org/licenses/>.
*/

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