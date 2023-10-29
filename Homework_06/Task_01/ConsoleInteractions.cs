namespace Task_01
{
    internal class ConsoleInteractions
    {
        /// <summary>
        /// Выводит в консоль данные о работнике.
        /// </summary>
        /// <param name="worker">Экземпляр структуры Worker.</param>
        public static void PrintWorker(Worker worker)
        {
            string pattern = "|{0, 3}|{1, 22}|{2, 32}|{3, 7}|{4, 4}|{5, 22}|{6, 16}|";
            Console.WriteLine(pattern, worker.Id, worker.CreateTime, worker.Fullname, worker.Age, worker.Height, worker.BirthDate, worker.BirthPlace);
        }

        /// <summary>
        /// Выводит в консоль список всех работников из массива работников.
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
