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
            Console.WriteLine("превышает 0.6 и не меньше 0, и сумма чисел равна 1.");
            Console.WriteLine();

            bool flExit = false;
            double value;
            double sum = 0.0;
            // точность для сравнения вещественных чисел
            double accuracy = 0.001;

            // объявляем ГСЧ
            Random rnd = new Random();

            do
            {
              // берем случайное целое число от 0 до 60
              value = rnd.Next(0, 60);
              // я взял вещественные числа с двумя знаками после запятой, чтобы последовательность получалась более интересной              
              value = Math.Round(value/100, 2);
              // 
              if (Math.Abs(sum + value - 1.0) < accuracy || sum + value < 1.0)
              {
                    // если сумма последовательности чисел = 1
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
            Console.WriteLine();
            Console.WriteLine("Написать метод, который в качестве входных данных принимает массив");
            Console.WriteLine("букв английского алфавита по порядку и возвращает пропущенную букву в массиве.");
            Console.WriteLine();

            string arraySymbol = "";
            char[] arrayChar;

            Console.Write("Введите массив символов через запятую: ");
            arraySymbol = Console.ReadLine();

            // преобразуем строку в символьный массив, убирая запятые
            arrayChar = arraySymbol.Where(x => x != ',').ToArray();

            // вызываем метод, возвращающий пропущенную букву в массиве
            ShowLostSymbol(arrayChar);

            Console.WriteLine();
        }

        /// <summary>
        /// Метод, возвращающий пропущенную букву в массиве
        /// </summary>
        /// <param name="arrayChar"></param> массив букв
        public static void ShowLostSymbol(char[] arrayChar)
        {
            char lostSymbol = ' ';
            int countLostSumbol = 0;
            bool errorArray = false;
            int dif;                       
                
            // проходим по всем элементам символьного массива
            for (int i = 1; i < arrayChar.Length; i++)
            {
                // вычисляем разницу значений соседних символов массива
                dif = Math.Abs(arrayChar[i-1].CompareTo(arrayChar[i]));

                // если между соседними элементами массива пропущено более одной буквы
                if (dif > 2) errorArray = true;
                // если между соседними элементами массива пропущена одна буква
                if (dif==2)
                {                                        
                    // получаем пропущенную букву
                    lostSymbol = (char)(arrayChar[i - 1] + 1);
                    // считаяем сколько раз в массиве было пропущено по одной букве
                    countLostSumbol++;
                }                

            }

            // если в массиве есть разрывы между соседними символами более одной буквы
            // или есть более одного случая, когда пропущена одна буква
            if (errorArray || countLostSumbol > 1)
                Console.WriteLine("Массив задан неверно!");
            else
                Console.WriteLine("Пропущенный символ: {0}", lostSymbol);
        }

        /// <summary>
        /// Метод, выполняющий тестовое задание №4
        /// </summary>
        public static void Example4()
        {
            Console.WriteLine();
            Console.WriteLine("Даны два числовых массива, необходимо написать LINQ-выражение,");
            Console.WriteLine("которое выдаст коллекцию из двух полей, где одно поле - это пересечение");
            Console.WriteLine("элементов массива, а другое поле - его квадрат.");
            Console.WriteLine();

            // объявляем два целочисленных массива
            int[] arrayOne = new int[6] {1, 2, 3, 4, 5, 7};
            int[] arrayTwo = new int[3] {2, 5, 7};

            // получаем коллекцию экземпляров анонимных типов с двумя свойствами типа int при помощи LINQ запроса
            var anonimous = from value in (from c1 in arrayOne select c1).Intersect(from c2 in arrayTwo select c2) select new {val = value, stepen = Math.Pow(value, 2)};
            
            // выводим полученную коллекцию на экран
            foreach (var s in anonimous)
                Console.WriteLine("{0}, {1}",s.val, s.stepen);

            Console.WriteLine();
        }
    }
}
