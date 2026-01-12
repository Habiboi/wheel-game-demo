using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
    [SerializeField] private Image spinImage, indicatorImage;
    [SerializeField] private Button spinButton;
    [SerializeField] private WheelSlice[] slices;
    [SerializeField] private WheelSpinEffectData spinEffectData;

    private RectTransform wheelTransform;
    private WheelSlice selectedSlice;

#if UNITY_EDITOR
    void OnValidate()
    {
        spinImage ??= transform.Find("ui_image_spin")?.GetComponent<Image>();
        indicatorImage ??= transform.Find("ui_image_indicator")?.GetComponent<Image>();
        spinButton ??= transform.Find("ui_button_spin")?.GetComponent<Button>();
        slices = GetComponentsInChildren<WheelSlice>();
    }
#endif

    private void Awake()
    {
        wheelTransform = spinImage.rectTransform;
        spinButton.onClick.AddListener(Spin);
    }

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
        SetWheel(zoneIndex, presetData.spinSprite, presetData.indicatorSprite, presetData.availableSlices, presetData.allowBomb);
        spinButton.interactable = true;
    }

    private void SetWheel(int zoneIndex, Sprite spinSprite, Sprite indicatorSprite, List<WheelSliceData> sliceDatas, bool allowBomb)
    {
        SetVisuals(spinSprite, indicatorSprite);
        SetSlices(sliceDatas, zoneIndex);

        if (allowBomb)
        {
            SetBomb();
        }
    }

    private void SetVisuals(Sprite spinSprite, Sprite indicatorSprite)
    {
        spinImage.sprite = spinSprite;
        indicatorImage.sprite = indicatorSprite;
    }

    private void SetSlices(List<WheelSliceData> sliceDatas, int zoneIndex)
    {
        foreach (var slice in slices)
        {
            var sliceData = sliceDatas.GetRandomElement();
            slice.SetSlice(sliceData, zoneIndex);
        }
    }

    private void SetBomb()
    {
        slices.GetRandomElement().SetBomb(true);
    }

    private void Spin()
    {
        spinButton.interactable = false;
        int sliceIndex = slices.GetRandomIndex();
        selectedSlice = slices[sliceIndex];
        SpinToIndex(sliceIndex);
    }

    private void SpinToIndex(int index)
    {
        float stepAngle = 360f / slices.Length;
        float targetAngle = index * stepAngle;
        float currentAngle = wheelTransform.localEulerAngles.z;
        float fullRotations = -360f * spinEffectData.extraSpinCount;

        float finalAngle = currentAngle + fullRotations + Mathf.DeltaAngle(currentAngle, targetAngle);

        wheelTransform.DOLocalRotate(Vector3.forward * finalAngle, spinEffectData.duration, RotateMode.FastBeyond360).SetEase(spinEffectData.ease).OnComplete(() =>
        {
            EventManager.sliceSelected.Invoke(selectedSlice);
        });
    }
}
