using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelSlice : MonoBehaviour
{
    [SerializeField] private Image rewardImage;
    [SerializeField] private TextMeshProUGUI rewardText;
    [SerializeField] private GameObject uiPanel, bombPanel;

#if UNITY_EDITOR
    void OnValidate()
    {
        rewardImage ??= GetComponentInChildren<Image>();
        rewardText ??= GetComponentInChildren<TextMeshProUGUI>();
        uiPanel ??= rewardImage.rectTransform.parent.gameObject;
        bombPanel ??= transform.Find("ui_image_bomb")?.gameObject;
    }
#endif

    private void OnEnable()
    {
        EventManager.sliceSelected.AddListener(OnSliceSelected);
    }
    private void OnDisable()
    {
        EventManager.sliceSelected.RemoveListener(OnSliceSelected);
    }
    private void OnSliceSelected(WheelSlice slice)
    {
        if (slice != this)
        {
            return;
        }

        uiPanel.transform.DOScale(1.5f, 0.4f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutExpo).SetDelay(0.2f);
    }

    public void SetSlice(WheelSliceData data)
    {
        SetBomb(false);
        rewardImage.sprite = data.rewardData.icon;
        rewardText.text = data.rewardAmount.GetRewardText();
    }

    public void SetBomb(bool isActive)
    {
        bombPanel.SetActive(isActive);
        uiPanel.SetActive(!isActive);
    }
}
