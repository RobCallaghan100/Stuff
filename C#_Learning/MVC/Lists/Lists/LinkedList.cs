using System;

namespace Lists
{
    public class LinkedList
    {
        public Node Head { get; private set; }
        public Node Tail { get; private set; }

        public Node Add(int num)
        {
            var node = new Node(num);

            if (Head == null)
            {
                Head = node;
                Tail = Head;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }

            return node;
        }

        public int Get(int num)
        {
            var node = Head;
            for (int i = 0; i < num; i++)
            {
                node = node.Next;
            }

            return node.Value;
        }

        public void Add(int index, int value)
        {
            /*
            check for negative index or index out of bounds - TODO

            create new node
            get node at index-1 (or head if index=0)
            copy next from index-1(or head) to temp variable
            add temp to Next of new node
            add new node to node at index-1(or head)
            */

            var newNode = new Node(value);

            var previousNode = GetNode(index-1);

        }   

        private Node GetNode(int index)
        {   
            var node = Head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node;
        }
    }
}