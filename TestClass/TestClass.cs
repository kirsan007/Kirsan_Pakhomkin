using System;
using System.Collections.Generic;
using System.Text;

namespace Laba6_2
{
    class TestClass
    {
        public TestClass() { }
        public TestClass(int i) { }
        public TestClass(string str) { }

        public int Plus(int x, int y) { return x + y; }
        public int Minus(int x, int y) { return x - y; }

        [AttribClass("Описание для property1")]
        public string property1
        {
            get { return _property1; }
            set { _property1 = value; }
        }
        private string _property1;

        public int property2 { get; set; }

        [AttribClass(Description = "Описание для property3")]
        public double property3 { get; private set; }


        public int field1;
        public float field2;
    }
}
