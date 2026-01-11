using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelInventoryStat : MonoBehaviour
{
    [SerializeField] private RewardData rewardData;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI amountText;

    private int amount = 0;

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

    private void OnEnable()
    {
        EventManager.wheelStarted.AddListener(OnWheelStarted);
        EventManager.sliceCollected.AddListener(OnSliceCollected);
    }
    private void OnDisable()
    {
        EventManager.wheelStarted.RemoveListener(OnWheelStarted);
        EventManager.sliceCollected.RemoveListener(OnSliceCollected);
    }
    private void OnWheelStarted()
    {
        SetAmount(0);
    }
    private void OnSliceCollected(WheelSliceData data)
    {
        if (!data.rewardData.Equals(rewardData))
        {
            return;
        }

        SetAmount(amount + data.rewardAmount);
    }

    private const string FORMAT = "N0";
    private void SetAmount(int newAmount)
    {
        amountText.text = amount.ToString(FORMAT);
        amount = newAmount;
    }
}
