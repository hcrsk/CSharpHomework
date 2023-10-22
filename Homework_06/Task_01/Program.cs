namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            //repository.GetWorkerById(3);
            Worker worker = new Worker();
            repository.AddWorker(worker);
            //repository.GetAllWorkers();
            Console.ReadKey();
        }
    }
}