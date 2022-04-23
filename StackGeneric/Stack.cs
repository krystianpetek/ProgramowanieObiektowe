using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGeneric
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] genericList = new T[100];
        private int top = 0;
        public void Push(T t)
        {
            genericList[top++] = t;
        }
        public T Pop()
        {
            return genericList[--top];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = top - 1; i >= 0; i--)
            {
                yield return genericList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> TopToBottom
        {
            get
            {
                return this;
            }
        }

        public IEnumerable<T> BottomToTop
        {
            get
            {
                for (int i = 0; i <= top - 1; i++)
                {
                    yield return genericList[i];
                }
            }
        }

        public IEnumerable<T> TopToN(int itemFromTop)
        {
            int startIndex = itemFromTop >= top ? 0 : top - itemFromTop;
            for (int i = top - 1; i >= startIndex; i--)
            {
                yield return genericList[i];
            }
        }
    }
}
