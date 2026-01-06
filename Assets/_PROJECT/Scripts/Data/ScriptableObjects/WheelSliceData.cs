using Project.Core.Enums;
using UnityEngine;

[CreateAssetMenu(fileName = "WheelSliceData", menuName = "Scriptable Objects/WheelSliceData")]
public class WheelSliceData : ScriptableObject
{
    [Header("Reward")]
    public RewardData rewardData;

    [Min(1)]
    public int rewardAmount;

    [Header("Visual")]
    public Sprite icon;
}
