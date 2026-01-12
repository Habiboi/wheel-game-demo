using UnityEngine.Events;

public static class EventManager
{
    public static readonly UnityEvent wheelStarted = new();
    public static readonly UnityEvent<int, WheelPresetData> zoneStarted = new();
    public static readonly UnityEvent<WheelSlice> sliceSelected = new();
    public static readonly UnityEvent bombSelected = new();
    public static readonly UnityEvent<WheelSliceData> sliceCollected = new();
    public static readonly UnityEvent zoneEnded = new();
    public static readonly UnityEvent wheelRestarted = new();
}
