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
        rewardImage ??= GetComponentInChildren<Image>();
        rewardText ??= GetComponentInChildren<TextMeshProUGUI>();
    }
#endif

    public void SetSlice(Sprite rewardSprite, int rewardAmount)
    {
        rewardImage.sprite = rewardSprite;
        rewardText.text = rewardAmount.ToString();
    }
}
