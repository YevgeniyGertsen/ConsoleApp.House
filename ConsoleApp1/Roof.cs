﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Roof : IPart
    {
        public TypeMaterial TypeMaterial { get; set; }
        public int Count { get; set; }
        public double TimeToCreate { get; set; }

        public bool Status { get; set; } = false;
        public IWorker worker { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine("Количество клыш: {0}, материал крыш: {1}", Count, TypeMaterial);
        }
    }
}
