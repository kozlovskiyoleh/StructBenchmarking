using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using StructBenchmarking.Abstaract_Factory_Pattern;
namespace StructBenchmarking;

public class Experiments
{
	public static ChartData BuildChartDataForArrayCreation(
		IBenchmark benchmark, int repetitionsCount)
	{
		Data data = new Data(new ArrayCreationFactory(), repetitionsCount);

        return new ChartData
		{
			Title = "Create array",
			ClassPoints = data.GetClassesDurations(),
			StructPoints = data.GetStructuresDyrations(),
		};
	}

	public static ChartData BuildChartDataForMethodCall(
		IBenchmark benchmark, int repetitionsCount)
	{
        Data data = new Data(new MethodCallCreationFactory(), repetitionsCount);
        return new ChartData
		{
			Title = "Call method with argument",
			ClassPoints = data.GetClassesDurations(),
			StructPoints = data.GetStructuresDyrations(),
		};
	}
}