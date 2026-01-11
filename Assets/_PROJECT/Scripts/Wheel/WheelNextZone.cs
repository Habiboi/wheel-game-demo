using Project.Core.Enums;
using TMPro;
using UnityEngine;

public class WheelNextZone : MonoBehaviour
{
    [SerializeField] private ZoneType zoneType;
    [SerializeField] private TextMeshProUGUI counterText;

#if UNITY_EDITOR
    void OnValidate()
    {
        counterText ??= transform.Find("ui_text_counter")?.GetComponent<TextMeshProUGUI>();

        if (transform.name.EndsWith("super"))
        {
            zoneType = ZoneType.Super;
        }
        else if (transform.name.EndsWith("safe"))
        {
            zoneType = ZoneType.Safe;
        }
    }
#endif
}
