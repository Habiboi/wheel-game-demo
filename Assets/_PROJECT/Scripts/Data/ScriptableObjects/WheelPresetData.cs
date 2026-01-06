using System.Collections.Generic;
using Project.Core.Enums;
using UnityEngine;

[CreateAssetMenu(fileName = "WheelPresetData", menuName = "Scriptable Objects/WheelPresetData")]
public class WheelPresetData : ScriptableObject
{
    [Header("Preset Info")]
    public SpinType spinType;

    [Min(1)]
    public int interval = 1;

    [Header("Slot Rules")]
    [Min(1)]
    public int slotCount = 8;

    [Header("Available Slices")]
    public List<WheelSliceData> availableSlices;

    [Header("Bomb Settings")]
    public bool allowBomb;
}
