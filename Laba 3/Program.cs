using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparseMatrix;
using scnd;


namespace Lab_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Пахомкин Кирсан ИУ5-31Б";
            Rectangle rect = new Rectangle(3, 16);

            Square squa = new Square(8);

            Circle crcl = new Circle(9);

            Console.WriteLine("Класс ArrayList");
            //....ArrayList....
            ArrayList arrlist = new ArrayList();
            arrlist.Add(squa);
            arrlist.Add(rect);
            arrlist.Add(crcl);
            foreach (Geom_Figure i in arrlist)
            {
                i.Print();
            }

            arrlist.Sort();

            Console.WriteLine("\nПосле сортировки");
            foreach (Geom_Figure i in arrlist)
            {
                i.Print();
            }

            Console.WriteLine("\nКласс List<>");
            //....List<T>....
            List<Geom_Figure> lst = new List<Geom_Figure>();
            lst.Add(squa);
            lst.Add(rect);
            lst.Add(crcl);
            foreach (Geom_Figure val in lst)
            {
                val.Print();
            }
            lst.Sort();
            Console.WriteLine("\nПосле сортировки:");
            foreach (Geom_Figure val in lst)
            {
                val.Print();
            }

            Console.WriteLine("\nМатрица:");
            Matrix<Geom_Figure> matrix = new Matrix<Geom_Figure>(3, 3, 3, null);
            matrix[0, 0, 0] = rect;
            matrix[1, 1, 1] = squa;
            matrix[2, 2, 2] = crcl;
            Console.WriteLine(matrix.ToString());


            SimpleStack<Geom_Figure> stck = new SimpleStack<Geom_Figure>();
            stck.Push(squa);
            stck.Push(rect);
            stck.Push(crcl);
            Console.WriteLine("\nКласс SimpleStack");
            while (stck.Count > 0)
            {
                Console.WriteLine(stck.Pop());
            }


            Console.ReadLine();
        }
    }
}
