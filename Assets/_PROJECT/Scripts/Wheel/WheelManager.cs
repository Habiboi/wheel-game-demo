using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WheelManager : MonoBehaviour
{
    [SerializeField] private ZoneRuleData zoneRuleData;

    private List<WheelPresetData> wheelPresetsByInterval;

    private int currentZone = 1;

    private void Awake()
    {
        wheelPresetsByInterval = zoneRuleData.presets.OrderByDescending(x => x.interval).ToList();
    }

    private void OnEnable()
    {
        EventManager.zoneEnded.AddListener(OnZoneEnded);
    }
    private void OnDisable()
    {
        EventManager.zoneEnded.RemoveListener(OnZoneEnded);
    }
    private void OnZoneEnded()
    {
        currentZone++;
        SetZone();
    }

    private void Start()
    {
        EventManager.wheelStarted.Invoke();
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
