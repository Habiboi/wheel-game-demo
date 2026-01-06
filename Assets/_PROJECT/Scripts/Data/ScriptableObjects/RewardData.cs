using UnityEngine;

[CreateAssetMenu(fileName = "RewardData", menuName = "Scriptable Objects/RewardData")]
public class RewardData : ScriptableObject
{
    public string rewardId;
    public string displayName;
    public Sprite icon;
}
