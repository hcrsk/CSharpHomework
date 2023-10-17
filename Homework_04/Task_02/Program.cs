namespace Task_02
{
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawString">строка которую мы будем делить на слова</param>
        /// <param name="separator">символ который является разделителем слов в строке</param>
        /// <returns></returns>
        static string[] StringToWordsArray(string rawString, char separator)
        {
            return rawString.Split(separator);
        }
        /// <summary>
        /// Метод меняет слова строки местами (в обратной последовательности)
        /// </summary>
        /// <param name="inputPhrase">Строка слова в которой будут инвертированы</param>
        /// <param name="separator">символ который является разделителем слов в строке</param>
        /// /// <returns></returns>
        static string ReverseWords(string inputPhrase, char separator)
        {
            string reverseString ="";

            string[] wordsArray = StringToWordsArray(inputPhrase, separator);
            for (int i = wordsArray.Length-1; i >= 0; i--) {
                reverseString += wordsArray[i] + ' ';
            }   
            return reverseString;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");

            string sentense = Console.ReadLine();

            Console.WriteLine("Выведем каждое слово в отдельной строке.");

            Console.WriteLine(ReverseWords(sentense,' '));
        }
    }
}