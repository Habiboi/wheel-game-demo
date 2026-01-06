using Project.Core.Enums;
using UnityEngine;

[CreateAssetMenu(fileName = "WheelSliceData", menuName = "Scriptable Objects/WheelSliceData")]
public class WheelSliceData : ScriptableObject
{
    [Header("Slice Info")]
    public WheelSliceType sliceType;

    [Header("Reward Settings")]
    [Min(0)]
    public int rewardAmount;

    [Header("Visual")]
    public Sprite icon;
}
