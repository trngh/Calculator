using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary_Demo02
{
    public class NODE<T>
    {
        public T Data { get; set; }
        public NODE<T> Next { get; set; }
        public NODE<T> Prev { get; set; }
        public NODE(T Data)
        {
            this.Data = Data;
            Next = null;
            Prev = null;
        }
    }
}
