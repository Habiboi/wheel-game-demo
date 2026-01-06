using System.Collections.Generic;
using Project.Core.Enums;
using UnityEngine;

[CreateAssetMenu(fileName = "ZoneConfig", menuName = "Scriptable Objects/ZoneConfig")]
public class ZoneConfig : ScriptableObject
{
    [Header("Zone Info")]
    public int zoneIndex;
    public ZoneType zoneType;

    [Header("Wheel Rules")]
    public bool hasBomb;

    [Tooltip("Slices used in this zone")]
    public List<WheelSliceData> wheelSlices;
}
