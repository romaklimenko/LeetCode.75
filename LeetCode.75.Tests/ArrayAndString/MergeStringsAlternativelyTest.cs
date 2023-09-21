using LeetCode._75.ArrayAndString;

namespace LeetCode._75.Tests.ArrayAndString;

public class MergeStringsAlternativelyTest
{
    public static IEnumerable<object[]> TestData
    {
        get
        {
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var func in new[]
                     {
                         MergeStringsAlternatively.WithStringBuilderAndLoops,
                         MergeStringsAlternatively.WithStringBuilderAndIterators,
                         MergeStringsAlternatively.WithArrayAndLoops
                     })
            foreach (var data in new (string word1, string word2, string expected)[]
                     {
                         ("abc", "pqr", "apbqcr"),
                         ("ab", "pqrs", "apbqrs"),
                         ("abcd", "pq", "apbqcd")
                     })
                yield return new object[]
                {
                    new TestDataRecord(func, data.word1, data.word2, data.expected)
                };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TestDataRecord input)
    {
        // Act
        var result = input.Fn(input.Word1, input.Word2);

        // Assert
        Assert.Equal(input.Expected, result);
    }

    public record TestDataRecord(Func<string, string, string> Fn, string Word1, string Word2, string Expected)
    {
        public override string ToString()
        {
            return $"func: \"{Fn.Method.Name}\", word1: \"{Word1}\", word2: \"{Word2}\", expected: \"{Expected}\"";
        }
    }
}