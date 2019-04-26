using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    class ReadTaskInfo : ITaskInfo
    {
        private Int64 _id;
        private int _length;

        public ReadTaskInfo(Int64 id, Int64 length)
        {
            _id = id;
            _length = (int)length;
        }

        public void Execute(object obj)
        {
        }

        public object GetData()
        {
            return _length;
        }

        public long GetId()
        {
            return _id;
        }
    }
}
