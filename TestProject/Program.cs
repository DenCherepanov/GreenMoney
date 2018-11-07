using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool userDone = false;
            string userCommand = "";

            try
            {
                do
                {
                    Console.Write("Введите номер тестового задания (от 1 до 4, Q - выход), и нажмите Enter: ");
                    userCommand = Console.ReadLine();
                    switch (userCommand.ToUpper())
                    {
                        case "1":
                            Example1();
                            break;
                        case "2":
                            Example2();
                            break;
                        case "3":
                            Example3();
                            break;
                        case "4":
                            Example4();
                            break;
                        case "Q":
                            userDone = true;
                            break;
                        default:
                            Console.WriteLine("Неправильные данные! Повторите попытку");
                            break;
                    }
                } while (!userDone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Метод, выполняющий тестовое задание №1
        /// </summary>
        public static void Example1()
        {
            Console.WriteLine();           
            Console.WriteLine("Написать код, который выведет числа от 0 до 127 по порядку. Вместо чисел,");
            Console.WriteLine("кратных 3, выводить текст ‘Green’, вместо чисел, кратных 5 – ‘Money’,");
            Console.WriteLine("вместо кратных и 3, и 5 – ‘GreenMoney’.");
            Console.WriteLine();

            for (int i = 0; i <= 127; i++)
            {
                if ((i % 3 == 0 || i % 5 == 0) & (i !=0))
                {
                    if (i % 3 == 0 & i % 5 != 0) Console.WriteLine("Green ");
                    if (i % 3 != 0 & i % 5 == 0) Console.WriteLine("Money ");
                    if (i % 3 == 0 & i % 5 == 0) Console.WriteLine("GreenMoney ");
                }
                else
                {
                    Console.WriteLine("{0} ", i);
                }                               
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Метод, выполняющий тестовое задание №2
        /// </summary>
        public static void Example2()
        {
            Console.WriteLine();
            Console.WriteLine("Сгенерировать последовательность случайных чисел, чей размер не");
            Console.WriteLine("ревышает 0.6 и не меньше 0, и сумма чисел равна 1.");
            Console.WriteLine();

            bool flExit = false;
            double value;
            double sum = 0.0;
            double accuracy = 0.001;

            Random rnd = new Random();

            do
            {
              value = rnd.Next(0, 60);
              value = Math.Round(value/100, 2);
              if (Math.Abs(sum + value - 1.0) < accuracy || sum + value < 1.0)
              {
                    if (Math.Abs(sum + value - 1.0) < accuracy) flExit = true;
                    sum = sum + value;
                    Console.WriteLine("{0}", value.ToString("0.00"));
              }
            } while (!flExit);
                                   

            Console.WriteLine();
        }

        /// <summary>
        /// Метод, выполняющий тестовое задание №3
        /// </summary>
        public static void Example3()
        {
            Console.WriteLine("Третье задание!");
        }

        /// <summary>
        /// Метод, выполняющий тестовое задание №4
        /// </summary>
        public static void Example4()
        {
            Console.WriteLine("Четвертое задание!");
        }
    }
}
