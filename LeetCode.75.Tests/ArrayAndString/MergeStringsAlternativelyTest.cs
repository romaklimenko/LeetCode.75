using LeetCode._75.ArrayAndString;

namespace LeetCode._75.Tests.ArrayAndString;

public class MergeStringsAlternativelyTest
{
    public static IEnumerable<object[]> TestData
    {
        get
        {
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var merge in new[]
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
                yield return new object[] { merge, data.word1, data.word2, data.expected };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void MergeAlternately_StateUnderTest_ExpectedBehavior(
        Func<string, string, string> merge, string word1, string word2, string expected)
    {
        // Act
        var result = merge(word1, word2);

        // Assert
        Assert.Equal(expected, result);
    }
}