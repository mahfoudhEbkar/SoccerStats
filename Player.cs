using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerStats
{

    public class RootObject
    {
        public Player[] player { get; set; }
    }

    public class Player
    {
        //You could decorate the property you wish controlling
        //its name with the[JsonProperty] attribute
        //which allows you to specify a different name:
        [JsonProperty(PropertyName = "first_name")]
        public string firstName { get; set; }
        public int id { get; set; }
        [JsonProperty(PropertyName = "points_per_game")]
        public double pointsPerGame { get; set; }
        [JsonProperty(PropertyName = "second_name")]
        public string lastName { get; set; }
        [JsonProperty(PropertyName = "team_name")]
        public string teamName { get; set; }
    }

}
