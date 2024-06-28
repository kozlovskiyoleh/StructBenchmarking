using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace StructBenchmarking;


public class StringBuilderTest : ITask
{
    public void Run()
    {
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < 10000; i++)
        {
            str.Append('a');
        }
        str.ToString();
    }
}

public class StringConstructorTest : ITask
{
    public void Run() => new string('a', 10000);
}

public class Benchmark : IBenchmark
{
    public double MeasureDurationInMs(ITask task, int repetitionCount)
    {
        GC.Collect();                   // Эти две строчки нужны, чтобы уменьшить вероятность того,
        GC.WaitForPendingFinalizers();  // что Garbadge Collector вызовется в середине измерений
                                        // и как-то повлияет на них.
        Stopwatch sw = new Stopwatch();
        task.Run();
        sw.Start();
        for(int i = 0;i < repetitionCount;i++)
        {
            task.Run();
        }
        sw.Stop();
        double elapsed = sw.Elapsed.Milliseconds;
        return elapsed/repetitionCount;

    }
}

//Refactor names of variables
[TestFixture]
public class RealBenchmarkUsageSample
{
    [Test]
    public void StringConstructorFasterThanStringBuilder()
    {
        StringBuilderTest stringBuilder = new StringBuilderTest();
        StringConstructorTest stringConstructor = new StringConstructorTest();
        Benchmark benchmark = new Benchmark();
        double stringBuilderDuration = benchmark.MeasureDurationInMs(stringBuilder, 7500);
        double stringConstructorDuration = benchmark.MeasureDurationInMs(stringBuilder, 7500);
        Assert.Less(stringConstructorDuration, stringBuilderDuration);
    }
}