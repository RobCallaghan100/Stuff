using System;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateLists();



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
    }
}
