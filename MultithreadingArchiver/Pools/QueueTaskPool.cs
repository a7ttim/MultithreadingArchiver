///////////////////////////////////////////////////////////
//  QueueTaskPool.cs
//  Implementation of the Class QueueTaskPool
//  Generated by Enterprise Architect
//  Created on:      15-апр-2019 23:18:23
//  Original author: A7ttim
///////////////////////////////////////////////////////////

using System.Collections.Generic;

namespace MultithreadingArchiver
{
    /// <summary>
    /// Класс для инкапсуляции добавления и получения задач
    /// </summary>
    class QueueTaskPool : IArchiverTaskPool
    {
        /// <summary>
        /// Коллекция для хранения описаний задач
        /// </summary>
        private Queue<ITaskInfo> _tasksInfo;

        private bool IsHasTasks()
        {
            return _tasksInfo.Count > 0;
        }

        public int TaskCount()
        {
            return _tasksInfo.Count;
        }

        public QueueTaskPool()
        {
            _tasksInfo = new Queue<ITaskInfo>();
        }

        public void AddTask(ITaskInfo task)
        {
            lock (this)
            {
                _tasksInfo.Enqueue(task);
            }
        }

        public ITaskInfo NextTask()
        {
            ITaskInfo task = null;
            lock (this)
            {
                if (IsHasTasks())
                {
                    task = _tasksInfo.Dequeue();
                }
            }
            return task;
        }
}
}