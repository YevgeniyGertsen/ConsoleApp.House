using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Worker : IWorker
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }

        public void ShowState()
        {
            Console.WriteLine("I work now!");
        }
    }
}
