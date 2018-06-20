using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerStats
{    
    public class PlayerComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return (x.pointsPerGame.CompareTo(y.pointsPerGame)) * -1 ;
        }
    }
}
