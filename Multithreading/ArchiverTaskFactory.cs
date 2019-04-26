///////////////////////////////////////////////////////////
//  TaskFactory.cs
//  Implementation of the Class TaskFactory
//  Generated by Enterprise Architect
//  Created on:      15-���-2019 23:18:23
//  Original author: A7ttim
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Multithreading
{
	public class ArchiverTaskFactory : IUnzipperTaskFactory, ICompressorTaskFactory {

        ITaskInfo IUnzipperTaskFactory.CreateDecompressionTask(Int64 id, byte[] bytes){
            return new DecompressionTaskInfo(id, bytes);
		}

        ITaskInfo ICompressorTaskFactory.CreateCompressionTask(Int64 id, byte[] bytes)
        {
            return new CompressionTaskInfo(id, bytes);
		}

        ITaskInfo ICompressorTaskFactory.CreateCompressionWriteTask(Int64 id, byte[] bytes)
        {
            return new CompressionWriteTaskInfo(id, bytes);
        }

        ITaskInfo IUnzipperTaskFactory.CreateDecompressionWriteTask(Int64 id, byte[] bytes)
        {
            return new DecompressionWriteTaskInfo(id, bytes);
        }

       ITaskInfo ITaskFactory.CreateReadTask(Int64 id, Int64 length)
        {
            return new ReadTaskInfo(id, length);
        }
    }
}