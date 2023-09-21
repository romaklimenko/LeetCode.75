using LeetCode._75.ArrayAndString;

namespace LeetCode._75.Tests.ArrayAndString;

public record TestDataRecord(Func<string, string, string> Fn, string Str1, string Str2, string Expected)
{
    public override string ToString()
    {
        return $"func: \"{Fn.Method.Name}\", str1: \"{Str1}\", str2: \"{Str2}\", expected: \"{Expected}\"";
    }
}

public class GreatestCommonDivisorOfStringsTest
{
    public static IEnumerable<object[]> TestData
    {
        get
        {
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var method in new[]
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
                         (
                             "NLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGM",
                             "NLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGM",
                             "NLZGM"
                         ),
                         ("AA", "A", "A")
                     })
                yield return new object[] { new TestDataRecord(method, data.str1, data.str2, data.expected) };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TestDataRecord input)
    {
        // Act
        var result = input.Fn(input.Str1, input.Str2);

        // Assert
        Assert.Equal(input.Expected, result);
    }
}