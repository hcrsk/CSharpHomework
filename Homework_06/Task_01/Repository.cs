using System.IO;

namespace Task_01
{
    internal class Repository
    {

        private string _path;
        private Worker[] _workers;

        /// <summary>
        /// Обьект класса Repository.
        /// </summary>
        /// <param name="path">Путь файла со списком сотрудников</param>
        public Repository(string path)
        {
            _path = path;
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
        /// <returns>Возвращает список сотрудников в виде массива работников.</returns>
        public Worker[] GetAllWorkers()
        {
            LoadWorkers(_path);
            return _workers;
        }

        /// <summary>
        /// Ищет работника по id в списке сотрудников.
        /// </summary>
        /// <param name="id">Id работника</param>
        /// <returns>возвращается Worker с запрашиваемым Id</returns>
        /// Следует учитывать что в нашем контексте Id является первичным ключом таблицы
        /// и соответствует, по крайней мере, 1NF и каждое значение id в таблице гарантированно уникально.
        public Worker GetWorkerById(int id)
        {
            for (int i = 0; i < _workers.Length; i++)
            {
                if (_workers[i].Id == id)
                {
                    return _workers[i];
                }
            }
            throw new Exception("Worker not found.");
        }

        /// <summary>
        /// Удаляет работника из списка работников.
        /// </summary>
        /// <param name="id">Id работника</param>
        public void DeleteWorker(int id)
        {
            int workersFound = 0, arrayLength = _workers.Length;
            for (int i = 0; i < _workers.Length; i++)
            {
                if (_workers[i].Id == id)
                {
                    (_workers[i], _workers[arrayLength-workersFound-1]) = (_workers[arrayLength - workersFound-1], _workers[i]);
                    workersFound++;
                }
            }
            if (workersFound > 0)
            {
                Array.Resize(ref _workers, _workers.Length - workersFound);
                WriteWorkers(_workers);
            }
            else
            {
                throw new Exception("Worker not found");
            }
        }

        /// <summary>
        /// Добавляет работника в список работников.
        /// </summary>
        /// <param name="worker">Данные работника в виде структуры Worker.</param>
        public void AddWorker(Worker worker)
        {
            Array.Resize(ref _workers, _workers.Length + 1);
            _workers[_workers.Length - 1] = worker;
            _workers[_workers.Length - 1].CreateTime = DateTime.Now;
            using (StreamWriter employeeStream = File.AppendText(_path))
            {
                employeeStream.Write(ParseWorker(worker));
            }
            WriteWorkers(_workers);
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
        /// <param name="worker">Экземпляр структуры Worker[].</param>
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
                    throw new ArgumentException("Wrong type!");
            }
            Array.Sort(sortedWorkers, (a, b) => (order == "asc" ? 1 : -1) * selector(a).CompareTo(selector(b)));
            return sortedWorkers;
        }

        /// <summary>
        /// Загружает в массив Worker[] данные считанные из файла.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        public void LoadWorkers(string path)
        {
            _path = path;
            if (File.Exists(path))
            {
                using (StreamReader workersList = new StreamReader(path))
                {
                    _workers = new Worker[File.ReadLines(path).Count()];
                    for (int i = 0; i < _workers.Length; i++)
                    {
                        _workers[i] = new Worker(workersList.ReadLine().Split("#"));
                    }
                }
            }
            else
            {
                using (File.Create(path))
                { }
            }
        }
    }
}
