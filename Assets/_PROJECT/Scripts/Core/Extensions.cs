using UnityEngine;
using System.Collections.Generic;

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

}