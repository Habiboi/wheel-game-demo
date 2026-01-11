using Project.Core.Enums;
using TMPro;
using UnityEngine;

public class WheelNextZone : MonoBehaviour
{
    [SerializeField] private WheelPresetData presetData;
    [SerializeField] private TextMeshProUGUI counterText;

#if UNITY_EDITOR
    void OnValidate()
    {
        counterText ??= transform.Find("ui_text_counter")?.GetComponent<TextMeshProUGUI>();
    }
#endif

    private void OnEnable()
    {
        EventManager.wheelStarted.AddListener(OnWheelStarted);
        EventManager.zoneStarted.AddListener(OnZoneStarted);
    }
    private void OnDisable()
    {
        EventManager.wheelStarted.RemoveListener(OnWheelStarted);
        EventManager.zoneStarted.RemoveListener(OnZoneStarted);
    }
    private void OnWheelStarted()
    {
        SetNextZone(presetData.interval);
    }
    private void OnZoneStarted(int zoneIndex, WheelPresetData zonePresetData)
    {
        if (zonePresetData.Equals(presetData))
        {
            SetNextZone(zoneIndex + presetData.interval);
        }
    }

    private void SetNextZone(int nextZoneIndex)
    {
        counterText.text = nextZoneIndex.ToString();
    }
}
