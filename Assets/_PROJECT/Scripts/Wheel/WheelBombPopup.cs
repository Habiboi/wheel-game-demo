using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WheelBombPopup : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Button restartButton;

#if UNITY_EDITOR
    private void OnValidate()
    {
        restartButton ??= GetComponentInChildren<Button>();
        canvasGroup ??= GetComponent<CanvasGroup>();
    }
#endif

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartWheel);

        EventManager.bombSelected.AddListener(OnBombSelected);

        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        EventManager.bombSelected.RemoveListener(OnBombSelected);
    }

    private void OnBombSelected()
    {
        gameObject.SetActive(true);
        canvasGroup.alpha = 0f;
        canvasGroup.DOFade(1f, 1f).SetEase(Ease.InOutSine);
    }

    private void RestartWheel()
    {
        EventManager.wheelRestarted.Invoke();
        canvasGroup.DOFade(0f, 1f).SetEase(Ease.InOutSine).OnComplete(() => gameObject.SetActive(false));
    }
}
