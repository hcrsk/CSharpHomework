namespace Task_01
{
    internal class Repository
    {
        //Просмотр всех записей.+
        //Просмотр одной записи. Функция должна на вход принимать параметр ID записи, которую необходимо вывести на экран.
        //Создание записи.
        //Удаление записи.
        //Загрузка записей в выбранном диапазоне дат.

        private string _path;
        private Worker[] _workers;

        public Repository(string path)
        {
            _path = path;
            _workers = LoadWorkers(_path);
        }

        public Repository() : this("Repository.txt")
        {
        }

        public Worker[] GetAllWorkers()
        {
            PrintWorkers(_workers);
            return _workers;
        }

        /// <summary>
        /// Происходит поиск работника по id
        /// </summary>
        /// <param name="id">Id работника</param>
        /// <returns>возвращается Worker с запрашиваемым Id</returns>
        /// Следует учитывать что в нашем контексте Id является первичным ключом таблицы
        /// и соответствует, по крайней мере, 1NF и каждое значение id в таблице гарантированно уникально.
        public Worker GetWorkerById(int id)
        {
            for (int i = 0; i < _workers.Length; i++)
            {
                {
                    if (_workers[i].Id == id)
                    {
                        Worker.PrintWorker(_workers[i]);
                        return _workers[i];
                    }
                }
            }
            return _workers[-1];
        }

        private void PrintWorkers(Worker[] workers)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                Worker.PrintWorker(workers[i]);
            }
        }

        private void PrintWorkers()
        {
            PrintWorkers(_workers);
        }

        /// <summary>
        /// Загружает массив Worker[] считанный из файла path
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Массив Worker[] считанный из файла path</returns>
        private Worker[] LoadWorkers(string path)
        {
            Worker[] workers;

            using (StreamReader workersList = new StreamReader(path))
            {
                workers = new Worker[File.ReadLines(path).Count()];
                for (int i = 0; i < workers.Length; i++)
                {
                    workers[i] = new Worker(workersList.ReadLine().Split("#"));
                }
                return workers;
            }
        }
    }
}