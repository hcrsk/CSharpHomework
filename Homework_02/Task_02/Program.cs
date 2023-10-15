namespace Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cardQuantity;
            int cardAmount = 0;

            Console.Write("Введите количество ваших карт: ");
            cardQuantity = int.Parse(Console.ReadLine());
            for (int i = 0; i < cardQuantity; i++)
            {
                Console.Write($"Введите номинал {i + 1} карты: ");
                string card = Console.ReadLine();
                switch (card)
                {
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                        cardAmount += int.Parse(card);
                        break;
                    case "J":
                        cardAmount += 2;
                        break;
                    case "Q":
                        cardAmount += 3;
                        break;
                    case "K":
                        cardAmount += 4;
                        break;
                    case "T":
                        cardAmount += 11;
                        break;
                }
            }
            Console.WriteLine($"Сумма ваших карт {cardAmount}!");
            Console.ReadKey();
        }
    }
}
