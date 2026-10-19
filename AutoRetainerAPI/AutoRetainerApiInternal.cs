using ECommons;

namespace AutoRetainerAPI;

public partial class AutoRetainerApi
{
    private void OnRetainerListTaskButtonsDrawAction()
    {
        if(OnRetainerListTaskButtonsDraw != null)
        {
            GenericHelpers.Safe(() => OnRetainerListTaskButtonsDraw());
        }
    }

    private void OnMainControlsDrawAction()
    {
        if(OnMainControlsDraw != null)
        {
            GenericHelpers.Safe(() => OnMainControlsDraw());
        }
    }

    private void OnRetainerPostVentureTaskDrawAction(ulong cid, string retainer)
    {
        // AutoRetainer 主視窗每列每幀都送這個事件。捕獲參數的 lambda 會讓閉包在方法一進來就配置（沒人掛處理器也一樣；
        // 捕獲分支裡的區域變數也沒用，編譯器會把它併到方法層），所以 lambda 放在另一個方法裡。
        if(OnRetainerPostVentureTaskDraw != null)
        {
            InvokeRetainerPostVentureTaskDraw(cid, retainer);
        }
    }

    private void InvokeRetainerPostVentureTaskDraw(ulong cid, string retainer) => GenericHelpers.Safe(() => OnRetainerPostVentureTaskDraw(cid, retainer));

    private void OnRetainerSettingsDrawAction(ulong cid, string retainer)
    {
        if(OnRetainerSettingsDraw != null)
        {
            InvokeRetainerSettingsDraw(cid, retainer);
        }
    }

    private void InvokeRetainerSettingsDraw(ulong cid, string retainer) => GenericHelpers.Safe(() => OnRetainerSettingsDraw(cid, retainer));

    private void OnRetainerReadyForPostprocessIntl(string plugin, string retainer)
    {
        if(PluginName == plugin)
        {
            if(OnRetainerReadyToPostprocess != null)
            {
                GenericHelpers.Safe(() => OnRetainerReadyToPostprocess(retainer));
            }
        }
    }

    private void OnCharacterReadyForPostprocessIntl(string plugin)
    {
        if(PluginName == plugin)
        {
            if(OnCharacterReadyToPostProcess != null)
            {
                GenericHelpers.Safe(() => OnCharacterReadyToPostProcess());
            }
        }
    }

    private void OnSendRetainerToVentureAction(string n)
    {
        if(OnSendRetainerToVenture != null)
        {
            GenericHelpers.Safe(() => OnSendRetainerToVenture(n));
        }
    }

    private void OnRetainerAdditionalTask(string n)
    {
        if(OnRetainerPostprocessStep != null)
        {
            GenericHelpers.Safe(() => OnRetainerPostprocessStep(n));
        }
    }

    private void OnCharacterAdditionalTask()
    {
        if(OnCharacterPostprocessStep != null)
        {
            GenericHelpers.Safe(() => OnCharacterPostprocessStep());
        }
    }
}
