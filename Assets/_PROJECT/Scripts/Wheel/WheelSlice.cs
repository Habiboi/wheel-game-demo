using TMPro;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class WheelSlice : MonoBehaviour
{
    [SerializeField] private Image rewardImage;
    [SerializeField] private TextMeshProUGUI rewardText;

#if UNITY_EDITOR
    void OnValidate()
    {
        if (EditorApplication.isPlaying)
        {
            return;
        }

        if (rewardImage == null)
        {
            rewardImage = GetComponentInChildren<Image>();
        }

        if (rewardText == null)
        {
            rewardText = GetComponentInChildren<TextMeshProUGUI>();
        }

        EditorUtility.SetDirty(this);
    }
#endif
}
