using System.Text;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelZoneCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countsText;
    [SerializeField] private Image currentImage, frameImage;
    [SerializeField] private WheelManager wheelManager;

#if UNITY_EDITOR
    void OnValidate()
    {
        countsText ??= transform.Find("ui_image_background")?.Find("ui_text_counts")?.GetComponent<TextMeshProUGUI>();
        currentImage ??= transform.Find("ui_image_background")?.Find("ui_image_current")?.GetComponent<Image>();
        frameImage ??= transform.Find("ui_image_frame")?.GetComponent<Image>();
        wheelManager ??= FindAnyObjectByType<WheelManager>();
    }
#endif

    private StringBuilder stringBuilder = new();
    private int additionalZoneCount = 5;
    private const string SPACE = " ";
    private const string FORMAT = "00";

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
        SetVisuals(zoneIndex, presetData.currentSprite);
    }

    private void SetVisuals(int zoneIndex, Sprite currentSprite)
    {
        bool setted = false;
        frameImage.rectTransform.DOScale(1.15f, 0.25f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutExpo).OnStepComplete(() =>
        {
            if (!setted)
            {
                setted = true;
                SetZoneCounts(zoneIndex);
                currentImage.sprite = currentSprite;
            }
        });
    }

    private void SetZoneCounts(int currentCount)
    {
        stringBuilder.Clear();

        for (int i = currentCount - additionalZoneCount; i < currentCount + additionalZoneCount; i++)
        {
            stringBuilder.Append(FormatZoneNumber(i));
            stringBuilder.Append(SPACE);
        }
        stringBuilder.Append(FormatZoneNumber(currentCount + additionalZoneCount));

        countsText.text = stringBuilder.ToString();
    }

    private string FormatZoneNumber(int value)
    {
        return Mathf.Clamp(value, 0, value).ToString(FORMAT).SetColor(wheelManager.GetZoneColor(value));
    }
}
