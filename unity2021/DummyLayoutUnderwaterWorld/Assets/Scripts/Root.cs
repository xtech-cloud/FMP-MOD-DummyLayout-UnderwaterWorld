
using UnityEngine;
using XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.Unity;

/// <summary>
/// 根程序类
/// </summary>
/// <remarks>
/// 不参与模块编译，仅用于在编辑器中开发调试
/// </remarks>
public class Root : RootBase
{
    public Transform slotOnInlay;

    private void Awake()
    {
        doAwake();
    }

    private void Start()
    {
        entry_.__DebugPreload(exportRoot);
    }

    private void OnDestroy()
    {
        doDestroy();
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 60, 30), "Create"))
        {
            entry_.__DebugCreate("test", "default", "", "", "", "");
        }

        if (GUI.Button(new Rect(0, 30, 60, 30), "Open"))
        {
            entry_.__DebugOpen("test", "file", "", 0.5f);
        }

        if (GUI.Button(new Rect(0, 60, 60, 30), "Show"))
        {
            entry_.__DebugShow("test", 0.5f);
        }

        if (GUI.Button(new Rect(0, 90, 60, 30), "Hide"))
        {
            entry_.__DebugHide("test", 0.5f);
        }

        if (GUI.Button(new Rect(0, 120, 60, 30), "Close"))
        {
            entry_.__DebugClose("test", 0.5f);
        }

        if (GUI.Button(new Rect(0, 150, 60, 30), "Delete"))
        {
            entry_.__DebugDelete("test");
        }

        if (GUI.Button(new Rect(0, 180, 180, 30), "Layout OnInlay"))
        {
            entry_.__DebugOnInlay("dummy", MyEntryBase.ModuleName, 1080, 1080, slotOnInlay);
        }

        if (GUI.Button(new Rect(0, 210, 180, 30), "InTransition OnEnter"))
        {
            entry_.__DebugInTransitionOnEnter("dummy", MyEntryBase.ModuleName, 30);
        }

        if (GUI.Button(new Rect(0, 240, 180, 30), "InTransition OnExit"))
        {
            entry_.__DebugInTransitionOnExit("dummy", MyEntryBase.ModuleName);
        }

        if (GUI.Button(new Rect(0, 270, 180, 30), "Layout OnEnter"))
        {
            entry_.__DebugLayoutOnEnter("dummy", MyEntryBase.ModuleName, 30);
        }

        if (GUI.Button(new Rect(0, 300, 180, 30), "Layout OnExit"))
        {
            entry_.__DebugLayoutOnEnter("dummy", MyEntryBase.ModuleName, 30);
        }

        if (GUI.Button(new Rect(0, 330, 180, 30), "OutTransition OnEnter"))
        {
            entry_.__DebugOutTransitionOnEnter("dummy", MyEntryBase.ModuleName, 30);
        }

        if (GUI.Button(new Rect(0, 370, 180, 30), "OutTransition OnExit"))
        {
            entry_.__DebugOutTransitionOnExit("dummy", MyEntryBase.ModuleName);
        }
    }
}

