namespace Lists
{
    public class Queue<T>
    {
        private LinkedList<T> _linkedList;

        public Queue()
        {
            _linkedList = new LinkedList<T>();
        }

        public void Enqueue(T value)
        {
            _linkedList.Add(value);
        }

        public T Dequeue()
        {
            return _linkedList.Remove(0);
        }

        public T Peek()
        {
            return _linkedList.Head.Value;
        }

        public int Count()
        {
            return _linkedList.Size;
        }
    }
}