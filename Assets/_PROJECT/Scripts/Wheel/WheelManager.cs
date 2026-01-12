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
        EventManager.wheelRestarted.AddListener(OnWheelRestarted);
    }
    private void OnDisable()
    {
        EventManager.zoneEnded.RemoveListener(OnZoneEnded);
        EventManager.wheelRestarted.RemoveListener(OnWheelRestarted);
    }
    private void OnZoneEnded()
    {
        currentZone++;
        SetZone();
    }
    private void OnWheelRestarted()
    {
        currentZone = 1;
        ResetWheel();
    }

    private void Start()
    {
        ResetWheel();
    }

    private void ResetWheel()
    {
        EventManager.wheelStarted.Invoke();
        SetZone();
    }
    private void SetZone()
    {
        EventManager.zoneStarted.Invoke(currentZone, GetPresetData(currentZone));
    }

    private WheelPresetData GetPresetData(int index)
    {
        foreach (var preset in wheelPresetsByInterval)
        {
            if (index % preset.interval == 0)
            {
                return preset;
            }
        }

        return null;
    }

    public Color GetZoneColor(int zoneIndex)
    {
        if (zoneIndex <= 0)
        {
            return Color.white;
        }

        return GetPresetData(zoneIndex).color;
    }
}
