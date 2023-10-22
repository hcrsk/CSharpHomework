﻿using System.IO;

namespace Task_01
{
    internal class Repository
    {
        //Просмотр всех записей.+
        //Просмотр одной записи. Функция должна на вход принимать параметр ID записи, которую необходимо вывести на экран.+
        //Создание записи.
        //Удаление записи.
        //Загрузка записей в выбранном диапазоне дат.

        private string _path;
        private Worker[] _workers;

        public Repository(string path)
        {
            _path = path;
            LoadWorkers();
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

        public void AddWorker(Worker worker)
        {
            Array.Resize(ref _workers, _workers.Length + 1);
            _workers[_workers.Length - 1] = worker;
            using (StreamWriter employeeStream = File.AppendText(_path))
            {
                employeeStream.WriteLine(ParseWorker(worker));
            }
        }

        private void WriteWorkers()
        {
            using (StreamWriter employeeStream = new StreamWriter(_path))
            {
                foreach (Worker worker in _workers)
                {
                    employeeStream.WriteLine(ParseWorker(worker));
                }
            }
        }

        private string ParseWorker(Worker worker)
        {
            string pattern = "{0}#{1}#{2}#{3}#{4}#{5}#{6}\n";
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

        public void DeleteWorker(int id)
        {
            for (int i = 0; i < _workers.Length; i++)
            {
                {
                    if (_workers[i].Id == id)
                    {


                    }
                }
            }
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workersBetweenTwoDates = _workers;

            return workersBetweenTwoDates;
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
                Console.WriteLine($"Файл  {_path} со списком сотрудников не существует!\n" +
                    $" Хотите создать файл {_path} для списка сотрудников? Да/Нет");
                if (Console.ReadLine() == "Да")
                { File.Create(_path); }
                else
                {
                    Environment.Exit(0);
                }

            }
        }
    }
}