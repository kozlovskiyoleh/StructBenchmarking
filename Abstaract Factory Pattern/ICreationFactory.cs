using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructBenchmarking
{
    public interface ICreationFactory
    {
        ITask GetClassCreation(int i);
        ITask GetStructCreation(int i);
    }
}
