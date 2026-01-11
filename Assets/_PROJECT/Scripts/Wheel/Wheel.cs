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

    private void SetWheel()
    {
        //SetVisuals();
        SetSlices();
    }

    private void SetVisuals(Sprite spinSprite, Sprite indicatorSprite)
    {
        spinImage.sprite = spinSprite;
        indicatorImage.sprite = indicatorSprite;
    }

    private void SetSlices()
    {
        foreach (var slice in slices)
        {
            //slice.SetSlice();
        }
    }
}
