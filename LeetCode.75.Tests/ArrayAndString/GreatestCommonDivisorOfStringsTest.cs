using LeetCode._75.ArrayAndString;

namespace LeetCode._75.Tests.ArrayAndString;

public class GreatestCommonDivisorOfStringsTest
{
    public static IEnumerable<object[]> TestData
    {
        get
        {
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var func in new[]
                     {
                         GreatestCommonDivisorOfStrings.GcdOfStrings,
                         GreatestCommonDivisorOfStrings.GcdOfStringsOptimized,
                         GreatestCommonDivisorOfStrings.GcdOfStringsSuperOptimized,
                         GreatestCommonDivisorOfStrings.GcdOfStringsTopLeetCode,
                         GreatestCommonDivisorOfStrings.GcdOfStringsTopLeetCodeBigInteger
                     })
            foreach (var data in new (string str1, string str2, string expected)[]
                     {
                         ("ABCABC", "ABC", "ABC"),
                         ("ABABAB", "ABAB", "AB"),
                         ("LEET", "CODE", ""),
                         ("NLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGM", "NLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGM",
                             "NLZGM"),
                         ("AA", "A", "A")
                     })
                yield return new object[] { func, data.str1, data.str2, data.expected };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void GreatestCommonDivisorOfStrings_ExpectedBehavior(
        Func<string, string, string> func, string str1, string str2, string expected)
    {
        // Act
        var result = func(str1, str2);

        // Assert
        Assert.Equal(expected, result);
    }
}