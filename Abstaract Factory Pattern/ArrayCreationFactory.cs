using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructBenchmarking.Abstaract_Factory_Pattern
{
    public class ArrayCreationFactory : ICreationFactory
    {
        public ITask GetStructCreation(int i)
        {
            return new StructArrayCreationTask(Constants.FieldCounts.ElementAt(i));
        }

        public ITask GetClassCreation(int i)
        {
            return new ClassArrayCreationTask(Constants.FieldCounts.ElementAt(i));
        }
    }
}
