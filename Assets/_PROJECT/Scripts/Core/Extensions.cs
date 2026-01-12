using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public static class Extensions
{
    public static void RemoveDuplicateReferences<T>(this IList<T> list) where T : class
    {
        if (list == null)
        {
            return;
        }

        HashSet<T> seen = new HashSet<T>();

        for (int i = list.Count - 1; i >= 0; i--)
        {
            T item = list[i];

            if (!seen.Add(item))
            {
                list.RemoveAt(i);
            }
        }
    }

    public static void AddNulls<T>(this IList<T> list, int count) where T : class
    {
        if (count <= 0)
        {
            return;
        }

        for (int i = 0; i < count; i++)
        {
            list.Add(null);
        }
    }

    public static T GetWeightedRandomElement<T>(this IList<T> collection, System.Func<T, int> weightSelector)
    {
        int totalWeight = 0;
        foreach (var item in collection)
        {
            totalWeight += weightSelector(item);
        }

        int randomWeight = Random.Range(0, totalWeight);
        int currentWeight = 0;

        foreach (var item in collection)
        {
            currentWeight += weightSelector(item);
            if (randomWeight < currentWeight)
            {
                return item;
            }
        }
        return collection.Count > 0 ? collection[0] : default;
    }

    public static T GetRandomElement<T>(this IList<T> collection)
    {
        return collection[Random.Range(0, collection.Count)];
    }

    public static int GetRandomIndex(this IList list)
    {
        return Random.Range(0, list.Count);
    }

    public static Color SetColorWithoutAlpha(this Color color, Color newColor)
    {
        newColor.a = color.a;
        return newColor;
    }

    public static string SetColor(this string text, Color color)
    {
        string hex = ColorUtility.ToHtmlStringRGB(color);
        return $"<color=#{hex}>{text}</color>";
    }

    public static string SetAlpha(this string text, float alpha)
    {
        int a = Mathf.RoundToInt(Mathf.Clamp01(alpha) * 255f);
        return $"<alpha=#{a:X2}>{text}</alpha>";
    }

    private static readonly (int Threshold, int Divisor, string Suffix)[] REWARD_FORMAT =
    {
    (1_000_000_000, 1_000_000_000, "B"),
    (1_000_000,     1_000_000,     "M"),
    (1_000,         1_000,         "K"),
    };

    public static string GetRewardText(this int value)
    {
        foreach (var (threshold, divisor, suffix) in REWARD_FORMAT)
        {
            if (value >= threshold)
            {
                return $"x{value / divisor}{suffix}";
            }
        }

        return $"x{value}";
    }
}