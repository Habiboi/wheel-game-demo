using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ZoneRuleData", menuName = "Scriptable Objects/ZoneRuleData")]
public class ZoneRuleData : ScriptableObject
{
    public List<WheelPresetData> presets = new();

    void OnValidate()
    {
        if (presets == null)
        {
            return;
        }

        int nullCount = presets.RemoveAll(x => x == null);

        presets.RemoveDuplicateReferences();
        presets = presets.OrderByDescending(x => x.interval).ToList();
        presets.AddNulls(nullCount);
    }
}
