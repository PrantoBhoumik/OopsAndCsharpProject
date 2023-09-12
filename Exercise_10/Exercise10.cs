using System;
using System.Collections.Generic;

namespace Exercise_10
{
    public interface PQueue2<T>
    {
        int Count { get; }
        void Push(T element);
        T Pop();
        void Remove(T element);
    }

    //Return true  if (a.priority >  b.priority)
    //Return false if (a.priority == b.priority)
    //Return false if (a.priority <  b.priority)
    //If equality does not return false then StablePriorityQueue will not sort correctly.
    public delegate bool PriorityIsGreater2<T>(T a, T b);

    class Queue2<T> : PQueue2<T>
    {
        public Queue2(PriorityIsGreater2<T> isGreaterPriority)
        {
            Initialize(isGreaterPriority);
        }

        public Queue2(PriorityIsGreater2<T> isGreaterPriority, T[] ary)
        {
            Initialize(isGreaterPriority);
            foreach (T element in ary) { Push(element); }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public void Push(T element)
        {
            int index = Count;
            list.Add(element);

            while (!isRoot(index) && IsGreater(list[index], list[parent(index)]))
            {
                swapElements(index, parent(index));
                index = parent(index);
            }
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Tried to pop an empty PriorityQueue.");
            }

            T retval = list[0];

            int victimIndex = Count - 1;
            if (victimIndex > 0) { list[0] = list[victimIndex]; }
            list.RemoveAt(victimIndex);

            int index = 0;
            while (hasChildren(index))
            {
                int gci = GreaterChildIndex(index);
                if (IsGreaterByIndex(index, gci)) { break; }
                swapElements(index, gci);
                index = gci;
            }

            return retval;
        }

        public void Remove(T element)
        {
            int index = list.FindIndex((x) => EqualityComparer<T>.Default.Equals(x, element));
            if (index == -1) { return; }
            while (!isRoot(index))
            {
                swapElements(index, parent(index));
                index = parent(index);
            }
            Pop();
        }

        #region Non-Public Members
        PriorityIsGreater2<T> IsGreater;

        bool IsGreaterByIndex(int a, int b)
        {
            return IsGreater(list[a], list[b]);
        }

        int GreaterChildIndex(int index)
        {
            int left = leftChild(index);
            int right = rightChild(index);

            if (!hasChildren(index)) { throw new IndexOutOfRangeException(); }
            if (right == Count) { return left; }

            if (IsGreaterByIndex(left, right)) { return left; }
            return right;
        }

        List<T> list;

        void Initialize(PriorityIsGreater2<T> isGreaterPriority)
        {
            IsGreater = isGreaterPriority;
            list = new List<T>();
        }

        static bool isRoot(int index) { return index == 0; }
        static int parent(int index) { return (index - 1) / 2; }
        static int leftChild(int index) { return (index * 2) + 1; }
        static int rightChild(int index) { return (index * 2) + 2; }

        bool hasChildren(int index)
        {
            return leftChild(index) < Count;
        }

        void swapElements(int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
        #endregion
    }
    class StableQueue2<T> : PQueue2<T>
    {
        public StableQueue2(PriorityIsGreater2<T> isGreaterPriority)
        {
            Initialize(isGreaterPriority);
        }

        public StableQueue2(PriorityIsGreater2<T> isGreaterPriority, T[] ary)
        {
            Initialize(isGreaterPriority);
            foreach (T element in ary) { Push(element); }
        }

        public int Count
        {
            get { return pq.Count; }
        }

        public void Push(T element)
        {
            pq.Push(new Node<T>(element, insertionCount++));
        }

        public T Pop()
        {
            return pq.Pop().Value;
        }

        public void Remove(T element)
        {
            pq.Remove(new Node<T>(element, -1));
        }

        #region Non-Public Memebers
        int insertionCount = 0;

        struct Node<NT> : IEquatable<Node<NT>>
        {
            public NT Value;
            public int InsertionOrder;

            public Node(NT value, int order)
            {
                Value = value;
                InsertionOrder = order;
            }

            public bool Equals(Node<NT> other)
            {
                return EqualityComparer<NT>.Default.Equals(Value, other.Value);
            }
        }

        Queue2<Node<T>> pq;

        PriorityIsGreater2<T> isGreater;

        bool NodeIsGreater(Node<T> a, Node<T> b)
        {
            if (isGreater(b.Value, a.Value)) { return false; }
            if (isGreater(a.Value, b.Value)) { return true; }
            return a.InsertionOrder < b.InsertionOrder;
        }

        void Initialize(PriorityIsGreater2<T> isGreaterPriority)
        {
            isGreater = isGreaterPriority;
            pq = new Queue2<Node<T>>(NodeIsGreater);
        }
        #endregion
    }

    struct TestThing2
    {
        public string Name;
        public int Value;

        public TestThing2(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString() + Name;
        }
    }

    public class Exercise10
    {
        static readonly string HR = "------------------------";

        static void TestFunc(PQueue2<TestThing2> pq)
        {
            while (pq.Count > 5) { Console.Write(pq.Pop() + ", "); }
            Console.WriteLine(pq.Pop());

            pq.Push(new TestThing2("", 8));
            pq.Push(new TestThing2("", 2));
            pq.Remove(new TestThing2("a", 7));
            pq.Push(new TestThing2("", 6));
            pq.Push(new TestThing2("", 4));

            while (pq.Count > 1) { Console.Write(pq.Pop() + ", "); }
            Console.WriteLine(pq.Pop());
            Console.WriteLine(HR);
        }
        public Exercise10()
        {
            List<TestThing2> list = new List<TestThing2> {
            new TestThing2("", 1),
            new TestThing2("a", 3),
            new TestThing2("a", 5),
            new TestThing2("a", 7),
            new TestThing2("a", 7),
            new TestThing2("", 9),
            new TestThing2("b", 3),
            new TestThing2("b", 5),
            new TestThing2("b", 7),
            new TestThing2("c", 7)
        };

            PriorityIsGreater2<TestThing2> isGreater = (a, b) => a.Value < b.Value;

            PQueue2<TestThing2> pq = new Queue2<TestThing2>(isGreater, list.ToArray());
            TestFunc(pq);
            pq = new StableQueue2<TestThing2>(isGreater, list.ToArray());
            TestFunc(pq);

            List<int> vals = new List<int> { 1, 5, 2, 3, 5, 4, 3, 2, 4 };
            PQueue2<int> queue = new Queue2<int>((a, b) => a > b, vals.ToArray());
            queue.Remove(7);
            queue.Remove(3);
            while (queue.Count > 1) { Console.Write(queue.Pop() + ", "); }
            Console.WriteLine(queue.Pop());
            Console.WriteLine(HR);

            queue = new StableQueue2<int>((a, b) => a > b, vals.ToArray());
            queue.Remove(7);
            queue.Remove(3);
            while (queue.Count > 1) { Console.Write(queue.Pop() + ", "); }
            Console.WriteLine(queue.Pop());
            Console.WriteLine(HR);
        }
    }
}
