using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_1
{
    delegate int PlusOrMinus(int lhs, int rhs);
    class Program
    {
        static int Plus(int lhs, int rhs) => lhs + rhs;

        static int Minus(int lhs, int rhs) => lhs - rhs;

        static void SumOrSubstraction(int lhs, int rhs, PlusOrMinus Fnk)
        {
            Console.WriteLine(($"{lhs} {(lhs + rhs == Fnk(lhs, rhs) ? "+" : "-")} {rhs} = {Fnk(lhs, rhs)}"));
        }

        static void SumOrSubstractionF(int lhs, int rhs, Func<int, int, int> Fnk)
        {
            Console.WriteLine(($"{lhs} {(lhs + rhs == Fnk(lhs, rhs) ? "+" : "-")} {rhs} = {Fnk(lhs, rhs)}"));
        }
        static void Main(string[] args)
        {
            int w1 = 5;
            int w2 = 6;

            //Создание экземпляра делегата на основе метода
            Console.WriteLine("На основе метода:");
            PlusOrMinus f1 = new PlusOrMinus(Plus);
            SumOrSubstraction(w1, w2, f1);

            PlusOrMinus f2 = Minus;
            SumOrSubstraction(w1, w2, f2);

            //Использование лямбда-выражение
            Console.WriteLine("\nИспользование лямбда-выражение:");
            SumOrSubstraction(4, 5, (lhs, rhs) => lhs + rhs);


            //Использование Func
            Console.WriteLine("\nBльзование Func:");
            SumOrSubstractionF(4, 5, Minus);
            Console.ReadLine();

        }
    }
}