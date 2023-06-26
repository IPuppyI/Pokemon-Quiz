using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevenshteinDistance
{
    public static int Calculate(string source, string target)
    {
        int sourceLength = source.Length;
        int targetLength = target.Length;

        int[,] distances = new int[sourceLength + 1, targetLength + 1];

        for (int i = 0; i <= sourceLength; i++)
            distances[i, 0] = i;

        for (int j = 0; j <= targetLength; j++)
            distances[0, j] = j;

        for (int i = 1; i <= sourceLength; i++)
        {
            for (int j = 1; j <= targetLength; j++)
            {
                int cost = (source[i - 1] != target[j - 1]) ? 1 : 0;

                distances[i, j] = Mathf.Min(
                    distances[i - 1, j] + 1,
                    distances[i, j - 1] + 1,
                    distances[i - 1, j - 1] + cost
                );
            }
        }

        return distances[sourceLength, targetLength];
    }
}
