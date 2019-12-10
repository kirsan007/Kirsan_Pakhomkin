using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scnd
{
    //...Класс Квадрат...
    public class Square : Rectangle
    {
        public Square(double a) : base(a, a)
        {
            lngth = a;
            wdth = a;
        }

        public override string ToString()
        {
            return "Квадрат с площадью:" + Area().ToString();
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