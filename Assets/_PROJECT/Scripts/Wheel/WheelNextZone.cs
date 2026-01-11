using Project.Core.Enums;
using TMPro;
using UnityEngine;

public class WheelNextZone : MonoBehaviour
{
    [SerializeField] private ZoneType zoneType;
    [SerializeField] private TextMeshProUGUI counterText;

    public ZoneType ZoneType { get => zoneType; }

#if UNITY_EDITOR
    void OnValidate()
    {
        counterText ??= transform.Find("ui_text_counter")?.GetComponent<TextMeshProUGUI>();

        if (transform.name.EndsWith("super"))
        {
            zoneType = ZoneType.Super;
        }
        else if (transform.name.EndsWith("safe"))
        {
            zoneType = ZoneType.Safe;
        }
    }
#endif

    private void OnEnable()
    {
        EventManager.zoneStarted.AddListener(OnZoneStarted);
    }
    private void OnDisable()
    {
        EventManager.zoneStarted.RemoveListener(OnZoneStarted);
    }
    private void OnZoneStarted(int zoneIndex, WheelPresetData presetData)
    {
        if (presetData.zoneType.Equals(zoneType))
        {
            SetNextZone(zoneIndex + presetData.interval);
        }
    }

    public void SetNextZone(int nextZoneIndex)
    {
        counterText.text = nextZoneIndex.ToString();
    }
}
