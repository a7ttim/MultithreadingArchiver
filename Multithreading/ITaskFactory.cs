﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    public interface ITaskFactory
    {
        ITaskInfo CreateReadTask(Int64 id, Int64 length);
    }
}
