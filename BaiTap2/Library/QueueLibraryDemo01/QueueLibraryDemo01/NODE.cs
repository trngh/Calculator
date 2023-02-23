using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLibraryDemo01
{
    public class NODE<T>
    {
        public T data;
        public NODE<T> next;
        public NODE(T data)
        {
            this.data = data;
            next = null;
        }
    }
}
