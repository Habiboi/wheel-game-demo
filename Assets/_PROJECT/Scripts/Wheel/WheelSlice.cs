using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelSlice : MonoBehaviour
{
    [SerializeField] private Image rewardImage;
    [SerializeField] private TextMeshProUGUI rewardText;

#if UNITY_EDITOR
    void OnValidate()
    {
        if (rewardImage == null)
        {
            rewardImage = GetComponentInChildren<Image>();
        }

        if (rewardText == null)
        {
            rewardText = GetComponentInChildren<TextMeshProUGUI>();
        }
    }
#endif
}
