namespace Interfejsy_CS.Stos
{
    public class StosLinkedNodes<T> : IStos<T>
    {
        private class Node
        {
            private T data;
            private Node next;
        }

        private Node head;
        private Node top;
        private int counter;

        public StosLinkedNodes()
        {
            head = top = null;
            counter = 0;
        }

        public int Count => counter;

        public void Clear()
        {
            top = head = null;
            counter = 0;
        }

        public bool IsEmpty => counter == 0;

        public T Peek => throw new NotImplementedException();

        public T Pop() => throw new NotImplementedException();

        public void Push(T value) => throw new NotImplementedException();

        public T this[int index] => throw new NotImplementedException();
    }
}