namespace HackerRank.DataStructure
{
    public class Stack
    {
        private Node head;

        private class Node
        {
            public Node(int val)
            {
                Value = val;
            }

            public int Value { get; set; }
            public Node Next { get; set; }
        }

        public void Add(int val)
        {
            var node = new Node(val);
            node.Next = head;
            head = node;
        }

        public int Pop()
        {
            var val = head.Value;
            head = head.Next;
            return val;
        }

        public int Peek()
        {
            return head.Value;
        }
    }
}
