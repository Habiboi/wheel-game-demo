using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "WheelSpinEffectData", menuName = "Scriptable Objects/WheelSpinEffectData")]
public class WheelSpinEffectData : ScriptableObject
{
    public float duration = 2.5f;
    public int extraSpinCount = 2;
    public Ease ease = Ease.InOutBack;
}
