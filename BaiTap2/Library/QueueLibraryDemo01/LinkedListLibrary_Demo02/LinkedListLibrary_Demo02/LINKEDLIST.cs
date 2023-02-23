using LinkedListLibrary_Demo02;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkedListLibrary_Demo02
{
    public class LINKEDLIST<T>
    {
        NODE<T> Head;
        NODE<T> Tail;

        public LINKEDLIST()
        {
            Head = Tail = null;
        }

        public bool IsEmpty()
        {
            if (Head == null)
                return true;
            return false;
        }

        public int Length()
        {
            int length = 0;
            for (NODE<T> p = Head; p != null; p = p.Next)
                ++length;
            return length;

        }

        public NODE<T> CreataNode(T Data)
        {
            NODE<T> newNode = new NODE<T>(Data);
            if (newNode == null)
                Console.WriteLine("Khong du bo nho!");
            return newNode;
        }

        public NODE<T> Get(int index)
        {
            int count = 0;
            for (NODE<T> p = Head; p != null; p = p.Next)
            {
                if (index == count)
                    return p;
                else ++count;
            }
            return null;
        }

        public T first()
        {
            return Head.Data;
        }

        public T last()
        {
            return Tail.Data;
        }

        public void AddFirst(T Data)
        {
            NODE<T> Node = new NODE<T>(Data);
            if (IsEmpty())
                Head = Tail = Node;
            else
            {
                Head.Prev = Node;
                Node.Next = Head;
                Head = Node;
            }
        }

        public void AddLast(T Data)
        {
            NODE<T> Node = new NODE<T>(Data);
            if (IsEmpty())
                Head = Tail = Node;
            else
            {
                Node.Prev = Tail;
                Tail.Next = Node;
                Tail = Node;
            }
        }

        public void AddNode(NODE<T> q, NODE<T> p)
        {
            if (q == Tail)
                AddLast(p.Data);
            else
            {
                p.Next = q.Next;
                q.Next.Prev = p;
                q.Next = p;
                p.Prev = q;
            }
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
                Console.WriteLine("Danh sach rong!\n");
            else
            {
                if (Head == Tail)
                    Head = Tail = null;
                else
                {
                    NODE<T> Node = Head;
                    Head = Head.Next;
                    Head.Prev = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (IsEmpty())
                Console.WriteLine("Danh sach rong!\n");
            else
            {
                if (Head == Tail)
                    Head = Tail = null;
                else
                {
                    NODE<T> Node = Tail;
                    Tail.Prev.Next = null;
                    Tail = Tail.Prev;
                }
            }
        }

        public void RemoveNode(NODE<T> q)
        {
            NODE<T> p = q.Next;
            if (p == null)
                Console.WriteLine("Khong ton tai phan tu sau q!");
            else
            {
                if (p == Tail)
                    RemoveLast();
                else
                {
                    p.Next.Prev = q;
                    q.Next = p.Next;
                }
            }
        }

        public void RemoveAll()
        {
            Head = Tail = null;
        }

        public void CopyTo(LINKEDLIST<T> myList)
        {
            for (NODE<T> p = myList.Head; p != null; p = p.Next)
            {
                AddLast(p.Data);
            }
        }
       
        public override string ToString()
        {
            string temp = "";
            for (NODE<T> p = Head; p != null; p = p.Next)
                temp += p.Data.ToString();
            return temp;
        }
    }
}
