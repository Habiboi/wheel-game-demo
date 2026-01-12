using UnityEngine;

[CreateAssetMenu(fileName = "WheelSliceData", menuName = "Scriptable Objects/WheelSliceData")]
public class WheelSliceData : ScriptableObject
{
    [Header("Reward")]
    public RewardData rewardData;

    [Min(1)]
    [SerializeField] private int rewardAmount;

    [Tooltip("Reward increase amount per zone")]
    [SerializeField] private int rewardIncreaseAmount;

    public int GetRewardAmount(int zoneIndex)
    {
        return rewardAmount + (zoneIndex - 1) * rewardIncreaseAmount;
    }
}
