using System.Collections.Generic;

namespace _29_implementacjaUproszczonegoStosuGenerycznego
{
    internal class Stos<T> : IStos<T>
    {
        public List<T> lista = new List<T>();

        public T Peek
        {
            get
            {
                if (lista.Count == 0)
                    throw new StosEmptyException();
                else
                    return lista[Count - 1];
            }
        }

        public T Pop()
        {
            if (lista.Count == 0)
                throw new StosEmptyException();
            else
            {
                T item = lista[Count - 1];
                lista.RemoveAt(Count - 1);
                return item;
            }
        }

        public int Count => lista.Count;

        public bool IsEmpty => lista.Count == 0 ? true : false;

        public void Clear() => lista.Clear();

        public void Push(T value)
        {
            lista.Add(value);
        }

        public T[] ToArray()
        {
            return lista.ToArray();
        }
    }
}