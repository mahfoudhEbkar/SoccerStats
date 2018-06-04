using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerStats
{
    public class GameResult
    {
        public DateTime GameDate { get; set; }
        public string TeamName { get; set; }
        public HomeOrAway HomeOrAway { get; set; }
    }

    public enum HomeOrAway
    {
        Home,
        Away
    }
}
