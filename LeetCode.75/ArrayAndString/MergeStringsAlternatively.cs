using System.Text;

namespace LeetCode._75.ArrayAndString;

public static class MergeStringsAlternatively
{
    public static string WithStringBuilderAndLoops(string word1, string word2)
    {
        // the capacity speeds things up when strings are long,
        // otherwise, it's faster to skip it
        var result = new StringBuilder(word1.Length + word2.Length);

        var i = 0;
        var j = 0;

        // exit when the shortest word ends
        while (i < word1.Length && j < word2.Length)
        {
            result.Append(word1[i++]);
            result.Append(word2[j++]);
        }

        // leftovers
        while (i < word1.Length) result.Append(word1[i++]);
        while (j < word2.Length) result.Append(word2[j++]);

        return result.ToString();
    }

    public static string WithStringBuilderAndIterators(string word1, string word2)
    {
        var length = word1.Length + word2.Length;
        var stringBuilder = new StringBuilder(capacity: length);

        using var enumerator1 = word1.GetEnumerator();
        using var enumerator2 = word2.GetEnumerator();

        while (stringBuilder.Length < length)
        {
            if (enumerator1.MoveNext()) stringBuilder.Append(enumerator1.Current);

            if (enumerator2.MoveNext()) stringBuilder.Append(enumerator2.Current);
        }

        return stringBuilder.ToString();
    }

    public static string WithArrayAndLoops(string word1, string word2)
    {
        var length = word1.Length + word2.Length;

        var array = new char[length];

        var i = 0; // word1 index
        var j = 0; // word2 index
        var k = 0; // array index

        while (k < length)
        {
            if (i < word1.Length) array[k++] = word1[i++];

            if (j < word2.Length) array[k++] = word2[j++];
        }

        return new string(array);
    }
}