using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Team
    {
        public List<IWorker> workers = new List<IWorker>();
        public void CreateWorkers(int count)
        {
            IWorker team = new TeamLeader();
            team.Name = "Name TL";
            team.Age = 55;
            team.Salary = 120000;
            this.workers.Add(team);

            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                IWorker worker = new Worker();
                worker.Name = "Name Worker #"+i;
                worker.Age = rnd.Next(18,45);
                worker.Salary = rnd.Next(45000, 200000);
                this.workers.Add(worker);
            }
        }

        public IWorker GetWorker()
        {
            Random rnd = new Random();
            int r = rnd.Next(workers.Count);

            return workers[r];
        }
    }
}
