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

        public Car(string name)
        {
            Name = name;
            Runner();
        }

        public async Task Runner()
        {
            await Task.Delay(5000);
        }
    }
}
