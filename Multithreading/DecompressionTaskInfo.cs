///////////////////////////////////////////////////////////
//  DecompressionTask.cs
//  Implementation of the Class DecompressionTask
//  Generated by Enterprise Architect
//  Created on:      15-���-2019 23:18:23
//  Original author: A7ttim
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.IO.Compression;

namespace Multithreading
{
    /// <summary>
    /// ����� �������� ������ ����������
    /// </summary>
    public class DecompressionTaskInfo : ITaskInfo
    {
        private Int64 _id;
        private byte[] _bytes;

        public DecompressionTaskInfo(Int64 id, byte[] bytes)
        {
            _id = id;
            _bytes = bytes;
        }

        /// <summary>
        /// ���������� �������� ��� �������. ���������� ��� ������������ ������ ������, 
        /// ����� ������������ ������ ������
        /// </summary>
        /// <param name="obj">
        /// ������ ��������� ��� ������
        /// </param>
        public object Execute(object obj)
        {
            byte[] buffer = obj as byte[];
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (GZipStream compressStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    compressStream.Read(_bytes, 0, _bytes.Length);
                    buffer = _bytes.ToArray();
                }
            }
            return null;
        }

        public object GetData()
        {
            return _bytes;
        }

        public Int64 GetId()
        {
            return _id;
        }
    }
}