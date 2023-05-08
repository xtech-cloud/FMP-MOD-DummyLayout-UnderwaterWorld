
using System.Collections.Generic;
using UnityEngine;
using LibMVCS = XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.MVCS;
using Unity.VisualScripting;

namespace XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.Unity
{
    /// <summary>
    /// 运行时类
    /// </summary>
    ///<remarks>
    /// 存储模块运行时创建的对象
    ///</remarks>
    public class MyRuntime : MyRuntimeBase
    {
        public MyRuntime(MonoBehaviour _mono, MyConfig _config, MyCatalog _catalog, Dictionary<string, LibMVCS.Any> _settings, LibMVCS.Logger _logger, MyEntryBase _entry)
            : base(_mono, _config, _catalog, _settings, _logger, _entry)
        {
        }

        public void Inlay(string _layer, string _pattern, int _virtualResolutionWidth, int _virtualResolutionHeight, Transform _uiSlot)
        {

        }

        public void OnLayoutEnter(string _layer, string _pattern, float _duration)
        {

        }

        public void OnLayoutExit(string _layer, string _pattern)
        {

        }

        public void OnInTransitionEnter(string _layer, string _pattern, float _duration)
        {

        }

        public void OnInTransitionExit(string _layer, string _pattern)
        {
        }

        public void OnOutTransitionEnter(string _layer, string _pattern, float _duration)
        {

        }

        public void OnOutTransitionExit(string _layer, string _pattern)
        {
        }

    }
}

