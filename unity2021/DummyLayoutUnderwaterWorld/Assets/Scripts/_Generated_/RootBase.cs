
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.86.0.  DO NOT EDIT!
//*************************************************************************************

using System.IO;
using System.Collections.Generic;
using LibMVCS = XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.Unity;
using XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.MVCS;

public class RootConfig : LibMVCS.Config
{
    public void MergeKV(string _key, string _value)
    {
        fields_[_key] = LibMVCS.Any.FromString(_value);
    }
}

/// <summary>
/// 控制台日志
/// </summary>
public class ConsoleLogger : LibMVCS.Logger
{
    protected override void trace(string _categoray, string _message)
    {
        UnityEngine.Debug.Log(string.Format("<color=#02cbac>TRACE</color> [{0}] - {1}", _categoray, _message));
    }
    protected override void debug(string _categoray, string _message)
    {
        UnityEngine.Debug.Log(string.Format("<color=#346cfd>DEBUG</color> [{0}] - {1}", _categoray, _message));
    }
    protected override void info(string _categoray, string _message)
    {
        UnityEngine.Debug.Log(string.Format("<color=#04fc04>INFO</color> [{0}] - {1}", _categoray, _message));
    }
    protected override void warning(string _categoray, string _message)
    {
        UnityEngine.Debug.LogWarning(string.Format("<color=#fce204>WARNING</color> [{0}] - {1}", _categoray, _message));
    }
    protected override void error(string _categoray, string _message)
    {
        UnityEngine.Debug.LogError(string.Format("<color=#fc0450>ERROR</color> [{0}] - {1}", _categoray, _message));
    }
    protected override void exception(System.Exception _exp)
    {
        UnityEngine.Debug.LogException(_exp);
    }
}

/// <summary>
/// 根程序基类
/// </summary>
/// <remarks>
/// 不参与模块编译，仅用于在编辑器中开发调试
/// </remarks>
public class RootBase : UnityEngine.MonoBehaviour
{
    public UnityEngine.Transform mainCanvas;
    public UnityEngine.Transform mainWorld;
    public UnityEngine.GameObject exportRoot;
    public UnityEngine.Font mainFont;

    protected LibMVCS.Framework framework_ { get; set; } = new LibMVCS.Framework();
    protected LibMVCS.Logger logger_ { get; set; } = new ConsoleLogger();
    protected DebugEntry entry_ { get; set; } = new DebugEntry();
    protected RootConfig config_ { get; set; } = new RootConfig();
    protected Dictionary<string, LibMVCS.Any> settings_ = new Dictionary<string, LibMVCS.Any>();

    /// <summary>
    /// 唤醒
    /// </summary>
    protected virtual void doAwake()
    {
        setupSettings();

        string xml = File.ReadAllText(UnityEngine.Application.dataPath + string.Format("/Exports/{0}.xml", MyEntryBase.ModuleName));
        config_.MergeKV(MyEntryBase.ModuleName + ".xml", xml);

        string json = File.ReadAllText(UnityEngine.Application.dataPath + string.Format("/Exports/{0}.json", MyEntryBase.ModuleName));
        config_.MergeKV(MyEntryBase.ModuleName + ".json", json);

        initFramework();

        entry_ = new DebugEntry();
        var options = entry_.NewOptions();
        entry_.Inject(framework_, options);
        entry_.UniInject(this, options, logger_, config_, settings_);
        framework_.setUserData("XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.MVCS.Entry", entry_);

        entry_.RegisterDummy();

        setupFramework();
    }

    /// <summary>
    /// 销毁
    /// </summary>
    protected virtual void doDestroy()
    {
        dismantleFramework();

        entry_.CancelDummy();

        releaseFramework();
    }

    /// <summary>
    /// 安装设置
    /// </summary>
    protected void setupSettings()
    {
        string vendorPath = Path.Combine(UnityEngine.Application.persistentDataPath, "data");
        string themesPath = Path.Combine(vendorPath, "themes");
        string assetsPath = Path.Combine(vendorPath, "assets");
        settings_["path.assets"] = LibMVCS.Any.FromString(assetsPath);
        settings_["path.themes"] = LibMVCS.Any.FromString(themesPath);
        settings_["platform"] = LibMVCS.Any.FromString("windows");
        settings_["devicecode"] = LibMVCS.Any.FromString(UnityEngine.SystemInfo.deviceUniqueIdentifier);
        settings_["serialnumber"] = LibMVCS.Any.FromString(UnityEngine.SystemInfo.deviceUniqueIdentifier);
        settings_["canvas.main"] = LibMVCS.Any.FromObject(mainCanvas);
        settings_["world.main"] = LibMVCS.Any.FromObject(mainWorld);
        settings_["font.main"] = LibMVCS.Any.FromObject(mainFont);
    }

    /// <summary>
    /// 初始化框架
    /// </summary>
    protected void initFramework()
    {
        framework_.setLogger(logger_);
        framework_.setConfig(config_);
        framework_.Initialize();
    }

    /// <summary>
    /// 安装框架
    /// </summary>
    protected void setupFramework()
    {
        framework_.Setup();
    }

    /// <summary>
    /// 注销框架
    /// </summary>
    protected void dismantleFramework()
    {
        framework_.Dismantle();
    }

    /// <summary>
    /// 释放框架
    /// </summary>
    protected void releaseFramework()
    {
        framework_.Release();
    }
}
