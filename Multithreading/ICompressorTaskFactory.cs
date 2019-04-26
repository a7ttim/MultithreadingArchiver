///////////////////////////////////////////////////////////
//  ICompressorTaskFactory.cs
//  Implementation of the Interface ICompressorTaskFactory
//  Generated by Enterprise Architect
//  Created on:      15-���-2019 23:19:29
//  Original author: A7ttim
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Multithreading
{
	public interface ICompressorTaskFactory : ITaskFactory
    {
		ITaskInfo CreateCompressionTask(Int64 id, byte[] bytes);
        ITaskInfo CreateCompressionWriteTask(Int64 id, byte[] bytes);
    }
}