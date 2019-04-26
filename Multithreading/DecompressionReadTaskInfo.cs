using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Multithreading
{
    class DecompressionReadTaskInfo : ITaskInfo
    {
        private Int64 _id;
        private int _length;

        public DecompressionReadTaskInfo(Int64 id, Int64 length)
        {
            _id = id;
            _length = (int)length;
        }

        public object Execute(object obj)
        {
            FileStream file = obj as FileStream;

            // Чтение размеров блоков
            byte[] lengthBuffer = new byte[8];
            file.Read(lengthBuffer, 0, lengthBuffer.Length);
            int blockLength = BitConverter.ToInt32(lengthBuffer, 4);

            // Чтение блоков
            byte[] compressedData = new byte[blockLength];
            lengthBuffer.CopyTo(compressedData, 0);
            file.Read(compressedData, 8, blockLength - 8);

            return compressedData;
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
