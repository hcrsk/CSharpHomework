namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            Worker worker = new Worker(3);

            repository.AddWorker(worker);
            repository.GetWorkerById(3);
            repository.DeleteWorker(3);
            repository.GetWorkerById(3);
            repository.GetAllWorkers();

            Console.ReadKey();
        }
    }
}