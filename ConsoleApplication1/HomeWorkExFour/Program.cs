using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static string text;
        private static List<int> numberOne = new List<int>();
        private static List<int> numberTwo = new List<int>();
        private static List<int> result = new List<int>();
        private static int numberSystem;
        private static char operation;

        public static void Main(string[] args)
        {
            Console.WriteLine("Give me your number one!");
            text = Console.ReadLine();
            for (var i = 0; i < text.Length; i++)
            {
                numberOne.Add(Convert.ToInt32(text.Substring(i, 1)));
            }

            Console.WriteLine("Give me your number two!");
            text = Console.ReadLine();
            for (var i = 0; i < text.Length; i++)
            {
                numberTwo.Add(Convert.ToInt32(text.Substring(i, 1)));
            }

            Console.WriteLine("What is this numbers system? (2...10)");
            numberSystem = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("+? -? *?");
            operation = Convert.ToChar(Console.ReadLine());


            if (numberOne.Count >= numberTwo.Count)
            {
                for (int i = numberTwo.Count; i < numberOne.Count; i++)
                {
                    numberTwo.Add(0);
                }

                if (operation == '+')
                {
                    result = Addition(numberOne, numberTwo);
                    for (int i = 0; i <= result.Count - 1; i++)
                    {
                        Console.Write(result[i]);
                    }
                }

                if (operation == '-')
                {
                    Deduction();
                }

                if (operation == '*')
                {
                    Multiply();
                }
            }
            else if (numberOne.Count <= numberTwo.Count)
            {
                for (int i = numberOne.Count; i < numberTwo.Count; i++)
                {
                    numberOne.Add(0);
                }

                if (operation == '+')
                {
                    result = Addition(numberOne, numberTwo);
                    for (int i = 0; i <= result.Count - 1; i++)
                    {
                        Console.Write(result[i]);
                    }
                }

                if (operation == '-')
                {
                    Deduction();
                }

                if (operation == '*')
                {
                    Multiply();
                }
            }
        }

        private static List<int> Addition(List<int> _numberOne, List<int> _numberTwo)
        {
            var voidResult = new List<int>();

            for (int i = _numberOne.Count - 1; i >= 0; i--)
            {
                if (_numberOne[i] + _numberTwo[i] >= numberSystem)
                {
                    voidResult.Add(_numberOne[i] + _numberTwo[i] - numberSystem);
                    if (i - 1 >= 0)
                    {
                        _numberOne[i - 1] += 1;
                    }
                    else
                    {
                        voidResult.Add(1);
                    }
                }
                else
                {
                    voidResult.Add(_numberOne[i] + _numberTwo[i]);
                }
            }
            voidResult.Reverse();
            return new List<int>(voidResult);
        }

        private static void Deduction()
        {
            int j = 1;
            for (int i = numberOne.Count - 1; i >= 0; i--)
            {
                if (numberOne[i] - numberTwo[i] >= 0)
                {
                    result.Add(numberOne[i] - numberTwo[i]);
                }
                else
                {
                    j = 1;
                    if (i - j <= 0)
                    {
                        Console.WriteLine("Exception: The result is a negative number!");
                        Environment.Exit(555);
                    }

                    while (numberOne[i - j] == 0)
                    {
                        if (i - j <= 0)
                        {
                            Console.WriteLine("Exception: The result is a negative number!");
                            Environment.Exit(555);
                        }

                        j++;
                    }

                    numberOne[i - j] -= 1;
                    while (j != 1)
                    {
                        j--;
                        numberOne[i - j] += numberSystem - 1;
                    }

                    numberOne[i] += numberSystem;
                    result.Add(numberOne[i] - numberTwo[i]);
                }
            }

            for (int i = result.Count - 1; i >= 0; i--)
            {
                Console.Write(result[i]);
            }
        }

        private static void Multiply()
        {
            if (numberSystem > 2)
            {
                Console.WriteLine("Exception: I can't do that, sorry :(");
                Environment.Exit(666);
            }
            List<int> dopResult = new List<int>();
            List<int> preResult = new List<int>();
            bool initialize = true;
            int myConst = 0;
            int f = 0;

            for (int i = 0; i <= numberTwo.Count - 1; i++)
            {

                for (int j = 0; j < f; j++)
                {
                    dopResult.Add(0);
                }
                
                for (int j = 0; j < myConst; j++)
                {
                    dopResult.Add(0);
                }
                
                for (int t = 0; t <= numberOne.Count - 1; t++)
                {
                    dopResult.Add(numberOne[t] * numberTwo[i]);
                    // TODO: Правильное умножение, или сложение в цикле...
                    
                    /*
                    Можно запилить правильное умножение,
                    чтобы работало не только с двоичной сисьтемой счисления,
                    но уже поздно, я потратил пол дня, еще математику писать...
                    */
                }
                
                for (int g = myConst; g <= numberOne.Count - 1; g++)
                {
                    dopResult.Add(0);
                    if (initialize)
                    {
                        preResult.Add(0);
                    }
                }

                if (initialize)
                {
                    for (int g = 0; g <= numberTwo.Count-1; g++)
                    {
                        preResult.Add(0);
                    }
                }
                myConst++;

                initialize = false;

                Console.WriteLine("");
                for (int e = 0; e <= preResult.Count - 1; e++)
                {
                    Console.Write(preResult[e]);
                }
                Console.WriteLine("");
                for (int e = 0; e <= dopResult.Count - 1; e++)
                {
                    Console.Write(dopResult[e]);
                }
                preResult = Addition(dopResult, preResult);
                if (preResult.Count > dopResult.Count)
                {
                    f++;
                }
                dopResult.Clear();
            }
            preResult.RemoveAt(0);
            preResult.RemoveAt(preResult.Count-1);
            Console.WriteLine("");
            for (int i = 0; i <= preResult.Count - 1; i++)
            {
                Console.Write(preResult[i]);
            }
        }
    }
}