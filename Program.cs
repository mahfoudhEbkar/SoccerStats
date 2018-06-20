using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;



namespace SoccerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            //DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            //var fileName = Path.Combine(currentDirectory, "SoccerGameResults.csv");

            var fileName = Path.Combine(currentDirectory, "players.json");
            
            var jsonFileContents = DeserializePlayer(fileName);
            //var fileContents = ReadResults(fileName);
            SerializePlayers(jsonFileContents, @"C:\Users\mebkar\source\repos\SoccerStats\SoccerStats");
            var topTenPlayers = GetTopTenPlayers(jsonFileContents);

            foreach (var player in topTenPlayers)
            {

                Console.WriteLine("Name: "+ player.firstName + " points per game: " + player.pointsPerGame);

            }


            //foreach (var lines in fileContents)
            //{
            //    Console.WriteLine("\n");
            //    foreach (var line in lines)
            //    {
            //        Console.Write(line);
            //    }
            //}

            //var file  = new FileInfo(fileName);

            //if (file.Exists)
            //{
            //using (var reader = new StreamReader(file.FullName))
            //{
            //  Console.SetIn(reader);
            // Console.WriteLine(Console.ReadLine());

            //reader.Close();
            //}
            //string[] result = ReadFile(file.FullName).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (var line in result)
            //{
            //    Console.WriteLine(line);

            //}
            //string[] result
            //}
        }

        public static string ReadFile(string fileName)
        {  
            {
                //Classes such as Stream, StreamReader, StreamWriter etc implements IDisposable
                using (var reader = new StreamReader(fileName))
                {
                    return reader.ReadToEnd();
                }  
            }    
        }

        public static List<GameResult> ReadResults(string fileName)
        {
            var soccerResults = new List<GameResult>();
            using (var reader = new StreamReader(fileName))
            {
                //while((reader.ReadLine()) != null )
                reader.Peek();
                while (reader.Peek() > -1)
                {
                    var gameResult = new GameResult();
                    string[] values = reader.ReadLine().Split(',');

                    //gameResult.GameDate = DateTime.Parse(values[0]);
                    DateTime gameDate;

                    if(DateTime.TryParse(values[0], out gameDate))
                    {
                        gameResult.GameDate = gameDate;
                    }

                    gameResult.TeamName = values[1];

                    HomeOrAway homeOrAway;
                    if (Enum.TryParse(values[2], out homeOrAway))
                    {
                        gameResult.HomeOrAway = homeOrAway;
                    }

                    int parseInt;
                    if(int.TryParse(values[3], out parseInt))
                    {
                        gameResult.Goals = parseInt;
                    }
                   
                    if(int.TryParse(values[4], out parseInt))
                    {
                        gameResult.GoalAttempts = parseInt;
                    }
                     
                    if(int.TryParse(values[5], out parseInt))
                    {
                        gameResult.ShotsOffGoal = parseInt;
                    }
                     
                    if(int.TryParse(values[6], out parseInt))
                    {
                        gameResult.ShotsOnGoal = parseInt;
                    }

                    double parseDouble;
                    if (double.TryParse(values[7], out parseDouble))
                    {
                        gameResult.PosessionPercent = parseDouble;
                    }

                    soccerResults.Add(gameResult);
                }
            }
            return soccerResults;
        }

        public static List<Player> DeserializePlayer(string fileName)
        {
            var players = new List<Player>();
            var serializer = new JsonSerializer();

            using (var streamReader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                players = serializer.Deserialize<List<Player>>(jsonReader);
            }
                
            return players;
        }

        public static void SerializePlayers(List<Player> players, string currentDirectory)
        {
            var serializer = new JsonSerializer();
            var fileName = Path.Combine(currentDirectory, "players_new.json");
            using (var streamWriter = new StreamWriter(fileName))
            using (JsonWriter writer = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(writer, players);
            }
        }

        public static List<Player> GetTopTenPlayers(List<Player> players)
        {
            var topTenPlayers = new List<Player>();
            players.Sort(new PlayerComparer());

            var counter = 0;
            foreach (var player in players)
            {
                topTenPlayers.Add(player);
                counter++;
                if(counter == 10)
                {
                    break;
                }
            }
            
            return topTenPlayers;
        }
    }
}
