using NUnit.Framework.Constraints;

namespace Lists
{
    public class Stack<T>
    {
        private LinkedList<T> _linkedList;

        public Stack()
        {
            _linkedList = new LinkedList<T>();
        }

        public void Push(T value)
        {
            _linkedList.Add(value);
        }

        public int Count()
        {
            return _linkedList.Size;
        }

        public T Peek()
        {
            return _linkedList.Tail.Value;
        }

        public T Pop()
        {
            return _linkedList.Remove(_linkedList.Size - 1);
        }
    }
}