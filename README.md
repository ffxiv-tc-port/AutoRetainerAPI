# AutoRetainerAPI

由 PunishXIV 開發的函式庫，讓其他插件透過 IPC 讀寫 `AutoRetainer` 的雇員派遣、
自由部隊金庫、潛水艇航行、離線角色資料等狀態。

## 台服 fork 的目的

修掉一個全艦隊只有這裡出現過的組態問題：`.csproj` 原本無條件用
`PackageReference Include="ECommons" Version="3.2.0.11"`，只靠「NuGet 套件版本號
高於 fork 版本號」讓 NuGet 選中艦隊加固過的 `ProjectReference` 子模組版本蓋掉它——
這個版本序已經倒掛（NuGet 版 3.2.0.11 > fork 版 3.0.1.15），一旦消費端 repin 到含這條邊的
commit，會**靜默**改吃未加固的 NuGet 版 ECommons，建置零錯誤零警告，只有實機才看得出差別。
改成依樹上有沒有 `ECommons` 專案判斷式互斥（有就走 `ProjectReference`，沒有才退回 NuGet），
不再依賴版本比較。

## 與上游的差異

- 上述 ECommons 參考來源條件式修正（見 commit `b217a64`）。
- 目前 pin 落後上游數個 commit，尚未同步的欄位：`InventoryManagementSettings` 的
  `IMAutoVendorHardIgnoreStack`/`IMDiscardIgnoreStack` 上游已改成 `HashSet<uint>`（我們仍是
  `List<uint>`）、`EnableMirageAutoDelivery`；`OfflineCharacterData` 的 `NoFcBuffUse`/
  `NoItemBuffUse`。這些是版本落差，非刻意改動，尚未逐一評估同步的必要性。

## 誰在用它

艦隊裡 5 個插件以子模組引用：`AutoRetainer`、`GatherBuddyReborn`、`Lifestream`、`SomethingNeedDoing`、`visland`。

---

上游原始碼：<https://github.com/PunishXIV/AutoRetainerAPI>
