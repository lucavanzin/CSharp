using System;
using System.Text;

namespace Random_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool parseResult;
            int items;
            int lowBoundary;
            int hignBoundary;
            int seed;
            string before;
            string after;
            ConsoleKeyInfo again;
            do
            {
                do
                {
                    Console.WriteLine(" Number of requested random numbers? ");
                    parseResult = Int32.TryParse(Console.ReadLine(), out items);
                } while (!parseResult);
                do
                {
                    Console.WriteLine(" Low boundary of generate numbers? ");
                    parseResult = Int32.TryParse(Console.ReadLine(), out lowBoundary);
                } while (!parseResult);
                do
                {
                    Console.WriteLine(" High boundary of generate numbers? ");
                    parseResult = Int32.TryParse(Console.ReadLine(), out hignBoundary);
                } while (!parseResult);
                do
                {
                    Console.WriteLine(" Specify a seed:  ");
                    parseResult = Int32.TryParse(Console.ReadLine(), out seed);
                } while (!parseResult);

                Console.WriteLine("Insert a number prefix: ");
                before = Console.ReadLine();
                Console.WriteLine("Insert a number separator: ");
                after = Console.ReadLine();

                Console.WriteLine("Generating numbers\n");
                StringBuilder sb = new StringBuilder();
                Random rnd = new Random(seed);
                for (int index = 0; index < items - 1; index++)
                {
                    int random = rnd.Next(lowBoundary, hignBoundary);
                    sb.Append(before + random.ToString() + after);
                }
                int lastRandom = rnd.Next(lowBoundary, hignBoundary);
                sb.Append(before + lastRandom.ToString());
                Console.WriteLine(sb.ToString());
                do
                {
                    Console.WriteLine("Again? (Y/N)");
                    again = Console.ReadKey();
                } while (again.Key != ConsoleKey.Y && again.Key != ConsoleKey.N);

            } while (again.Key == ConsoleKey.Y);
        }
    }
}
