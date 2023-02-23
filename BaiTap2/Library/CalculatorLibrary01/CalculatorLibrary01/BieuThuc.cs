using QueueLibraryDemo01;
using StackLibraryDemo01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListLibrary_Demo02;

namespace CalculatorLibrary01
{
    public class BieuThuc
    {
        QUEUE<string> bieuThucHauTo = new QUEUE<string>();
        STACK<double> stack = new STACK<double>();
        public BieuThuc(LINKEDLIST<string> bieuThuc)
        {
            ChuanHoaBieuThuc chuanHoaBieuThuc = new ChuanHoaBieuThuc();
            bieuThucHauTo = chuanHoaBieuThuc.BieuThucHauTo(bieuThuc);
        }
        private double ThucHienPhepTinh()
        {
            double a = stack.Pop();
            double b = stack.Pop();
            double rs = 0;
            switch (bieuThucHauTo.Peek())
            {
                case "+":
                    rs = (a + b);
                    break;
                case "-":
                    rs = (b - a);
                    break;
                case "×":
                    rs = (a * b);
                    break;
                case "÷":
                    rs = ((double)b / a);
                    break;
                default:
                    break;
            }
            return rs;
        }
        public string GiaTriBieuThuc()
        {
            while (!bieuThucHauTo.IsEmptyQueue())
            {
                if (Double.TryParse(bieuThucHauTo.Peek(), out double d))
                    stack.Push(d);
                else
                    stack.Push(ThucHienPhepTinh());
                bieuThucHauTo.DeQueue();
            }
            return stack.Peek().ToString();
        }
    }
}
