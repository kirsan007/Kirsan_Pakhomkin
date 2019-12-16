using System;
using System.Collections.Generic;
using System.Text;

namespace Laba6_2
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    class AttribClass : Attribute
    {
            public AttribClass() { }
            public AttribClass(string DescriptionParam)
            {
                Description = DescriptionParam;
            }

            public string Description { get; set; }
        
    }
}
