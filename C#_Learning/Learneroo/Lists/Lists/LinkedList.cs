﻿namespace Lists
{
    public class LinkedList
    {
        public Node Head { get; private set; }
        public Node Tail { get; private set; }
        public int Size { get; private set; }

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

            Size += 1;

            return node;
        }

        public void Add(int index, int value)
        {
            /*
            check for negative index or index out of bounds - TODO
            */

            var newNode = new Node(value);

            var previousNode = GetNode(index - 1);

            if (IsBeforeHead(previousNode))
            {
                CreateNewHead(newNode);
            }
            else
            {
                InsertNode(previousNode, newNode);
            }

            Size += 1;
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

        public int Remove(int index)
        {
            // TODO: check that index is in bounds

            var currentNode = GetNode(index);
            var previousNode = GetNode(index - 1);

            if (IsBeforeHead(previousNode))
            {
                Head = Head.Next;
            }
            else
            {
                previousNode.Next = currentNode.Next;
            }

            Size -= 1;

            return currentNode.Value;
        }
    }
}