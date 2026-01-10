using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelInventoryStat : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI amountText;

#if UNITY_EDITOR
    void OnValidate()
    {
        iconImage ??= GetComponentInChildren<Image>();
        amountText ??= GetComponentInChildren<TextMeshProUGUI>();
    }
#endif
}
