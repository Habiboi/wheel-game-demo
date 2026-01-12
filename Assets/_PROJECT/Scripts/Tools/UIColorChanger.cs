using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIColorChanger : MonoBehaviour
{
    public Color color = Color.white;

    private void OnValidate()
    {
        SetColor();
    }

    public void SetColor()
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
