using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scnd
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Пахомкин Кирсан ИУ5-31Б";
            Rectangle One = new Rectangle(3, 16); One.Print(); One.lngth = 15; One.wdth = 2; One.Print();

            Square Two = new Square(8); Two.Print();

            Circle Three = new Circle(9); Three.Print();

            Console.ReadLine();
        }
    }
}