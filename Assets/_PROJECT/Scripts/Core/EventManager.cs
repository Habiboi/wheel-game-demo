using UnityEngine.Events;

public static class EventManager
{
    public static readonly UnityEvent<int, WheelPresetData> zoneStarted = new();
    public static readonly UnityEvent<WheelSlice> sliceSelected = new();
}
