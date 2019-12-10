using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scnd
{
    //....Класс Прямоугольник....
    public class Rectangle : Geom_Figure
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
            return "Прямоугольник с площадью:" + Area().ToString();
        }
        public override void Print()
        {
            Console.WriteLine(ToString());
        }
        public override int CompareTo(object obj)
        {
            Geom_Figure p = (Geom_Figure)obj;
            if (this.Area() > p.Area()) { return 1; }
            else if (this.Area() < p.Area()) { return -1; }
            else if (this.Area() == p.Area()) { return 0; }
            else { throw new NotImplementedException(); }
        }
    };
}