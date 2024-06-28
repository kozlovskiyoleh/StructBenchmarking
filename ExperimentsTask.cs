using System.Collections.Generic;
using System.Linq;

namespace StructBenchmarking;

public class Experiments
{
	public static ChartData BuildChartDataForArrayCreation(
		IBenchmark benchmark, int repetitionsCount)
	{
		var classesTimes = new List<ExperimentResult>();
		var structuresTimes = new List<ExperimentResult>();

        for (int i = 0;i<Constants.FieldCounts.Count;i++)
		{
			ExperimentResult durationStructuresTimes = new ExperimentResult(Constants.FieldCounts.ElementAt(i),
				benchmark.MeasureDurationInMs(new StructArrayCreationTask(Constants.FieldCounts.ElementAt(i)),10));
            ExperimentResult durationClassesTimes = new ExperimentResult(Constants.FieldCounts.ElementAt(i),
                benchmark.MeasureDurationInMs(new ClassArrayCreationTask(Constants.FieldCounts.ElementAt(i)), 10));
            structuresTimes.Add(durationStructuresTimes);
			classesTimes.Add(durationClassesTimes);
		}

        return new ChartData
		{
			Title = "Create array",
			ClassPoints = classesTimes,
			StructPoints = structuresTimes,
		};
	}

	public static ChartData BuildChartDataForMethodCall(
		IBenchmark benchmark, int repetitionsCount)
	{
		var classesTimes = new List<ExperimentResult>();
		var structuresTimes = new List<ExperimentResult>();
            
		//...

		return new ChartData
		{
			Title = "Call method with argument",
			ClassPoints = classesTimes,
			StructPoints = structuresTimes,
		};
	}
}