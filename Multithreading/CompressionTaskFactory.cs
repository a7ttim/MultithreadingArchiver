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
	public class CompressionTaskFactory : ITaskFactory {

        public ITaskInfo CreateReadTask(Int64 id, Int64 length)
        {
            return new CompressionReadTaskInfo(id, length);
        }

        public ITaskInfo CreateProcessTask(Int64 id, byte[] bytes)
        {
            return new CompressionTaskInfo(id, bytes);
		}

        public ITaskInfo CreateWriteTask(Int64 id, byte[] bytes)
        {
            return new CompressionWriteTaskInfo(id, bytes);
        }
    }
}