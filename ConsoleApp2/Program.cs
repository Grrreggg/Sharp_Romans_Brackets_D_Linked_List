using System;
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ToIntRe RomanToIntClass = new ToIntRe();
            Balance BalanceClass = new Balance();
            DoubleLinkedList<string> linkedList = new DoubleLinkedList<string>();

            Console.WriteLine("Перевод числа MMCMXCIX");
            Console.WriteLine(RomanToIntClass.RomanToInt("MMCMXCIX"));

            Console.WriteLine("В выражении ((1+3)()(4+(3-5))) скобки сбалансированы");
            Console.WriteLine(BalanceClass.Check("((1+3)()(4+(3-5)))"));

            Console.WriteLine("Двухсвязный список");

            linkedList.AddLast("Ivan");
            linkedList.AddLast("Boris");
            linkedList.AddFirst("Katya");

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Развернуть");

            linkedList.Reverse();
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

    }
    public class ToIntRe
    {
        private static Dictionary<char, int> Romance = new Dictionary<char, int>
        {
            {'M', 1000},
            {'D', 500 },
            {'C', 100 },
            {'L', 50  },
            {'X', 10  },
            {'V', 5   },
            {'I', 1   },
        };

        public int RomanToInt(string BadRomance)
        {
            int last = 9999;
            int current = 0;
            int res = 0;
            foreach (char c in BadRomance)
            {
                current = Romance[c];

                if (last < current)
                {
                    res -= 2 * last;
                    res += current;
                }
                else
                {
                    res += current;
                    last = current;
                }
            }
            return res;
        }
    }

    public class Balance
    {
        public bool Check(string expression)
        {
            int balance = 0;

            foreach (char c in expression)
            {
                if (c.Equals('('))
                {
                    balance++;
                }
                else if (c.Equals(')'))
                {
                    balance--;
                }
            }
            return balance == 0;
        }
    }

    public class DoubleLinkedListNode<T>
    {
        public DoubleLinkedListNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoubleLinkedListNode<T> Previous { get; set; }
        public DoubleLinkedListNode<T> Next { get; set; }
    }

    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        DoubleLinkedListNode<T> head;
        DoubleLinkedListNode<T> tail;
        int count;

        public void AddLast(T data)
        {
            DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(T data)
        {
            DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(data);
            DoubleLinkedListNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        public bool Remove(T data)
        {
            DoubleLinkedListNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoubleLinkedListNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void Reverse()
        {
            DoubleLinkedListNode<T> temp = null;
            DoubleLinkedListNode<T> current = head;

            while (current != null)
            {
                temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;
                current = current.Previous;
            }
            if (temp != null)
            {
                head = temp.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoubleLinkedListNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
