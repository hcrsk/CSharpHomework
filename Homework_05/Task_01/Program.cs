namespace Task_01
{
    internal class Program
    {
        /// <summary>
        /// Метод выводит данные о всех сотрудниках в файле
        /// </summary>
        /// <param name="fileDirectory">Путь к файлу</param>
        static void PrintEmployeeData(string fileDirectory)
        {
            if (File.Exists(fileDirectory))
            {
                if (new FileInfo(fileDirectory).Length > 0)
                {
                    #region форматирование вывода
                    string pattern = "|{0, 3}|{1, 21}|{2, 32}|{3, 7}|{4, 4}|{5, 16}|{6, 16}|";
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
                        "---------------------",
                        "--------------------------------",
                        "-------",
                        "----",
                        "----------------",
                        "----------------" };
                    Console.WriteLine("Cписок всех сотрудников.");
                    Console.WriteLine(pattern, split);
                    Console.WriteLine(pattern, headers);
                    Console.WriteLine(pattern, split);
                    #endregion
                    using (StreamReader employeeStream = new StreamReader(fileDirectory))
                    {
                        do
                        {
                            var employee = employeeStream.ReadLine().Split("#");
                            Console.WriteLine(pattern, employee);
                        }
                        while (!employeeStream.EndOfStream);
                        Console.WriteLine(pattern, split);
                        Console.WriteLine();
                        employeeStream.Close();
                    }
                }
                else Console.WriteLine($"Файл {fileDirectory} пуст!");
            }
            else
            {
                Console.WriteLine($"Файл {fileDirectory} не существует!\n");
            }
        }
        /// <summary>
        /// Метод вносит данные нового сотрудника в конец списка сотрудников
        /// </summary>
        /// <param name="fileDirectory">Путь к файлу</param>
        static void InsertEmployeeData(string fileDirectory)
        {
            using (StreamWriter employeeStream = File.AppendText(fileDirectory))
            {
                for (int i = 0; i < 7; i++)
                {
                    char separatist = '#'; 
                    switch (i)
                    {
                        case 0: Console.Write("Id пользователя: "); break;
                        case 1: Console.WriteLine("Текущая дата {0}", DateTime.Now); break;
                        case 2: Console.Write("Ф.И.О. пользователя: "); break;
                        case 3: Console.Write("Возраст пользователя: "); break;
                        case 4: Console.Write("Рост пользователя: "); break;
                        case 5: Console.Write("Дата рождения пользователя: "); break;
                        case 6: separatist = '\n'; Console.Write("Место рождения пользователя: "); break;
                    }
                    if (i != 1)
                        employeeStream.Write(Console.ReadLine() + separatist);
                    else
                    {
                        employeeStream.Write(Convert.ToString(DateTime.Now) + separatist);
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            bool terminate = false;
            var path = "employeeList.txt";
            do
            {
                Console.Write("Выберите, что хотите сделать:\n" +
                    "   Что бы вывести список сотрудников введите: 0\n" +
                    "   Что бы заполнить данные и добавить новую запись в конец файла введите: 1\n" +
                    "   Для выхода нажмите Enter\n");
                switch (Console.ReadLine())
                {
                    case "0":
                        PrintEmployeeData(path);
                        break;
                    case "1":
                        InsertEmployeeData(path);
                        break;
                    default:
                        return;
                }
            } while (!terminate);
        }
    }
}