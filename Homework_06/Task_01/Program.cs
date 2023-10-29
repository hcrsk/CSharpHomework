namespace Task_01
{
    internal class Program
    {
        public static void Help()
        {
            Console.WriteLine("Для загрузки из файла и просмотра всех записей введите: 0\n" +
                "Что бы добавить запись введите: 1\n" +
                "Что бы удалить запись введите: 2\n" +
                "Что бы получить данные работника по Id введите: 3\n" +
                "Что бы получить данные о работниках между двумя датами введите: 4\n" +
                "Что бы получить отстортированый список работников по заданым параметрам введите 5\n" +
                "Что бы выйти из программы введите: 6\n" +
                "Для вывода данной справки нажмите Enter\n");
        }

        public static void PrintWorker(Worker worker)
        {
            string pattern = "|{0, 3}|{1, 22}|{2, 32}|{3, 7}|{4, 4}|{5, 22}|{6, 16}|";
            Console.WriteLine(pattern, worker.Id, worker.CreateTime, worker.Fullname, worker.Age, worker.Height, worker.BirthDate, worker.BirthPlace);
        }

        /// <summary>
        /// Выводит список всех работников из массива работников.
        /// </summary>
        /// <param name="workers">Массив работников.</param>
        public static void PrintWorkers(Worker[] workers)
        {
            string pattern = "|{0, 3}|{1, 22}|{2, 32}|{3, 4}|{4, 4}|{5, 22}|{6, 16}|";
            string pattern1 = "+{0, 3}+{1, 22}+{2, 32}+{3, 4}+{4, 4}+{5, 22}+{6, 16}+";
            string[] headers = {
                        "id",
                        "дата",
                        "Ф.И.О.",
                        "Возраст",
                        "Рост",
                        "Дата рождения",
                        "Место рождения" };
            string[] split = {
                        "---",
                        "----------------------",
                        "--------------------------------",
                        "-------",
                        "----",
                        "----------------------",
                        "----------------" };
            Console.WriteLine(pattern1, split);
            Console.WriteLine(pattern, headers);
            Console.WriteLine(pattern1, split);
            foreach (var worker in workers)
            {
                PrintWorker(worker);
            }
            Console.WriteLine(pattern1, split);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Repository repository = new Repository();

            Help();

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
                    case "0": PrintWorkers(repository.GetAllWorkers()); break;
                    case "1": repository.AddWorker(worker); break;
                    case "2": 
                        Console.Write("Введите Id сотрудника: "); 
                        repository.DeleteWorker(int.Parse(Console.ReadLine()));
                        break;
                    case "3":
                        Console.Write("Введите Id сотрудника: ");
                        PrintWorker(repository.GetWorkerById(int.Parse(Console.ReadLine())));
                        break;
                    case "4": 
                        PrintWorkers(repository.GetWorkersBetweenTwoDates(dateFrom, dateTo)); 
                        break;
                    case "5": 
                        PrintWorkers(repository.SortWokersBy(repository.GetAllWorkers(), "id", "desc")); 
                        break;
                    case "6": job = false; break;
                    default: Help(); break;
                }
            }
        }
    }
}