namespace ConsoleApp1
{
    public interface IWorker
    {
        string Name { get; set; }
        double Salary { get; set; }
        int Age { get; set; }

        void ShowState();
    }
}