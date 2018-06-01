using System;
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
            var file  = new FileInfo(fileName);

            if (file.Exists)
            {
                //using (var reader = new StreamReader(file.FullName))
                //{
                //  Console.SetIn(reader);
                // Console.WriteLine(Console.ReadLine());

                //reader.Close();
                //}
                string[] result = ReadFile(file.FullName).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in result)
                {
                    Console.WriteLine(line);
                    //Console.WriteLine("Spaaaaaaaaaaaaace");

                }//Console.ReadLine();
            }

            
        
        }

        public static string ReadFile(string fileName)
        {
             
            {
                using (var reader = new StreamReader(fileName))
                {
                    return reader.ReadToEnd();
                }  
            }
             
        }
    }
}
