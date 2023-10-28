﻿namespace Task_01
{
    internal class Program
    {
        public static void Help()
        {
            Console.WriteLine("Для просмотра всех записей введите: 0\n" +
                "Что бы добавить запись введите: 1\n" +
                "Что бы удалить запись введите: 2\n" +
                "Что бы получить данные работника по Id введите: 3\n" +
                "Что бы получить данные о работниках между двумя датами введите: 4\n" +
                "Что бы получить отстортированый список работников по заданым параметрам введите 5\n" +
                "Что бы выйти из программы введите: 6\n" +
                "Для вывода данной справки нажмите Enter\n");
        }
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            Help();

            bool job = true;
            DateTime dateFrom = new DateTime(1990, 1, 1);
            DateTime dateTo = new DateTime(1995, 1, 1);
            Worker worker = new Worker();
            Worker[] workers = new Worker[(repository.GetAllWorkers(false)).Length];
            Array.Copy(repository.GetAllWorkers(false), workers, (repository.GetAllWorkers(false)).Length);


            while (job)
            {
                Console.Write("Введите команду: ");
                switch (Console.ReadLine())
                {
                    case "0": repository.GetAllWorkers(); break;
                    case "1": repository.AddWorker(worker); break;
                    case "2": 
                        Console.Write("Введите Id сотрудника: "); 
                        repository.DeleteWorker(int.Parse(Console.ReadLine()));
                        break;
                    case "3":
                        Console.Write("Введите Id сотрудника: ");
                        repository.GetWorkerById(int.Parse(Console.ReadLine()));
                        break;
                    case "4": repository.GetWorkersBetweenTwoDates(dateFrom, dateTo); break;
                    case "5": repository.SortWokersBy(workers, "id", "desc"); break;
                    case "6": job = false; break;
                    default: Help(); break;

                }
            }
        }
    }
}