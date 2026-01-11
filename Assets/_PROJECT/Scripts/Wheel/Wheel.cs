using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
    [SerializeField] private Image spinImage, indicatorImage;
    [SerializeField] private Button spinButton;
    [SerializeField] private WheelSlice[] slices;

#if UNITY_EDITOR
    void OnValidate()
    {
        spinImage ??= transform.Find("ui_image_spin")?.GetComponent<Image>();
        indicatorImage ??= transform.Find("ui_image_indicator")?.GetComponent<Image>();
        spinButton ??= transform.Find("ui_button_spin")?.GetComponent<Button>();
        slices = GetComponentsInChildren<WheelSlice>();
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
    private void OnZoneStarted(WheelPresetData presetData)
    {
        SetWheel(presetData.spinSprite, presetData.indicatorSprite, presetData.availableSlices);
    }

    private void SetWheel(Sprite spinSprite, Sprite indicatorSprite, List<WheelSliceData> sliceDatas)
    {
        SetVisuals(spinSprite, indicatorSprite);
        SetSlices(sliceDatas);
    }

    private void SetVisuals(Sprite spinSprite, Sprite indicatorSprite)
    {
        spinImage.sprite = spinSprite;
        indicatorImage.sprite = indicatorSprite;
    }

    private void SetSlices(List<WheelSliceData> sliceDatas)
    {
        foreach (var slice in slices)
        {
            var sliceData = sliceDatas.GetRandomElement();
            slice.SetSlice(sliceData);
        }
    }
}
