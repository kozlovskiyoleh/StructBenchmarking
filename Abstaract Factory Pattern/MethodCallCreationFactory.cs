using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructBenchmarking.Abstaract_Factory_Pattern
{
    public class MethodCallCreationFactory : ICreationFactory
    {
        public ITask GetClassCreation(int i)
        {
            return new MethodCallWithClassArgumentTask(Constants.FieldCounts.ElementAt(i));
        }

        public ITask GetStructCreation(int i)
        {
            return new MethodCallWithStructArgumentTask(Constants.FieldCounts.ElementAt(i));
        }
    }
}
