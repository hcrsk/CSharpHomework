namespace Task_01
{
    internal class Program
    {
        /// <summary>
        /// Метод, который в качестве входного параметра принимает строковую переменную, а в качестве возвращаемого значения — массив слов
        /// </summary>
        /// <param name="rawString">строковая переменная</param>
        /// <param name="separator">символ который является разделителем слов в строке</param>
        /// <returns></returns>
        static string[] StringToWordsArray(string rawString, char separator)
        {
            string[] words = new string[1];

            for (int i = 0; i < rawString.Length; i++)
            {
                if (rawString[i] != separator)
                {
                    words[0] += rawString[i];
                }
                else
                {
                    string[] newWords = StringToWordsArray(rawString.Substring(++i), separator);
                    Array.Resize(ref words, words.Length + newWords.Length);
                    for (int j = 0; j < newWords.Length; j++)
                    {
                        words[words.Length - newWords.Length + j] = newWords[j];
                    }
                    break;
                }
            }
            return words;
        }

        /// <summary>
        ///  Метод, который выводит каждое слово в отдельной строке
        /// </summary>
        /// <param name="words">массив слов</param>
        static void PrintWordsArray(string[] words)
        {
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string sentense = Console.ReadLine();
            Console.WriteLine("Выведем каждое слово в отдельной строке.");
            PrintWordsArray(StringToWordsArray(sentense, ' '));
        }
    }
}