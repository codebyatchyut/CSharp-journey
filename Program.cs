using ConsoleApp2.Models;
using ConsoleApp2.Data;



namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Computer c1 = new Computer{
                Motherboard = "ASUS ROG Strix Z590-E",
                CPUCores = 8,
                HasWifi = true,
                ReleaseDate = new DateTime(2021, 5, 15),
                Price = 699.99m,
                VideoCard = "NVIDIA GeForce RTX 3080"
            };

            DataContextDapper dataContext = new DataContextDapper();
            DataContextEF dataContextEF = new DataContextEF();

            // Inserting data using Dapper
            //string insertSqlCommand = $@"
            //    INSERT INTO MyAppSchema.computer (Motherboard, CPUCores, HasWifi, ReleaseDate, Price, VideoCard)
            //    VALUES ('{c1.Motherboard}', {c1.CPUCores}, {(c1.HasWifi ? 1 : 0)}, '{c1.ReleaseDate:yyyy-MM-dd}', {c1.Price}, '{c1.VideoCard}' )
            //";

            //int rowsInserted = dataContext.ExecuteWithCount(insertSqlCommand);
            //Console.WriteLine("Rows inserted: " + rowsInserted);

            // Retrieving data using Dapper
            string selectSqlCommand = "SELECT * FROM MyAppSchema.computer";
            List<Computer> computers = dataContext.LoadData<Computer>(selectSqlCommand).ToList();

            foreach(var computer in computers)
            {
                Console.WriteLine($"ID: {computer.ComputerId}, Motherboard: {computer.Motherboard}, CPU Cores: {computer.CPUCores}, Has Wifi: {computer.HasWifi}, Release Date: {computer.ReleaseDate.ToShortDateString()}, Price: {computer.Price}, Video Card: {computer.VideoCard}");
            }

            // Inserting data using Entity Framework
            dataContextEF.Add(c1);
            dataContextEF.SaveChanges();

            IEnumerable<Computer> computersEF = dataContextEF.Set<Computer>().ToList();

        }
    }
}