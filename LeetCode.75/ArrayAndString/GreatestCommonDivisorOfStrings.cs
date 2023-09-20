using System.Numerics;

namespace LeetCode._75.ArrayAndString;

/// <summary>
///     For two strings s and t, we say "t divides s" if and only if s = t + ... + t
///     (i.e., t is concatenated with itself one or more times).
///     Given two strings str1 and str2,
///     return the largest string x such that x divides both str1 and str2.
///     https://leetcode.com/problems/greatest-common-divisor-of-strings/description/
/// </summary>
public static class GreatestCommonDivisorOfStrings
{
    public static string GcdOfStrings(string str1, string str2)
    {
        var gcd = string.Empty;

        var shortestStringLength = Math.Min(str1.Length, str2.Length);

        for (var length = 1; length <= shortestStringLength; length++)
        {
            var currentGcd = str1.Substring(0, length);
            if (str1.Split(currentGcd).All(x => x == string.Empty) &&
                str2.Split(currentGcd).All(x => x == string.Empty))
                gcd = currentGcd;
        }

        return gcd;
    }

    public static string GcdOfStringsOptimized(string str1, string str2)
    {
        for (var length = Math.Min(str1.Length, str2.Length); length > 0; length--)
        {
            var gcd = str1.Substring(0, length);

            if (str1.Split(gcd).All(x => x == string.Empty) &&
                str2.Split(gcd).All(x => x == string.Empty))
                return gcd;
        }

        return string.Empty;
    }

    public static string GcdOfStringsSuperOptimized(string str1, string str2)
    {
        for (var length = Math.Min(str1.Length, str2.Length); length > 0; length--)
        {
            var gcd = str1.Substring(0, length);

            var split1 = str1.Split(gcd);
            for (var i = 0; i < split1.Length; i++)
            {
                if (split1[i] == string.Empty) continue;
                goto EXIT;
            }

            var split2 = str2.Split(gcd);
            for (var i = 0; i < split2.Length; i++)
            {
                if (split2[i] == string.Empty) continue;
                goto EXIT;
            }

            return gcd;

            EXIT: ; // GOTO FTW!
        }

        return string.Empty;
    }

    // https://leetcode.com/problems/greatest-common-divisor-of-strings/solutions/3125530/c-simple-solution-java-beats-92/
    public static string GcdOfStringsTopLeetCode(string str1, string str2)
    {
        var len1 = str1.Length;
        var len2 = str2.Length;
        if (!(str1 + str2).Equals(str2 + str1)) return string.Empty; // smart!
        var index = Gcd(len1, len2);
        return str1.Substring(0, index);

        int Gcd(int n1, int n2)
        {
            return n2 == 0 ? n1 : Gcd(n2, n1 % n2);
        }
    }

    public static string GcdOfStringsTopLeetCodeBigInteger(string str1, string str2)
    {
        var len1 = str1.Length;
        var len2 = str2.Length;
        if (!(str1 + str2).Equals(str2 + str1)) return string.Empty; // smart!
        var index = BigInteger.GreatestCommonDivisor(len1, len2); // wow!
        return str1.Substring(0, (int)index);
    }
}