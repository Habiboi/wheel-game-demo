using TMPro;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class WheelZoneCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countsText;
    [SerializeField] private Image currentImage, frameImage;

#if UNITY_EDITOR
    void OnValidate()
    {
        if (EditorApplication.isPlaying)
        {
            return;
        }

        countsText ??= transform.Find("ui_image_background")?.Find("ui_text_counts")?.GetComponent<TextMeshProUGUI>();
        currentImage ??= transform.Find("ui_image_background")?.Find("ui_image_current")?.GetComponent<Image>();
        frameImage ??= transform.Find("ui_image_frame")?.GetComponent<Image>();

        EditorUtility.SetDirty(this);
    }
#endif
}
