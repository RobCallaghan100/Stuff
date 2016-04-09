using NUnit.Framework.Constraints;

namespace Lists
{
    public class Stack
    {
        private LinkedList _linkedList;

        public Stack()
        {
            _linkedList = new LinkedList();
        }

        public void Push(int value)
        {
            _linkedList.Add(value);
        }

        public int Count()
        {
            return _linkedList.Size;
        }

        public int Peek()
        {
            return _linkedList.Tail.Value;
        }
    }
}