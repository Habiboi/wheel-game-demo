using UnityEngine;

public class WheelInventory : MonoBehaviour
{
    [SerializeField] private WheelInventoryStat[] stats;

#if UNITY_EDITOR
    void OnValidate()
    {
        stats = GetComponentsInChildren<WheelInventoryStat>();
    }
#endif

    private void Awake()
    {
        foreach (var stat in stats)
        {
            //stat.
        }
    }
}
