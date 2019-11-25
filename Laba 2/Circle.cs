using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2
{

    //....Класс Круг....
    class Circle : Geom_Figure, IPrint
    {
        public double radius { get; set; }

        public Circle(double r)
        {
            radius = r;
        }
        public override double Area()
        {
            return Math.PI * radius * radius;
        }

        public override string ToString()
        {
            return "Радиус: " + radius.ToString() + '\n' + "Площадь: " + Area().ToString() + '\n';
        }

        public void Print()
        {
            Console.WriteLine("Круг:\n" + ToString());
        }
    }
}
