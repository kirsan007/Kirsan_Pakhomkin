using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2
{
    //....Класс Прямоугольник....
    class Rectangle : Geom_Figure, IPrint
    {
        public double lngth { get; set; }
        public double wdth { get; set; }

        public Rectangle(double a, double b)
        {
            lngth = a;
            wdth = b;
        }

        public override double Area()
        {
            return lngth * wdth;
        }

        public override string ToString()
        {
            return "Длина: " + lngth.ToString() + '\n' + "Ширина: " + wdth.ToString() + '\n' + "Площадь: " + Area().ToString() + '\n';
        }
        public void Print()
        {
            Console.WriteLine("Прямоугольник:\n" + ToString());
        }
    };
}
