using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueLibraryDemo01;
using StackLibraryDemo01;
using LinkedListLibrary_Demo02;

namespace CalculatorLibrary01
{
    internal class ChuanHoaBieuThuc
    {
        STACK<string> stack = new STACK<string>();
        QUEUE<string> queue = new QUEUE<string>();
        public int UuTien(string c)
        {
            if (c == "+" || c == "-")
                return 1;
            if (c == "÷" || c == "×")
                return 2;
            return 0;
        }
        public QUEUE<string> BieuThucHauTo(LINKEDLIST<string> bieuThuc)
        {
            while (!bieuThuc.IsEmpty())
            {
                string value = bieuThuc.first();
                bieuThuc.RemoveFirst();

                if (Double.TryParse(value, out double d))
                {
                    queue.EnQueue(value);
                }
                else if (stack.IsEmptyStack() || value == "(")
                {
                    stack.Push(value);
                }
                else if (value == ")")
                {
                    while (!stack.IsEmptyStack() && stack.Peek() != "(")
                    {
                        queue.EnQueue(stack.Pop());
                    }
                    stack.Pop();
                }
                else
                {
                    while (!stack.IsEmptyStack() && UuTien(value) <= UuTien(stack.Peek()))
                    {
                        queue.EnQueue(stack.Pop());
                    }
                    stack.Push(value);
                }
            }
            while (!stack.IsEmptyStack())
            {
                queue.EnQueue(stack.Pop());
            }
            return queue;
        }
    }
}
