///////////////////////////////////////////////////////////
//  HashtableTaskPool.cs
//  Implementation of the Class HashtableTaskPool
//  Generated by Enterprise Architect
//  Created on:      15-апр-2019 23:18:23
//  Original author: A7ttim
///////////////////////////////////////////////////////////

using System;
using System.Collections;

namespace MultithreadingArchiver
{
    /// <summary>
    /// Класс для инкапсуляции добавления и упорядоченного получения задач
    /// </summary>
	class HashtableTaskPool : IArchiverTaskPool
    {
        /// <summary>
        /// Коллекция для хранения описаний задач
        /// </summary>
        private Hashtable _tasksInfo;
        private Int64 _last = 0;

        private bool IsHasTasks()
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