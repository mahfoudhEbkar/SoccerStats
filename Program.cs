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

        public static List<string[]> ReadResults(string fileName)
        {
            var soccerResults = new List<string[]>();
            using (var reader = new StreamReader(fileName))
            {
                //while((reader.ReadLine()) != null )
                while (reader.Peek() > -1)
                {
                    soccerResults.Add(reader.ReadLine().Split(','));
                }
            }
            return soccerResults;
        }
    }
}
