using System.Diagnostics;

namespace Otus.Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            LaunchMethodF1(sw, 5);
            LaunchMethodF1(sw, 10);
            LaunchMethodF1(sw, 20);

            LaunchMethodF2(sw, 5);
            LaunchMethodF2(sw, 10);
            LaunchMethodF2(sw, 20);
        }

        private static int FibonacciRecursive(int number)
        {
            if (number == 0 || number == 1)
                return number;
            return FibonacciRecursive(number - 1) + FibonacciRecursive(number - 2);
        }

        static int FibonacciLoop(int number)
        {
            int result = 0;
            int element = 1;
            int temp;

            for (int i = 0; i < number; i++)
            {
                temp = result;
                result = element;
                element += temp;
            }

            return result;
        }

        //Переделать под делегат/лямбду
        private static void LaunchMethodF1(Stopwatch stopwatch, int number)
        {
            stopwatch.Start();
            FibonacciRecursive(number);
            stopwatch.Stop();
            Console.WriteLine($"Для {number} нахождение числа в последовательности рекурсией заняло: " +
                stopwatch.Elapsed.Microseconds + " микросекнуд");
        }

        private static void LaunchMethodF2(Stopwatch stopwatch, int number)
        {
            stopwatch.Start();
            FibonacciLoop(number);
            stopwatch.Stop();
            Console.WriteLine($"Для {number} нахождение числа в последовательности циклом заняло: " +
                stopwatch.Elapsed.Microseconds + " микросекнуд");
        }

    }
}
