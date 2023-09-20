using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using LeetCode._75.ArrayAndString;

namespace LeetCode._75.Benchmarks.ArrayAndStrings;

/*
| Method                                               | Mean        | Error     | StdDev    | Rank | Gen0   | Allocated |
   |----------------------------------------------------- |------------:|----------:|----------:|-----:|-------:|----------:|
   | GreatestCommonDivisorOfStrings_TopLeetCode           |    99.59 ns |  0.808 ns |  0.716 ns |    1 | 0.0663 |     416 B |
   | GreatestCommonDivisorOfStrings_TopLeetCodeBigInteger |    99.81 ns |  0.663 ns |  0.588 ns |    1 | 0.0663 |     416 B |
   | GreatestCommonDivisorOfStrings_SuperOptimized        | 3,221.23 ns | 15.961 ns | 14.930 ns |    2 | 1.0185 |    6408 B |
   | GreatestCommonDivisorOfStrings_Optimized             | 6,420.47 ns | 30.688 ns | 27.204 ns |    3 | 1.2207 |    7688 B |
   | GreatestCommonDivisorOfStrings_FirstSubmission       | 8,391.74 ns | 99.714 ns | 88.394 ns |    4 | 1.4648 |    9280 B |
 */

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class GreatestCommonDivisorOfStringsBenchmarks
{
    private const string Str1 = "NLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGM";
    private const string Str2 = "NLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGM";

    [Benchmark]
    public void GreatestCommonDivisorOfStrings_FirstSubmission()
    {
        GreatestCommonDivisorOfStrings.GcdOfStrings(Str1, Str2);
    }

    [Benchmark]
    public void GreatestCommonDivisorOfStrings_Optimized()
    {
        GreatestCommonDivisorOfStrings.GcdOfStringsOptimized(Str1, Str2);
    }

    [Benchmark]
    public void GreatestCommonDivisorOfStrings_SuperOptimized()
    {
        GreatestCommonDivisorOfStrings.GcdOfStringsSuperOptimized(Str1, Str2);
    }

    [Benchmark]
    public void GreatestCommonDivisorOfStrings_TopLeetCode()
    {
        GreatestCommonDivisorOfStrings.GcdOfStringsTopLeetCode(Str1, Str2);
    }

    [Benchmark]
    public void GreatestCommonDivisorOfStrings_TopLeetCodeBigInteger()
    {
        GreatestCommonDivisorOfStrings.GcdOfStringsTopLeetCodeBigInteger(Str1, Str2);
    }
}