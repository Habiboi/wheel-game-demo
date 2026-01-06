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
}