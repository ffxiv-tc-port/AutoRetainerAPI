using ECommons.DalamudServices;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoRetainerAPI.Configuration;

[Serializable]
[Obfuscation(Exclude = true, ApplyToMembers = true)]
public class OfflineCharacterData
{
    public readonly ulong CreationFrame = Svc.PluginInterface.UiBuilder.FrameCount;
    public bool ShouldSerializeCreationFrame() => false;
    public ulong CID = 0;
    public string Name = "Unknown";
    public string World = "";
    public string WorldOverride = null;
    public bool Enabled = false;
    public bool WorkshopEnabled = false;
    public List<OfflineRetainerData> RetainerData = [];
    public bool Preferred = false;
    public uint Ventures = 0;
    public uint InventorySpace = 0;
    public uint VentureCoffers = 0;
    public int ServiceAccount = 0;
    public bool EnableGCArmoryHandin = false; //todo: remove
    public bool ShouldSerializeEnableGCArmoryHandin() => false;
    public GCDeliveryType GCDeliveryType = GCDeliveryType.Disabled;
    public HashSet<uint> UnlockedGatheringItems = [];
    public short[] ClassJobLevelArray = new short[30];
    public uint Gil = 0;
    // 🔴 GCSeals 與 GCRank 由 AutoRetainer 的登入快照寫入，取樣時間看 GCSealsUpdatedAt。
    //    型別與預設值刻意不動：改動它們對既有消費端是回退行為。
    public uint GCSeals = 0;
    public uint GCRank = 0;
    /// <summary>軍票上限（會隨軍階提高）。三態：-1 = 從沒讀到過；0 = 這個角色還是平民，
    /// 沒有加入大國防聯軍，「軍票」對它不成立（那與「不知道」是兩件事，顯示端要分開畫）。</summary>
    public int GCSealsMax = -1;
    /// <summary>GCSeals／GCSealsMax／GCRank 這一組的取樣時間。null = 從沒讀到過。</summary>
    public DateTime? GCSealsUpdatedAt = null;

    // 每日／每週配額的登入快照，刻意做成三態（上面那些欄位「讀不到就是 0」，分辨不出「還沒讀到」與「真的是 0」）：
    //   值 == -1 且對應的時間戳 == null ⇒ 從來沒有成功讀到過（顯示端要畫灰色的 ?，不可以畫成 0）
    //   值 >= 0 且時間戳有值           ⇒ 那個時間點讀到的真值，0 是合法值（額度用完）
    // 🔴 寫入端在遊戲結構還沒就緒時整組不覆寫，維持上一次的值與時間戳（過期好過寫假的 0）。
    // 📌 舊設定檔沒有這些鍵，反序列化時會保留欄位初始式 ⇒ 舊使用者一律落在「沒讀過」，不需要遷移。
    /// <summary>理符任務受理限額剩餘張數，上限 100。-1 = 從沒讀到。</summary>
    public int LevequestAllowances = -1;
    public DateTime? LevequestAllowancesUpdatedAt = null;
    /// <summary>籌備委託品本週剩餘次數（滿額 12）。-1 = 從沒讀到。</summary>
    public int CustomDeliveryAllowances = -1;
    public DateTime? CustomDeliveryAllowancesUpdatedAt = null;
    /// <summary>本週已取得的限定神典石數量。-1 = 從沒讀到。</summary>
    public int WeeklyTomestoneCount = -1;
    /// <summary>限定神典石的每週上限，取自 Tomestones 資料表而非寫死。-1 = 從沒讀到。</summary>
    public int WeeklyTomestoneCap = -1;
    public DateTime? WeeklyTomestoneUpdatedAt = null;
    public List<OfflineVesselData> OfflineAirshipData = [];
    public List<OfflineVesselData> OfflineSubmarineData = [];
    public HashSet<string> EnabledAirships = [];
    public HashSet<string> EnabledSubs = [];
    //public HashSet<string> FinalizeAirships = new();
    //public HashSet<string> FinalizeSubs = new();
    public Dictionary<string, AdditionalVesselData> AdditionalAirshipData = [];
    public Dictionary<string, AdditionalVesselData> AdditionalSubmarineData = [];
    public int Ceruleum = 0;
    public int RepairKits = 0;
    public bool ExcludeRetainer = false;
    public bool ExcludeWorkshop = false;
    public bool ExcludeOverlay = false;
    public int NumSubSlots = 0;
    public bool MultiWaitForAllDeployables = false;
    public ulong FCID = 0;
    public bool DisablePrivateHouseTeleport = false;
    public bool DisableFcHouseTeleport = false;
    public bool DisableApartmentTeleport = false;
    public TeleportOptionsOverride TeleportOptionsOverride = new();
    public bool NoGilTrack = false;
    public Guid ExchangePlan = Guid.Empty;
    public Guid InventoryCleanupPlan = Guid.Empty;

    public Dictionary<long, uint> SentVenturesByDay = [];
    public Dictionary<long, uint> SentVoyagesByDay = [];

    public string Identity => $"{CID}";
    public bool ShouldSerializeIdentity() => false;

    public string CurrentWorld => WorldOverride ?? World;

    public override string ToString()
    {
        return $"{Name}@{World}";
    }
}
