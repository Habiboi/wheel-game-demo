using UnityEngine;
using UnityEngine.UI;

public class WheelInventory : MonoBehaviour
{
    [SerializeField] private Button exitButton;

#if UNITY_EDITOR
    private void OnValidate()
    {
        exitButton ??= GetComponentInChildren<Button>();
    }
#endif

    void Awake()
    {
        exitButton.onClick.AddListener(ExitWheel);
    }

    void OnEnable()
    {
        EventManager.zoneStarted.AddListener(OnZoneStarted);
        EventManager.spinStarted.AddListener(OnSpinStarted);
    }
    void OnDisable()
    {
        EventManager.zoneStarted.RemoveListener(OnZoneStarted);
        EventManager.spinStarted.RemoveListener(OnSpinStarted);
    }
    private void OnZoneStarted(int zoneIndex, WheelPresetData presetData)
    {
        exitButton.gameObject.SetActive(!presetData.allowBomb);
        exitButton.interactable = true;
    }
    private void OnSpinStarted()
    {
        exitButton.interactable = false;
    }

    private void ExitWheel()
    {
        EventManager.wheelRestarted.Invoke();
    }
}
