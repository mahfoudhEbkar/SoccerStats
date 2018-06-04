using System;
using System.Collections.Generic;
using System.IO;



namespace SoccerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            //DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(currentDirectory, "SoccerGameResults.csv");
            var fileContents = ReadResults(fileName);

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
                    soccerResults.Add(gameResult);
                }
            }
            return soccerResults;
        }
    }
}
