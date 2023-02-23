using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StackLibraryDemo01
{
    public class STACK<T>
    {
        Node<T> top;
        public void InitStack()
        {
            top = null;
        }
        public bool IsEmptyStack()
        {
            if (top == null)
                return true;
            return false;
        }
        public Node<T> CreateNode(T data)
        {
            Node<T> p = new Node<T>(data);
            if (p == null)
            {
                Console.WriteLine("Khong du bo nho");
                return null;
            }
            return p;
        }
        public void Push(T data)
        {
            Node<T> p = CreateNode(data);
            p.next = top;
            top = p;
        }
        public T Peek()
        {
            return top.data;
        }
        public T Pop()
        {
            T sp = top.data;
            top = top.next;
            return sp;
        }
    }
}
