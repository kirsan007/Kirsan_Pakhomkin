using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Пахомкин Кирсан ИУ5-31Б";
            string a, b, c;
            double A, B, C;
            string answ = "y";
            while (answ == "y")
            {
                if ((args != null) && (args.Length >= 1))
                {
                    a = args[0];
                }

                else

                {
                    Console.WriteLine("Введите значение первого коэффициента:");
                    a = Console.ReadLine();
                }

                while (Double.TryParse(a, out A) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод. Повторите: ");             
                    a = Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                if ((args != null) && (args.Length >= 2))
                {
                    b = args[1];
                }
                else
                {
                    Console.WriteLine("Введите значение второго коэффициента:");
                    b = Console.ReadLine();
                }

                while (Double.TryParse(b, out B) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод. Повторите: ");
                    b = Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                if ((args != null) && (args.Length >= 3))
                {
                    c = args[2];
                }

                else
                {
                    Console.WriteLine("Введите значение третьего коэффициента:");
                    c = Console.ReadLine();
                }

                while (Double.TryParse(c, out C) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод. Повторите: ");
                    c = Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                if (A == 0 && B == 0 && C == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Корень - любое число"); // 0*x^4+0*x^2+0=0
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else

                {
                    if ((A == 0) && (B == 0) && (C != 0))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Корней нет"); // Такого уравнения не существует
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    else
                    {
                        if (A != 0)
                        {
                            double dscr = B * B - 4 * A * C;
                            if (dscr > 0)
                            {
                                double y1 = (-B + Math.Sqrt(dscr)) / (2 * A);
                                double y2 = (-B - Math.Sqrt(dscr)) / (2 * A);
                                Console.ForegroundColor = ConsoleColor.Green;
                                if ((y1 > 0) && (y2 > 0))
                                {
                                    double x1 = Math.Sqrt(y1);
                                    double x2 = -Math.Sqrt(y1);
                                    double x3 = Math.Sqrt(y2);
                                    double x4 = -Math.Sqrt(y2);
                                    Console.WriteLine("Корень 1= " + x1);
                                    Console.WriteLine("Корень 2= " + x2);
                                    Console.WriteLine("Корень 3= " + x3);
                                    Console.WriteLine("Корень 4= " + x4);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                if ((y1 > 0) && (y2 < 0))
                                {
                                    double x1 = Math.Sqrt(y1);
                                    double x2 = -Math.Sqrt(y1);
                                    Console.WriteLine("Корень 1= " + x1);
                                    Console.WriteLine("Корень 2= " + x2);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                if ((y1 < 0) && (y2 > 0))
                                {
                                    double x1 = Math.Sqrt(y2);
                                    double x2 = -Math.Sqrt(y2);
                                    Console.WriteLine("Корень 1= " + x1);
                                    Console.WriteLine("Корень 2= " + x2);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                if ((y1 < 0) && (y2 < 0))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Корней нет");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                if (y1 == 0 && y2 < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Корень 1= 0");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                if (y1 == 0 && y2 > 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    double x1 = Math.Sqrt(y2);
                                    double x2 = -Math.Sqrt(y2);
                                    Console.WriteLine("Корень 1= 0");
                                    Console.WriteLine("Корень 2= " + x1);
                                    Console.WriteLine("Корень 3=" + x2);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                if (y1 < 0 & y2 == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Корень 1= 0");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                if (y1 > 0 && y2 == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    double x1 = Math.Sqrt(y1);
                                    double x2 = -Math.Sqrt(y1);
                                    Console.WriteLine("Корень 1= " + x1);
                                    Console.WriteLine("Корень 2= " + x2);
                                    Console.WriteLine("Корень 3= 0");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                            }
                            else
                            {
                                if (dscr == 0)
                                {
                                    double y = (-B + Math.Sqrt(dscr)) / (2 * A);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    double x1 = Math.Sqrt(y);
                                    double x2 = -Math.Sqrt(y);
                                    Console.WriteLine("Корень 1= " + x1);
                                    Console.WriteLine("Корень 2= " + x2);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                if (dscr < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Корней нет");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                            }
                        }
                        else
                        {
                            if (C == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;  // B^2*x+C=0
                                Console.WriteLine("Корень 1= 0");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else
                            {
                                if (C > 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;  // B^2*x+C=0
                                    Console.WriteLine("Корней нет");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                else
                                {
                                    double dscr = -4 * B * C; // B^2+C=0
                                    double x1 = (Math.Sqrt(dscr)) / (2 * B);
                                    double x2 = (-Math.Sqrt(dscr)) / (2 * B);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Корень 1= " + x1);
                                    Console.WriteLine("Корень 2= " + x2);
                                }                            
                            }
                        }
                    }
                }
            }
        }
    }
}
