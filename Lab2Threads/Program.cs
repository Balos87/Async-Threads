using System.Collections.Concurrent;

namespace Lab2Threads
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Console.Out.WriteLineAsync("Lets race!");

            Car car1 = new Car("Volvo");
            Car car2 = new Car("Kia");

            Task car1Race = Task.Run(() => car1.StartRaceAsync());
            Task car2Race = Task.Run(() => car2.StartRaceAsync());

            Task displayRace = DisplayCarPositionsAsync(car1, car2);

            await Task.WhenAny(car1Race, car2Race);
            await Console.Out.WriteLineAsync("Race is over!!");
        }

        static async Task DisplayCarPositionsAsync(Car car1, Car car2)
        {
            while (!car1.HasFinished && !car2.HasFinished) 
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine($"{car1.Name} has traveled: {car1.TrackStartPosition} meters");
                        Console.WriteLine($"{car2.Name} has traveled: {car2.TrackStartPosition} meters");
                    }
                }await Task.Delay(100);

            }
        }
    }
}
