using System.Diagnostics;

namespace RecursionAndLoopsHomework
{
    internal static class FindFibonacciMethods
    {
        public static void StartProgram()
        {
            int[] indexes = [5, 10, 20];
            var timer = new Stopwatch();

            Console.WriteLine("Нахождение чисел Фибоначчи через рекурсию:");
            FindFibonacciNumber(indexes, GetRecursionFibonacciNumberByIndex, timer);
            Console.WriteLine("\nНахождение чисел Фибоначчи через цикл:");
            FindFibonacciNumber(indexes, GetLoopsFibonacciNumberByIndex, timer);
        }

        private static void FindFibonacciNumber(int[] indexes, Func<int, long> findFibonacciMethod, Stopwatch timer)
        {
            foreach (var index in indexes)
            {
                timer.Start();
                var number = findFibonacciMethod(index);
                timer.Stop();
                Console.WriteLine($"{index}-е число Фибоначчи: {number}, затраченное время - {timer.ElapsedTicks} тиков");
                timer.Reset();
            }
        }

        private static long GetRecursionFibonacciNumberByIndex(int index)
        {
            if (index < 0)
                throw new ArgumentException("Невозможно найти число Фибоначчи для отрицательной позиции");

            if (index is 0)
                return 0;
            else if (index is 1 or 2)
                return 1;

            return GetRecursionFibonacciNumberByIndex(index - 1) + GetRecursionFibonacciNumberByIndex(index - 2);
        }
        private static long GetLoopsFibonacciNumberByIndex(int index)
        {
            if (index < 0)
                throw new ArgumentException("Невозможно найти число Фибоначчи для отрицательной позиции");

            long currentResult = 0L;
            long previousResult = 1L;
            long beforePreviousResult = 1L;
            for (int i = 0; i <= index; i++)
            {
                if (i is 0)
                    continue;
                else if (i is 1 or 2)
                    currentResult = 1;
                else
                {
                    currentResult = previousResult + beforePreviousResult;
                    beforePreviousResult = previousResult;
                    previousResult = currentResult;
                }
            }

            return currentResult;
        }
    }
}
