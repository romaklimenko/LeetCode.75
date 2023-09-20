using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using LeetCode._75.ArrayAndString;

namespace LeetCode._75.Benchmarks.ArrayAndStrings;

/*
    | Method                                                | Mean      | Error    | StdDev   | Rank | Gen0   | Allocated |
    |------------------------------------------------------ |----------:|---------:|---------:|-----:|-------:|----------:|
    | MergeStringsAlternately_WithArrayAndLoops             |  40.23 ns | 0.302 ns | 0.268 ns |    1 | 0.0178 |     112 B |
    | MergeStringsAlternately_WithStringBuilderAndLoops     |  78.04 ns | 0.712 ns | 0.666 ns |    2 | 0.0254 |     160 B |
    | MergeStringsAlternately_WithStringBuilderAndIterators | 164.99 ns | 0.771 ns | 0.643 ns |    3 | 0.0355 |     224 B |
 */

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class MergeStringsAlternativelyBenchmarks
{
    private const string Word1 = "klmnoprqstu";
    private const string Word2 = "abcde";

    [Benchmark]
    public void MergeStringsAlternately_WithStringBuilderAndIterators()
    {
        MergeStringsAlternatively.WithStringBuilderAndIterators(Word1, Word2);
    }

    [Benchmark]
    public void MergeStringsAlternately_WithStringBuilderAndLoops()
    {
        MergeStringsAlternatively.WithStringBuilderAndLoops(Word1, Word2);
    }

    [Benchmark]
    public void MergeStringsAlternately_WithArrayAndLoops()
    {
        MergeStringsAlternatively.WithArrayAndLoops(Word1, Word2);
    }
}