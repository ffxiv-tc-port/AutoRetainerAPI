<!-- ffxiv-tc-port 繁體中文說明開始 -->
# AutoRetainerAPI(台服 fork)

由 PunishXIV 開發的函式庫，提供其他插件與 `AutoRetainer` 互動所需的 IPC 包裝，以及 AutoRetainer
記錄的角色與僱員資料型別（`OfflineCharacterData`／`OfflineRetainerData` 等），讓其他插件能讀取
多角色的僱員、背包與配額狀態，或在 AutoRetainer 介面上掛自己的處理器。

## 台服 fork 的目的

跟隨艦隊釘 API13，並替艦隊插件（AutoRetainer 的多角色總覽等）擴充資料欄位。

## 與上游的差異

- **`OfflineCharacterData` 新增欄位**：軍票上限、理符受理限額、老主顧交易次數、本週亞拉戈神典石
  數量與上限，各附取樣時間；`-1` 代表「不知道」，與真正的 0 分得開。
- **`OfflineRetainerData` 新增 `ItemCount`**：記錄每個僱員自己的背包佔用格數。
- **`ShouldSerializeCreationFrame` 改成方法**：原本寫成屬性，Newtonsoft 的慣例完全不生效。
- **降低記憶體用量**：AutoRetainer 主視窗展開僱員清單時，沒有掛處理器的插件不再每列每幀配置閉包。

## 誰在用它

目前 6 個插件 repo 以子模組使用：`AutoRetainer`、`GatherBuddyReborn`、`HoardFarm`、`Lifestream`、
`SomethingNeedDoing`、`visland`。

---

以下為上游原始 README，內容未經修改：

<!-- ffxiv-tc-port 繁體中文說明結束 -->

# AutoRetainerAPI