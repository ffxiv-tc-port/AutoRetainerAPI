using System;
using System.Reflection;

namespace AutoRetainerAPI.Configuration;
[Serializable]
[Obfuscation(Exclude = true, ApplyToMembers = true)]
public class FCData
{
    public ulong ID;
    public string Name;
    public long Gil = -1;
    public bool GilCountsTowardsChara = false;
    public long LastGilUpdate;
    public long FCPoints;
    public long FCPointsLastUpdate;
    public ulong HolderChara;

    /// <summary>Founding time, Unix seconds. 0 = not known yet.</summary>
    public long FoundedAt;
    /// <summary>Whether the FC owns an estate, as last observed. <see cref="FCEstateState.Unknown"/> until observed.</summary>
    public FCEstateState EstateState;
    /// <summary>When <see cref="EstateState"/> was last observed, Unix milliseconds. 0 = never.</summary>
    public long EstateStateUpdate;
    /// <summary>When the "can buy FC land" notice was shown, Unix milliseconds. 0 = not shown since the FC was last seen owning an estate.</summary>
    public long HousingEligibleNotified;
}

public enum FCEstateState
{
    Unknown = 0,
    NoEstate = 1,
    HasEstate = 2,
}
