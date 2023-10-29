namespace Task_01
{
    internal class ConsoleInteractions
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

    }
}
