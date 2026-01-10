using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelZoneCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countsText;
    [SerializeField] private Image currentImage, frameImage;

#if UNITY_EDITOR
    void OnValidate()
    {
        countsText ??= transform.Find("ui_image_background")?.Find("ui_text_counts")?.GetComponent<TextMeshProUGUI>();
        currentImage ??= transform.Find("ui_image_background")?.Find("ui_image_current")?.GetComponent<Image>();
        frameImage ??= transform.Find("ui_image_frame")?.GetComponent<Image>();
    }
#endif
}
