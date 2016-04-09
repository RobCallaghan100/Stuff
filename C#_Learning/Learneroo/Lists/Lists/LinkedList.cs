namespace Lists
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Size { get; private set; }

        public Node<T> Add(T num)
        {
            return Add(Size, num);
        }

        public Node<T> Add(int index, T value)
        {
            /*
            check for negative index or index out of bounds - TODO
            */

            var newNode = new Node<T>(value);
            var previousNode = GetNode(index - 1);

            if (IsNodeBeforeHead(previousNode))
            {
                CreateNewHead(newNode);
            }
            else
            {
                InsertNode(previousNode, newNode);
            }

            if (IsIndexAtTail(index))
            {
                Tail = newNode;
            }

            Size += 1;

            return newNode;
        }

        private bool IsIndexAtTail(int index)
        {
            return index == Size;
        }

        public T Get(int index)
        {
            var node = Head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node.Value;
        }

        private static void InsertNode(Node<T> previousNode, Node<T> newNode)
        {
            var previousNext = previousNode.Next;
            newNode.Next = previousNext;
            previousNode.Next = newNode;
        }

        private void CreateNewHead(Node<T> newNode)
        {
            var oldHead = Head;
            Head = newNode;
            Head.Next = oldHead;
        }

        private static bool IsNodeBeforeHead(Node<T> previousNode)
        {
            return previousNode == null;
        }

        private Node<T> GetNode(int index)
        {
            if (index < 0)
            {
                return null;
            }

            var node = Head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node;
        }

        public T Remove(int index)
        {
            // TODO: check that index is in bounds

            var currentNode = GetNode(index);
            var previousNode = GetNode(index - 1);

            if (IndexAtHead(index))
            {
                if (Head == null)
                {
                    return default(T);
                }

                Head = Head.Next;
            }
            else if (IndexAtTail(index))
            {
                Tail = previousNode;
            }
            else
            {
                previousNode.Next = currentNode.Next;
            }

            Size -= 1;

            return currentNode.Value;
        }

        private bool IndexAtTail(int index)
        {
            return index+1 == Size;
        }

        private static bool IndexAtHead(int index)
        {
            return index == 0;
        }
    }
}