using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scnd
{

    //....Класс Круг....
    public class Circle : Geom_Figure
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
            return "Круг с площадью:" + Area().ToString();
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
    }
}