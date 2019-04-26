///////////////////////////////////////////////////////////
//  TaskPool.cs
//  Implementation of the Class TaskPool
//  Generated by Enterprise Architect
//  Created on:      15-���-2019 23:18:23
//  Original author: A7tti
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Collections;

namespace Multithreading
{
	public class HashtableTaskPool
    {
        private Hashtable _tasksInfo;
        private Int64 _last = 0;

        public bool IsHasTasks()
        {
            return _tasksInfo.Count > 0;
        }

        public int TaskCount()
        {
            return _tasksInfo.Count;
        }

        public HashtableTaskPool()
        {
            _tasksInfo = new Hashtable();
        }

        public void AddTask(ITaskInfo task)
        {
            lock (this)
            {
                _tasksInfo.Add(task.GetId(), task);
            }
        }

        public ITaskInfo NextTask()
        {
            ITaskInfo task = null;
            lock (this)
            {
                if (IsHasTasks())
                {
                    if (_tasksInfo.ContainsKey(_last))
                    {
                        task = _tasksInfo[_last] as ITaskInfo;
                        _tasksInfo.Remove(_last++);
                    }
                }
            }
            return task;
        }
	}
}