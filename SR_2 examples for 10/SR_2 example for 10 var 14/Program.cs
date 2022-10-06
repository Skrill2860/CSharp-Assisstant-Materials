using System;

namespace SR_2_example_for_10_var_14
{
    /*
     Вариант 14 (нечетное число букв в имени) 

    На вход программе подаются числа х, y и m.  

    Необходимо написать метод, возвращающий сумму простых чисел и количество чисел,
    делящихся на m в промежутке [x, y] через выходные параметры (out). 

    При несоответствии вводимых пользователем данных спецификации и здравой логике
    необходимо выводить осмысленное сообщение об ошибке и требовать повторить ввод.
    Требуется организовать повтор решения задачи. 
    Предусмотреть обработку исключительных ситуаций. 
     */
    class Program
    {
        /// <summary>
        /// Проверяет число на простоту.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>True если число простое, иначе false.</returns>
        static bool IsPrime(int a)
        {
            if (a < 2)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Это тоже стоит по логике разбить на 2 метода, о том что у нас метод выполняет
        // не одну функцию явно намекает And, которое так и просится в название метода
        /// <summary>
        /// Подсчитывает сумму простых чисел и количество чисел делящихся на <paramref name="m"/> на промежутке [<paramref name="x"/>, <paramref name="y"/>].
        /// </summary>
        static void CalculatePrimeSumAndDivisibleCount(int x, int y, int m, out long primeSum, out int divisibleCount)
        {
            primeSum = 0;
            divisibleCount = 0;
            for (int i = x; i <= y; i++)
            {
                if (IsPrime(i))
                {
                    primeSum += i;
                }
                if (i % m == 0)
                {
                    divisibleCount++;
                }
            }
        }

        static void Main(string[] args)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Введите начало промежутка:");
                int begin, end, delimeter;
                while (!int.TryParse(Console.ReadLine(), out begin) || begin < 0)
                {
                    Console.WriteLine("Введенное число некорректно. Начало промежутка - целое неотрицательное число.");
                }

                Console.WriteLine("Введите конец промежутка:");
                while (!int.TryParse(Console.ReadLine(), out end) || end < begin)
                {
                    Console.WriteLine("Введенное число некорректно. Конец промежутка - целое неотрицательное число. " +
                        "Конец должен быть больше либо равен началу.");
                }

                Console.WriteLine("Введите m:");
                while (!int.TryParse(Console.ReadLine(), out delimeter) || delimeter <= 0)
                {
                    Console.WriteLine("Введенное число некорректно. Введите натуральное число.");
                }

                CalculatePrimeSumAndDivisibleCount(begin, end, delimeter, out long primeSum, out int divCount);
                Console.WriteLine($"На промежутке [{begin}, {end}]:\nСумма простых чисел: {primeSum}\n" +
                    $"Количество чисел, делящихся на m: {divCount}");
                
                Console.WriteLine("Хотите начать заново? (y/n)");
                string s = Console.ReadLine().ToLower();
                if (s == "no" || s == "n")
                {
                    repeat = false;
                }
            }
        }
    }
}
