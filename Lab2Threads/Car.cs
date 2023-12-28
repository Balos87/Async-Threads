using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Lab2Threads
{
    internal class Car
    {
        public string Name { get; set; }
        public int DrivingSpeed = 34; // 120km/h - I wanted it converted to meters so this is aprox 34m/s
        public int SpeedAtStart = 0; // Before GO.
        public int TrackLenght = 1000; // 10km
        public int TrackStartPosition = 0; // The Start-line
        public bool HasFinished = false;

        public int OutOfGasDelayer = 10000;

        private bool IsDelayed = false;

        public Car(string name)
        {
            Name = name;
        }

        public async Task StartRaceAsync()
        {//Method that runs the race actual race.

            var roadProblemsTask = RoadProblemsAsync();
            await Console.Out.WriteLineAsync($"{Name} just started the race!");

            while (TrackStartPosition < TrackLenght)
            {
                if (!IsDelayed)
                {
                    TrackStartPosition += DrivingSpeed;
                }

                await Task.Delay(1000);

                if (TrackStartPosition >= TrackLenght)
                {
                    await Console.Out.WriteLineAsync($"{Name} is the winner!");
                    HasFinished = true;
                    break;
                }
            }
            await roadProblemsTask;

        }

        public async Task RoadProblemsAsync()
        {//Method to simulate problems along the race.

            Random whatProblemWillAccure = new Random();

            while ( TrackStartPosition < TrackLenght )
            {
                await Task.Delay(5000);

                int randomAccident = whatProblemWillAccure.Next(1, 51);

                if (randomAccident <= 1)
                {
                    IsDelayed = true;
                    await Console.Out.WriteLineAsync($"{Name} is out of gas, need refill fuel.");
                    await Console.Out.WriteLineAsync($"{Name} is delayed with 20secs");
                    await Task.Delay(20000);
                    await Console.Out.WriteLineAsync("Delay has passed.");
                    IsDelayed = false;
                }
                else if (randomAccident <= 3)
                {
                    IsDelayed = true;
                    await Console.Out.WriteLineAsync($"{Name} got a flat tire, need to change it.");
                    await Console.Out.WriteLineAsync($"{Name} is delayed with 10secs");
                    await Task.Delay(10000);
                    await Console.Out.WriteLineAsync("Delay has passed.");
                    IsDelayed = false;
                }
                else if (randomAccident <= 8)
                {
                    IsDelayed = true;
                    await Console.Out.WriteLineAsync($"{Name} got a bird on the windshield, what are the odds... Need to clean it up.");
                    await Console.Out.WriteLineAsync($"{Name} is delayed with 5secs");
                    await Task.Delay(5000);
                    await Console.Out.WriteLineAsync("Delay has passed.");
                    IsDelayed = false;
                }
                else if (randomAccident <= 18)
                {
                    await Console.Out.WriteLineAsync($"{Name} got a engine malfunction, speed is reduced.");
                    DrivingSpeed--;
                }
                else
                {
                    await Console.Out.WriteLineAsync("Phew, no accident happened, race keeps on going.");
                }
            }

        }
    }
}
