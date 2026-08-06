using ECommons.DalamudServices;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoRetainerAPI.Configuration;

[Serializable]
[Obfuscation(Exclude = true, ApplyToMembers = true)]
public class OfflineRetainerData : IEquatable<OfflineRetainerData>
{
    public readonly ulong CreationFrame = Svc.PluginInterface.UiBuilder.FrameCount;
    public bool ShouldSerializeCreationFrame() => false;
    public string Name = "";
    public long VentureEndsAt = 0;
    public bool HasVenture = false;
    public int Level = 0;
    public long VentureBeginsAt = 0;
    public uint Job = 0;
    public uint VentureID = 0;
    public uint Gil = 0;
    public ulong RetainerID = 0;
    public int MBItems = 0;

    /// <summary>
    /// 這個僱員背包裡佔用的格數（不含寄售中的道具，那個是 <see cref="MBItems"/>）。
    /// <br></br>
    /// 來源是僱員清單本身（<c>RetainerManager.Retainer.ItemCount</c>，0x2B），
    /// 跟 <see cref="Gil"/>／<see cref="MBItems"/> 同一份資料 —— 也就是說
    /// <b>不需要開過那個僱員</b>就有值，但它是「該角色最後一次登入時」的快照而不是即時值。
    /// <br></br>
    /// 🔑 <c>-1</c> 代表<b>從來沒記錄過</b>，跟「真的是 0 件」是兩回事。
    /// 舊設定檔沒有這個欄位，反序列化後就停在 -1，所以預設值不能改成 0 ——
    /// UI 必須把 -1 畫成 <c>?</c>，畫成 0 會讓使用者以為僱員是空的（實際可能是滿的）。
    /// </summary>
    public int ItemCount = -1;

    public string Identity => $"{Name}";
    public bool ShouldSerializeIdentity() => false;

    public override bool Equals(object obj)
    {
        return Equals(obj as OfflineRetainerData);
    }

    public bool Equals(OfflineRetainerData other)
    {
        return other is not null &&
               Name == other.Name &&
               VentureEndsAt == other.VentureEndsAt &&
               HasVenture == other.HasVenture &&
               Level == other.Level &&
               VentureBeginsAt == other.VentureBeginsAt;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, VentureEndsAt, HasVenture, Level, VentureBeginsAt);
    }

    public static bool operator ==(OfflineRetainerData left, OfflineRetainerData right)
    {
        return EqualityComparer<OfflineRetainerData>.Default.Equals(left, right);
    }

    public static bool operator !=(OfflineRetainerData left, OfflineRetainerData right)
    {
        return !(left == right);
    }
}
