using System.IO;

namespace Task_01
{
    internal class Repository
    {

        private string _path;
        private Worker[] _workers;
        /// <summary>
        /// Инициализирует список сотрудников в виде массива работников.
        /// </summary>
        /// <param name="path">Путь файла со списком сотрудников</param>
        public Repository(string path)
        {
            _path = path;
            LoadWorkers();
        }
        /// <summary>
        /// Инициализирует список сотрудников в виде массива работников. Из файла "Repository.txt"
        /// </summary>
        public Repository() : this("Repository.txt")
        {
        }
        /// <summary>
        /// Получает список сотрудников в виде массива работников.
        /// </summary>
        /// <param name="print">Выводить ли список сотрудников в консоль</param>
        /// <returns>Возвращает список сотрудников в виде массива работников.</returns>
        public Worker[] GetAllWorkers(bool print)
        {
            if (print) PrintWorkers(_workers);
            return _workers;
        }
        /// <summary>
        /// Получает список сотрудников в консоли и в виде массива работников.
        /// </summary>
        /// <returns>Возвращает список сотрудников в консоли и в виде массива работников.</returns>
        public Worker[] GetAllWorkers()
        {
            return GetAllWorkers(true);
        }
        /// <summary>
        /// Ищет работника по id в списке сотрудников.
        /// </summary>
        /// <param name="id">Id работника</param>
        /// <param name="print">Печатать ли сотрудника в консоли</param>
        /// <returns>возвращается Worker с запрашиваемым Id</returns>
        /// Следует учитывать что в нашем контексте Id является первичным ключом таблицы
        /// и соответствует, по крайней мере, 1NF и каждое значение id в таблице гарантированно уникально.
        public Worker? GetWorkerById(int id, bool print)
        {
            for (int i = 0; i < _workers.Length; i++)
            {
                if (_workers[i].Id == id)
                {
                    if (print)
                        Worker.PrintWorker(_workers[i]);
                    return _workers[i];
                }
            }
            if (print)
            Console.WriteLine($"Пользователь с id {id} не найден");
            return null;
        }
        /// <summary>
        /// Ищет работника по id в списке сотрудников.
        /// </summary>
        /// <param name="id">Id работника</param>
        /// <param name="print">Печатать ли сотрудника в консоли</param>
        /// <returns>Возвращает Worker с запрашиваемым Id и сообщает об этом в консоль.</returns>
        /// Следует учитывать что в нашем контексте Id является первичным ключом таблицы
        /// и соответствует, по крайней мере, 1NF и каждое значение id в таблице гарантированно уникально.
        public Worker? GetWorkerById(int id)
        {
            return GetWorkerById(id, true);
        }

