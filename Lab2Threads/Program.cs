using System.Collections.Concurrent;

namespace Lab2Threads
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            await Console.Out.WriteLineAsync("Hello World!");

            Car car = new Car("Volvo");

            Task.Run(() => { car; });
        }
    }
}
