using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    public interface IArchiverTaskPool
    {
        bool IsHasTasks();
        int TaskCount();
        void AddTask(ITaskInfo task);
        ITaskInfo NextTask();
    }
}