        /// <summary>
        /// Выводит список всех работников из массива работников.
        /// </summary>
        /// <param name="workers">Массив работников.</param>
        private void PrintWorkers(Worker[] workers)
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
            for (int i = 0; i < workers.Length; i++)
            {
                Worker.PrintWorker(workers[i]);
            }
            Console.WriteLine(pattern1, split);
            Console.WriteLine();
        }
        /// <summary>
        /// Выводит список работников из списка сотрудников. 
        /// </summary>
        private void PrintWorkers()
        {
            PrintWorkers(_workers);
        }
        /// <summary>
        /// Добавляет работника в список работников.
        /// </summary>
        /// <param name="worker">Данные работника в виде структуры Worker.</param>
        public void AddWorker(Worker worker)
        {
            if (GetWorkerById(worker.Id, false) == null)
            {
                Array.Resize(ref _workers, _workers.Length + 1);
                _workers[_workers.Length - 1] = worker;
                _workers[_workers.Length - 1].CreateTime = DateTime.Now;
                using (StreamWriter employeeStream = File.AppendText(_path))
                {
                    employeeStream.Write(ParseWorker(worker));
                    Console.WriteLine($"Работник с Id {worker.Id} создан!");
                }
            }
            else
            {
                Console.WriteLine("Невозможно создать работника, существует работник с таким же Id");
            }
        }
        /// <summary>
        /// Записывает массив работников Worker[] в файл списка сотрудников.
        /// </summary>
        /// <param name="workers">Массив работников Worker[]</param>
        private void WriteWorkers(Worker[] workers)
        {
            using (StreamWriter employeeStream = new StreamWriter(_path))
            {
                foreach (Worker worker in workers)
                {
                    employeeStream.WriteLine(ParseWorker(worker));
                }
            }
        }
        /// <summary>
        /// Записывает загруженый массив работников в файл списка сотрудников.
        /// </summary>
        private void WriteWorkers()
        {
            WriteWorkers(_workers);
        }
        /// <summary>
        /// Подготавливает данные работника для записи в файл списка сотрудников.
        /// </summary>
        /// <param name="worker">Данные работника.</param>
        /// <returns></returns>
        private string ParseWorker(Worker worker)
        {
            string pattern = "{0}#{1}#{2}#{3}#{4}#{5}#{6}";
            string workerString = string.Format(pattern,
                worker.Id,
                worker.CreateTime,
                worker.Fullname,
                worker.Age,
                worker.Height,
                worker.BirthDate,
                worker.BirthPlace);
            return workerString;
        }
        /// <summary>
        /// Удаляет работника из списка работников.
        /// </summary>
        /// <param name="id">Id работника</param>
        public void DeleteWorker(int id)
        {
            Worker[] workers = new Worker[_workers.Length];
            bool workerFound = false;
            int workersLength = _workers.Length;
            for (int i = 0, j = 0; i < _workers.Length; i++)
            {
                if (_workers[i].Id == id)
                {
                    workerFound = true;
                    workersLength--;
                    continue;
                }
                workers[j] = _workers[i];
                j++;
            }
            if (workerFound)
            {
                Console.WriteLine($"Работник с Id {id} удалён!");
                Array.Resize(ref workers, workersLength);
                Array.Resize(ref _workers, workersLength);
                _workers = workers;
                WriteWorkers(_workers);
            }
            else
            {
                Console.WriteLine($"Работника с Id {id} нет в справочнике «Сотрудники»");
            }
        }
        /// <summary>
        /// Выбирает сотрудников между двумя датами из общего массива сотрудников.
        /// </summary>
        /// <param name="dateFrom">Начальная дата временного промежутка.</param>
        /// <param name="dateTo">Конечная дата временного промежутка.</param>
        /// <returns>Возращает массив сотрудников между двумя датами из общего массива сотрудников.</returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workersBetweenTwoDates = new Worker[_workers.Length];
            int arrayLength = 0;
            for (int i = 0; i < _workers.Length; i++)
            {
                if ((dateFrom < _workers[i].BirthDate) && (_workers[i].BirthDate < dateTo))
                {
                    workersBetweenTwoDates[arrayLength] = _workers[i];
                    arrayLength++;
                }
            }
            Array.Resize(ref workersBetweenTwoDates, arrayLength);
            PrintWorkers(workersBetweenTwoDates);
            return workersBetweenTwoDates;
        }
        /// <summary>
        /// Сортировать сотрудников по параметрам.
        /// </summary>
        /// <param name="workers">Массив работников</param>
        /// <param name="type">Поле по которому необходимо сортировать массив сотрудников (id, age, height)</param>
        /// <param name="order">Сортировать по убыванию или по возрастанию (asc, desc)</param>
        /// <returns>Остортированный массив сотрудников</returns>
        /// <exception cref="ArgumentException">Поле по которому необходимо сортировать массив введено не корректно.</exception>
        public Worker[] SortWokersBy(Worker[] workers, string type, string order)
        {
            Worker[] sortedWorkers = workers;

            Func<Worker, int> selector;
            switch (type)
            {
                case "id":
                    selector = s => s.Id;
                    break;
                case "age":
                    selector = s => s.Age;
                    break;
                case "height":
                    selector = s => s.Height;
                    break;
                default:
                    throw new ArgumentException("Неверный тип!");
            }
            Array.Sort(sortedWorkers, (a, b) => (order == "asc" ? 1 : -1) * selector(a).CompareTo(selector(b)));
            PrintWorkers(sortedWorkers);
            return sortedWorkers;
        }
        /// <summary>
        /// Загружает массив Worker[] считанный из файла path
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Массив Worker[] считанный из файла path</returns>
        private void LoadWorkers()
        {
            if (File.Exists(_path))
            {
                using (StreamReader workersList = new StreamReader(_path))
                {
                    _workers = new Worker[File.ReadLines(_path).Count()];
                    for (int i = 0; i < _workers.Length; i++)
                    {
                        _workers[i] = new Worker(workersList.ReadLine().Split("#"));
                    }
                }
            }
            else
            {
                Console.WriteLine($"Файл {_path} не существует!\n" +
                    $"Хотите создать файл {_path} для списка сотрудников? Да/Нет");
                if (Console.ReadLine() == "Да")
                {
                    using (File.Create(_path))
                    { }
                    LoadWorkers();
                }
                else
                {
                    Environment.Exit(0);
                }

            }
        }
    }
}