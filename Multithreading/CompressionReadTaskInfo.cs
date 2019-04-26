using System;
using System.IO;

namespace Multithreading
{
    class CompressionReadTaskInfo : ITaskInfo
    {
        private Int64 _id;
        private int _length;

        public CompressionReadTaskInfo(Int64 id, Int64 length)
        {
            _id = id;
            _length = (int)length;
        }

        public object Execute(object obj)
        {
            FileStream file = obj as FileStream;
            byte[] buffer = new byte[_length];
            file.Read(buffer, 0, _length);
            return buffer;
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
