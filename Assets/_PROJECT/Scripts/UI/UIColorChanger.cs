using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIColorChanger : MonoBehaviour
{
    [SerializeField] private Color color = Color.white;

    void OnValidate()
    {
        foreach (var image in GetComponentsInChildren<Image>(true))
        {
            image.color = image.color.SetColorWithoutAlpha(color);
        }

        foreach (var tmpro in GetComponentsInChildren<TextMeshProUGUI>(true))
        {
            tmpro.color = tmpro.color.SetColorWithoutAlpha(color);
        }
    }
}
