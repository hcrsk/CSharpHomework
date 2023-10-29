using Task_01;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            ConsoleInteractions.Help();

            bool job = true;
            DateTime dateFrom = new DateTime(1990, 1, 1);
            DateTime dateTo = new DateTime(1995, 1, 1);
            Worker worker = new Worker();
            repository.LoadWorkers("Repository.txt");

            while (job)
            {
                Console.Write("Введите команду: ");
                switch (Console.ReadLine())
                {
                    case "0": ConsoleInteractions.PrintWorkers(repository.GetAllWorkers()); break;
                    case "1": repository.AddWorker(worker); break;
                    case "2": 
                        Console.Write("Введите Id сотрудника: "); 
                        repository.DeleteWorker(int.Parse(Console.ReadLine()));
                        break;
                    case "3":
                        Console.Write("Введите Id сотрудника: ");
                        ConsoleInteractions.PrintWorker(repository.GetWorkerById(int.Parse(Console.ReadLine())));
                        break;
                    case "4":
                        ConsoleInteractions.PrintWorkers(repository.GetWorkersBetweenTwoDates(dateFrom, dateTo)); 
                        break;
                    case "5":
                        ConsoleInteractions.PrintWorkers(repository.SortWokersBy(repository.GetAllWorkers(), "id", "desc")); 
                        break;
                    case "6": job = false; break;
                    default: ConsoleInteractions.Help(); break;
                }
            }
        }
    }
}