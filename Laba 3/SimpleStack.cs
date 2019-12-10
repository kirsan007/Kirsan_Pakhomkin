using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleListProject;
using scnd;

namespace Lab_03
{
    class SimpleStack<T> : SimpleList<T>
        where T : IComparable
    {
        public void Push(T element)
        {
            Add(element);
        }

        public T Pop()
        {
            T res = default;
            if (this.Count == 0)
                return res;
            else if (this.Count == 1)
            {
                res = this.first.data;
                this.first = null;
                this.last = null;
            }
            else
            {
                //предпоследний элемент
                SimpleListItem<T> n = this.GetItem(this.Count - 2);
                res = n.next.data;
                this.last = n;
                this.last.next = null;

            }
            this.Count--;
            return res;
        }
    }
}