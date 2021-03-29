using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class House
    {
        public List<IPart> Basement { get; set; }
        public List<IPart> Walls { get; set; }
        public List<IPart> Door { get; set; }
        public List<IPart> Window { get; set; }
        public List<IPart> Roof { get; set; }

        public void PrintReport()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("рабочие принимавшие участие: ");
            Console.WriteLine("----------------------------------");

            foreach (var item in Basement)
                Console.WriteLine(item.worker?.Name);

            foreach (var item in Walls)
                Console.WriteLine(item.worker?.Name);

            foreach (var item in Roof)
                Console.WriteLine(item?.worker?.Name);
            Console.WriteLine("----------------------------------");

        }
    }

    public enum TypeMaterial { None = 0, Cement = 1, Metal=2, Brick =3 }

    public class ServiceHouse
    {
        private Random rnd = new Random();

        public House CreateHouseProject_1()
        {
            House house = new House();
            house.Basement = Init_Basement(1);
            house.Walls = Init_Walls(4);
            house.Roof = Init_Roof(1);

            return house;
        }

        public List<IPart> GetAllPart(House house)
        {
            List<IPart> partsHouse = new List<IPart>();

            partsHouse.AddRange(house.Basement);

            //foreach (var item in house.Basement)
            //{
            //    partsHouse.Add(item);
            //}

            partsHouse.AddRange(house.Walls);
            partsHouse.AddRange(house.Roof);

            return partsHouse;
        }

        public List<IPart> Init_Basement(int count)
        {
            List<IPart> basements = new List<IPart>();
            for (int i = 0; i < count; i++)
            {
                Basement basement = new Basement();
                basement.Count = i;
                basement.TypeMaterial = TypeMaterial.Cement;
                basement.TimeToCreate = rnd.Next(1, 30);

                basements.Add(basement);
            }

            return basements;
        }

        public List<IPart> Init_Walls(int count)
        {
            List<IPart> walls = new List<IPart>();
            for (int i = 0; i < count; i++)
            {
                Walls wall = new Walls();
                wall.Count = i;
                wall.TypeMaterial = TypeMaterial.Brick;
                wall.TimeToCreate = rnd.Next(1, 30);

                walls.Add(wall);
            }

            return walls;
        }

        public List<IPart> Init_Roof(int count)
        {
            List<IPart> roofs = new List<IPart>();
            for (int i = 0; i < count; i++)
            {
                Roof roof = new Roof();
                roof.Count = i;
                roof.TypeMaterial = TypeMaterial.Brick;
                roof.TimeToCreate = rnd.Next(1, 30);

                roofs.Add(roof);
            }

            return roofs;
        }

        public void StartBuild()
        {
            //Заказать проект дома
            House house = CreateHouseProject_1();

            //Создать команду
            Team team = new Team();
            team.CreateWorkers(5);

            foreach (IPart part in GetAllPart(house))
            {
                var worker = team.GetWorker();
                if(worker is TeamLeader)
                    house.PrintReport();
                else
                {
                    part.worker = worker;
                    part.Status = true;

                    worker.ShowState();
                    for (int i = 0; i < part.TimeToCreate; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(100);
                    }

                    Console.WriteLine("");
                }
               
            }

            house.PrintReport();
        }
    }
}
