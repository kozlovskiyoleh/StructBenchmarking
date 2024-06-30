using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructBenchmarking.Abstaract_Factory_Pattern
{
    public class Data
    {
        private List<ExperimentResult> _classesDurations = new();
        private List<ExperimentResult> _structDurations = new();

        public Data(ICreationFactory factory, int repetitionsCount) 
        {
            Benchmark benchmark = new Benchmark();
            for (int i = 0; i < Constants.FieldCounts.Count; i++)
            {
                ExperimentResult durationStructuresTimes = new ExperimentResult(Constants.FieldCounts.ElementAt(i),
                    benchmark.MeasureDurationInMs(factory.GetStructCreation(i), repetitionsCount));
                ExperimentResult durationClassesTimes = new ExperimentResult(Constants.FieldCounts.ElementAt(i),
                    benchmark.MeasureDurationInMs(factory.GetClassCreation(i), repetitionsCount));
                _structDurations.Add(durationStructuresTimes);
                _classesDurations.Add(durationClassesTimes);
            }
        }

        public List<ExperimentResult> GetClassesDurations() => _classesDurations;

        public List<ExperimentResult> GetStructuresDyrations() => _structDurations;
    }
}
