namespace Lists
{
    public class Node
    {
        public int Value { get; private set; }

        public Node(int value)
        {
            Value = value;
        }

        public Node Next { get; set; }
    }
}