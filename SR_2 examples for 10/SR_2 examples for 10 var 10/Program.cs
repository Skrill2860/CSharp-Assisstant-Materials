using System;

namespace SR_1_example_for_10_var_10
{
    /*
    Вариант 10  (четное число букв в имени) 

    Программа запрашивает у пользователя два целочисленных значения a и A
    (a < A) – минимальное и максимальное значение длины стороны правильно треугольника, соответственно.
    Затем, выводит на экран значение площади треугольника, периметра треугольника и
    отношение площади треугольника к его периметру для длин сторон из интервала
    [a, A] с шагом 1 (текущее значение стороны также вывести на экран).  

    Нахождение периметра треугольника и площади необходимо вынести в отдельный метод,
    который принимает в качестве параметров текущее значение длины стороны и возвращает 
    площадь треугольника и его периметр через выходные параметры (out). 
    Площадь треугольника и его периметр представляются вещественными числами. 

    При несоответствии вводимых пользователем данных спецификации и здравой 
    логике необходимо выводить осмысленное сообщение об ошибке и требовать 
    повторить ввод. Требуется организовать повтор решения задачи. 
    Предусмотреть обработку исключительных ситуаций. 
     */
    class Program
    {
        // В условии просят один метод который считает и то, и то,
        // но логичнее будет разделить его на два разных

        /// <summary>
        /// Высчитывает периметр равнобедренного треугольника по длине его стороны <paramref name="sideLength"/>.
        /// </summary>
        /// <param name="sideLength">Длина стороны</param>
        /// <param name="perimeter">Значение периметра равнобедренного треугольника</param>
        static void CalculatePerimeter(int sideLength, out int perimeter)
        {
            perimeter = 3 * sideLength;
        }

        /// <summary>
        /// Высчитывает площадь равнобедренного треугольника по длине его стороны <paramref name="sideLength"/>.
        /// </summary>
        /// <param name="sideLength">Длина стороны</param>
        /// <param name="area">Значение площади равнобедренного треугольника</param>
        static void CalculateArea(int sideLength, out double area)
        {
            // Вроде у площади такая формула
            area = sideLength * sideLength * Math.Sqrt(3) / 2;
        }

        static void Main(string[] args)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Введите минимальную длину стороны:");
                int minLength, maxLength;
                while (!int.TryParse(Console.ReadLine(), out minLength) || minLength < 0)
                {
                    Console.WriteLine("Введеная минимальная длина некорректна. Длина - целое неотрицательное число");
                }

                Console.WriteLine("Введите максимальную длину стороны:");
                while (!int.TryParse(Console.ReadLine(), out maxLength) || maxLength < minLength)
                {
                    Console.WriteLine("Введеная максимальная длина некорректна. Длина - целое неотрицательное число." +
                        " Макс длина должна быть больше либо равна мин длине.");
                }

                for (int i = minLength; i <= maxLength; i++)
                {
                    CalculatePerimeter(i, out int perimeter);
                    CalculateArea(i, out double area);
                    Console.WriteLine($"Для стороны длины {i}:\n" +
                        $"Периметр: {perimeter}\nПлощадь: {area}\nОтношение: {area / (perimeter == 0 ? 1 : perimeter)}\n");
                }
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
