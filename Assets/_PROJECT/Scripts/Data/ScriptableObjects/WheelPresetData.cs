using System.Collections.Generic;
using Project.Core.Enums;
using UnityEngine;

[CreateAssetMenu(fileName = "WheelPresetData", menuName = "Scriptable Objects/WheelPresetData")]
public class WheelPresetData : ScriptableObject
{
    [Header("Preset Info")]
    public ZoneType zoneType;

    [Min(1)]
    public int interval = 1;

    [Header("Slot Rules")]
    [Min(1)]
    public int slotCount = 8;

    [Header("Available Slices")]
    public List<WheelSliceEntry> wheelSliceEntries;

    [System.Serializable]
    public struct WheelSliceEntry
    {
        public WheelSliceData sliceData;
        [Range(1, 100)]
        public int weight;
    }

    [Header("Bomb Settings")]
    public bool allowBomb;

    [Header("Visuals")]
    public Sprite spinSprite;
    public Sprite indicatorSprite;
    public Sprite currentSprite;
    public Color color = Color.white;
}
