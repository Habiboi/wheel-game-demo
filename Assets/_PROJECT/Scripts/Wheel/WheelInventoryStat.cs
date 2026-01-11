using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;

public class WheelInventoryStat : MonoBehaviour
{
    [SerializeField] private RewardData rewardData;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI amountText;

#if UNITY_EDITOR
    void OnValidate()
    {
        iconImage ??= GetComponentInChildren<Image>();
        amountText ??= GetComponentInChildren<TextMeshProUGUI>();

        if (rewardData != null)
        {
            iconImage.sprite = rewardData.icon;
        }
    }
#endif
}
