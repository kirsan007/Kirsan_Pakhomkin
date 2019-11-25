using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Пахомкин Кирсан ИУ5-31Б";
            Rectangle One = new Rectangle(4, 17); One.Print(); One.lngth = 18; One.wdth = 4; One.Print();

            Square Two = new Square(12); Two.Print();

            Circle Three = new Circle(6); Three.Print();

            Console.ReadLine();
        }
    }
}
