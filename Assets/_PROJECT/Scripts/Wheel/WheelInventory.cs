using UnityEngine;

public class WheelInventory : MonoBehaviour
{
    [SerializeField] private WheelInventoryStat[] stats;

    void OnValidate()
    {
        stats = GetComponentsInChildren<WheelInventoryStat>();
    }
}
