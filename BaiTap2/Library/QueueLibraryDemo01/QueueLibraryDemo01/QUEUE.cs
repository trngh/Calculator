using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QueueLibraryDemo01
{
    public class QUEUE<T>
    {
        NODE<T> head;
        NODE<T> tail;

        public void InitQueue()
        {
            head = tail = null;
        }
        public bool IsEmptyQueue()
        {
            if (head == null)
                return true;
            return false;
        }
        public NODE<T> CreateQueue(T data)
        {
            NODE<T> p = new NODE<T>(data);
            if (p == null)
            {
                Console.WriteLine("Khong du bo nho!");
                return null;
            }
            return p;
        }
        public void EnQueue(T data)
        {
            NODE<T> p = CreateQueue(data);
            if (IsEmptyQueue())
                head = tail = p;
            else
            {
                tail.next = p;
                tail = p;
            }
        }
        public T DeQueue()
        {
            if (IsEmptyQueue())
            {
                Console.WriteLine("Danh sach rong!");
                return default(T);
            }
            T data = head.data;
            head = head.next;
            return data;
        }
        public T Peek()
        {
            if (IsEmptyQueue())
            {
                Console.WriteLine("Danh sach rong!");
                return default(T);
            }
            return head.data;
        }
    }
}
