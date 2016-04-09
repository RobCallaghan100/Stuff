using System;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
//            CreateLists();

            CreateAndRemoveNodesFromLinkedList();


            Console.ReadLine();
        }

        private static void CreateLists()
        {
            var linkedList = new LinkedList();
            linkedList.Add(3);
            Console.WriteLine(linkedList.Get(0));
            linkedList.Add(5);
            linkedList.Add(7);
            Console.WriteLine(linkedList.Get(1));
            linkedList.Add(4);
            Console.WriteLine(linkedList.Get(3));
            Console.WriteLine(linkedList.Get(0));
            linkedList.Add(12);
            linkedList.Add(14);
            Console.WriteLine(linkedList.Get(2));
            Console.WriteLine(linkedList.Get(5));
        }

        private static void CreateAndRemoveNodesFromLinkedList()
        {
            var _linkedList = new LinkedList();

            _linkedList.Add(3);
            Console.WriteLine(_linkedList.Get(0));
            _linkedList.Add(5);
            _linkedList.Add(1, 11);
            _linkedList.Add(7);
            _linkedList.Add(3, 13);
            _linkedList.Add(3, 14);
            Console.WriteLine(_linkedList.Get(1));
            Console.WriteLine(_linkedList.Get(3));
            Console.WriteLine(_linkedList.Remove(2));
            Console.WriteLine(_linkedList.Remove(0));
            Console.WriteLine(_linkedList.Get(3));
            _linkedList.Add(2, 10);
            _linkedList.Add(1, 9);
            Console.WriteLine(_linkedList.Get(5));
            Console.WriteLine(_linkedList.Get(3));
            Console.WriteLine(_linkedList.Remove(0));
            Console.WriteLine(_linkedList.Remove(0));
            Console.WriteLine(_linkedList.Remove(0));
            Console.WriteLine(_linkedList.Remove(0));
            Console.WriteLine(_linkedList.Remove(0));
            _linkedList.Add(2);
            _linkedList.Add(3);
            _linkedList.Add(1, 1);
            _linkedList.Add(3, 5);
            Console.WriteLine(_linkedList.Get(4));
            Console.WriteLine(_linkedList.Get(2));
        }
    }
}
