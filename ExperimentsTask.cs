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
				benchmark.MeasureDurationInMs(new StructArrayCreationTask(Constants.FieldCounts.ElementAt(i)),repetitionsCount));
            ExperimentResult durationClassesTimes = new ExperimentResult(Constants.FieldCounts.ElementAt(i),
                benchmark.MeasureDurationInMs(new ClassArrayCreationTask(Constants.FieldCounts.ElementAt(i)), repetitionsCount));
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
        for(int i = 0; i < Constants.FieldCounts.Count; i++)
		{
			ExperimentResult durationClasses = new ExperimentResult(Constants.FieldCounts.ElementAt(i),
				benchmark.MeasureDurationInMs(new MethodCallWithClassArgumentTask(Constants.FieldCounts.ElementAt(i)), repetitionsCount));
            ExperimentResult durationStructures = new ExperimentResult(Constants.FieldCounts.ElementAt(i),
                benchmark.MeasureDurationInMs(new MethodCallWithStructArgumentTask(Constants.FieldCounts.ElementAt(i)), repetitionsCount));
            structuresTimes.Add(durationStructures);
            classesTimes.Add(durationClasses);
        }

		return new ChartData
		{
			Title = "Call method with argument",
			ClassPoints = classesTimes,
			StructPoints = structuresTimes,
		};
	}
}