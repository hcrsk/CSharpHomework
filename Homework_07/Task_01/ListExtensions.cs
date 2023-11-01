using System;
using System.Collections.Generic;

namespace Task_01
{
    /// <summary>
    /// Расширяющие методы для класса List<int>.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Выводит элементы списка в консоль.
        /// </summary>
        /// <param name="list">Расширяемый список целых чисел.</param>
        public static void PrintList(this List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
        }

        /// <summary>
        /// Добавляет указанное количество случайных целых чисел (от 0 до 100) в список.
        /// </summary>
        /// <param name="list">Расширяемый список целых чисел.</param>
        /// <param name="length">Количество случайных чисел, которые необходимо добавить в список.</param>
        /// <returns>Список с добавленными случайными числами.</returns>
        public static List<int> GetRandomList(this List<int> list, int length)
        {
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                list.Add(rand.Next(101));
            }
            return list;
        }
    }
}
