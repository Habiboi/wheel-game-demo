using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
    [SerializeField] private Image spinImage, indicatorImage;
    [SerializeField] private Button spinButton;
    [SerializeField] private WheelSlice[] slices;

    private RectTransform wheelTransform;

#if UNITY_EDITOR
    void OnValidate()
    {
        spinImage ??= transform.Find("ui_image_spin")?.GetComponent<Image>();
        indicatorImage ??= transform.Find("ui_image_indicator")?.GetComponent<Image>();
        spinButton ??= transform.Find("ui_button_spin")?.GetComponent<Button>();
        slices = GetComponentsInChildren<WheelSlice>();

        spinButton.onClick.AddListener(Spin);
    }
#endif

    private void Awake()
    {
        wheelTransform = spinImage.rectTransform;
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
        SetWheel(presetData.spinSprite, presetData.indicatorSprite, presetData.availableSlices, presetData.allowBomb);
    }

    private void SetWheel(Sprite spinSprite, Sprite indicatorSprite, List<WheelSliceData> sliceDatas, bool allowBomb)
    {
        SetVisuals(spinSprite, indicatorSprite);
        SetSlices(sliceDatas);

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

    private void SetSlices(List<WheelSliceData> sliceDatas)
    {
        foreach (var slice in slices)
        {
            var sliceData = sliceDatas.GetRandomElement();
            slice.SetSlice(sliceData);
        }
    }

    private void SetBomb()
    {
        slices.GetRandomElement().SetBomb(true);
    }

    private void Spin()
    {
        SpinToIndex(slices.GetRandomIndex());
    }

    private void SpinToIndex(int index)
    {
        float stepAngle = 360f / slices.Length;
        float targetAngle = index * stepAngle;
        float currentAngle = wheelTransform.localEulerAngles.z;
        float fullRotations = 360f * 2f;

        float finalAngle = currentAngle + fullRotations + Mathf.DeltaAngle(currentAngle, targetAngle);

        wheelTransform.DOLocalRotate(Vector3.forward * finalAngle, 2.6f, RotateMode.FastBeyond360).SetEase(Ease.InOutBack);
    }
}
