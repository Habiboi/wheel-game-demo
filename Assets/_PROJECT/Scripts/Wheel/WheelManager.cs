using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WheelManager : MonoBehaviour
{
    [SerializeField] private ZoneRuleData zoneRuleData;
    [SerializeField] private WheelNextZone[] wheelNextZones;

    private List<WheelPresetData> wheelPresetsByInterval;

    private int currentZone = 1;

#if UNITY_EDITOR
    void OnValidate()
    {
        wheelNextZones ??= FindObjectsByType<WheelNextZone>(FindObjectsSortMode.None);
    }
#endif

    private void Awake()
    {
        wheelPresetsByInterval = zoneRuleData.presets.OrderByDescending(x => x.interval).ToList();

        foreach (var wheelNextZone in wheelNextZones)
        {
            var data = wheelPresetsByInterval.Find(x => x.zoneType.Equals(wheelNextZone.ZoneType));
            wheelNextZone.SetNextZone(data.interval);
        }
    }

    void Start()
    {
        SetZone();
    }

    private void SetZone()
    {
        EventManager.zoneStarted.Invoke(currentZone, GetPresetData());
    }

    private WheelPresetData GetPresetData()
    {
        foreach (var preset in wheelPresetsByInterval)
        {
            if (currentZone % preset.interval == 0)
            {
                return preset;
            }
        }

        return null;
    }
}
