using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    public interface IArchiverMode
    {
        bool ProcessFile(FileDescriptor readFile, FileDescriptor writeFile);
    }
}
