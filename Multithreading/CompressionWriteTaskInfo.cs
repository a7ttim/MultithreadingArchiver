using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Multithreading
{
    class CompressionWriteTaskInfo : ITaskInfo
    {
        Int64 _id;
        byte[] _bytes;

        public CompressionWriteTaskInfo(Int64 id, byte[] bytes)
        {
            _id = id;
            _bytes = bytes;
        }

        public object Execute(object obj)
        {
            FileStream fileStream = obj as FileStream;
            // В первых 4х байтах длина куска данных
            BitConverter.GetBytes(_bytes.Length).CopyTo(_bytes, 4);
            fileStream.Write(_bytes, 0, _bytes.Length);
            return null;
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
