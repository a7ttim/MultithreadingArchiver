using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Multithreading
{
    class DecompressionWriteTaskInfo : ITaskInfo
    {
        Int64 _id;
        byte[] _bytes;

        public DecompressionWriteTaskInfo(Int64 id, byte[] bytes)
        {
            _id = id;
            _bytes = bytes;
        }

        public void Execute(object obj)
        {
            FileStream fileStream = obj as FileStream;
            fileStream.Write(_bytes, 0, _bytes.Length);
        }

        public object GetData()
        {
            return _bytes;
        }

        public long GetId()
        {
            return _id;
        }
    }
}
