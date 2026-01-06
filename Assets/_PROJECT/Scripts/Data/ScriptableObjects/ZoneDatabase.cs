using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZoneDatabase", menuName = "Scriptable Objects/ZoneDatabase")]
public class ZoneDatabase : ScriptableObject
{
    public List<ZoneConfig> zones;

    public ZoneConfig GetZone(int zoneIndex)
    {
        return zones.Find(z => z.zoneIndex == zoneIndex);
    }
}