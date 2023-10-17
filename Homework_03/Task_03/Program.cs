using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameOfLife
{

    public class LifeSimulation
    {
        private int _height;
        private int _width;
        private bool[,] cells;
        private int[,] _age;

        /// <summary>
        /// Создаем новую игру
        /// </summary>
        /// <param name="Height">Высота поля.</param>
        /// <param name="Width">Ширина поля.</param>

        public LifeSimulation(int Height, int Width)
        {
            _height = Height;
            _width = Width;
            cells = new bool[Height, Width];
            _age = new int[Height, Width];
            GenerateField();
        }

        /// <summary>
        /// Перейти к следующему поколению и вывести результат на консоль.
        /// </summary>
        public void DrawAndGrow()
        {
            DrawGame();
            Grow();
        }

        /// <summary>
        /// Двигаем состояние на одно вперед, по установленным правилам
        /// </summary>

        private void Grow()
        {
            Random generator = new Random();
            int epidemy = generator.Next(20);
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    int naturalDeathChance = generator.Next(_age[i, j]);
                    int epidemyDeathChance = generator.Next(5);
                    int numOfAliveNeighbors = GetNeighbors(i, j);
                    int numOfAliveCells = AliveCells();
                    if (numOfAliveCells < (_height*_width/3) || (epidemy == 1))
                    {
                        if (5 > numOfAliveNeighbors && numOfAliveNeighbors >= 2)
                        {
                            cells[i, j] = true;
                        }
                    }
                    if (cells[i, j])
                    {
                        
                        if ((epidemy == 1) && (epidemyDeathChance == 1))
                        {
                            cells[i, j] = false;
                        }
                        if (_age[i, j] >= 3)
                        {
                            if (naturalDeathChance > 1)
                            {
                                cells[i, j] = false;
                                _age[i, j] = 0;
                            }
                        }
                        else
                        {
                            _age[i, j]++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Смотрим сколько живых соседий вокруг клетки.
        /// </summary>
        /// <param name="x">X-координата клетки.</param>
        /// <param name="y">Y-координата клетки.</param>
        /// <returns>Число живых клеток.</returns>
        private int GetNeighbors(int x, int y)
        {
            int NumOfAliveNeighbors = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= _height || j >= _width)))
                    {
                        if (cells[i, j] == true) NumOfAliveNeighbors++;
                    }
                }
            }
            return NumOfAliveNeighbors;
        }
        /// <summary>
        /// Считаем количество живых клеток на поле
        /// </summary>
        /// <param name="x">X-координата клетки.</param>
        /// <param name="y">Y-координата клетки.</param>
        /// <returns>Число живых клеток.</returns>
        private int AliveCells()
        {
            int numOfAliveCells = 0;
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (cells[i, j])
                        numOfAliveCells++;
                }
            }
            return numOfAliveCells;

        }

        /// <summary>
        /// Нарисовать Игру в консоле
        /// </summary>

        private void DrawGame()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Console.Write(cells[i, j] ? "x" : " ");
                    if (j == _width - 1) Console.WriteLine("\r");
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        }

        /// <summary>
        /// Инициализируем случайными значениями
        /// </summary>

        private void GenerateField()
        {
            Random generator = new Random();
            int number;
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    number = generator.Next(2);
                    cells[i, j] = ((number == 0) ? false : true);
                    if (cells[i, j]) _age[i, j] = 1;
                    else _age[i, j] = 0;
                }
            }
        }
    }

    internal class Program
    {

        // Ограничения игры
        private const int Heigth = 15;
        private const int Width = 30;
        private const uint MaxRuns = 100;

        private static void Main(string[] args)
        {
            int runs = 0;
            LifeSimulation sim = new LifeSimulation(Heigth, Width);

            while (true)//(runs++ < MaxRuns)
            {
                sim.DrawAndGrow();

                // Дадим пользователю шанс увидеть, что происходит, немного ждем
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
