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
            */

            var newNode = new Node(value);

            var previousNode = GetNode(index-1);

            if (IsBeforeHead(previousNode))
            {
                CreateNewHead(newNode);
            }
            else
            {
                InsertNode(previousNode, newNode);
            }
        }

        private static void InsertNode(Node previousNode, Node newNode)
        {
            var previousNext = previousNode.Next;
            newNode.Next = previousNext;
            previousNode.Next = newNode;
        }

        private void CreateNewHead(Node newNode)
        {
            var oldHead = Head;
            Head = newNode;
            Head.Next = oldHead;
        }

        private static bool IsBeforeHead(Node previousNode)
        {
            return previousNode == null;
        }

        private Node GetNode(int index)
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

        public void Remove(int index)
        {
            throw new NotImplementedException();
        }
    }
}