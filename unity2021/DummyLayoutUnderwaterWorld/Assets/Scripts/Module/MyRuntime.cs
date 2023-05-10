
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
            CreateInstanceAsync(_layer, _pattern, "", "", "", "", (_instance) =>
            {
                _instance.rootUI.transform.SetParent(_uiSlot);
            });
        }

        public void OnLayoutEnter(string _layer, string _pattern, float _duration)
        {

            MyInstance instance;
            if (!instances.TryGetValue(_layer, out instance))
            {
                logger_.Error("instance:${0}$ not found", _layer);
                return;
            }
        }

        public void OnLayoutExit(string _layer, string _pattern)
        {
            MyInstance instance;
            if (!instances.TryGetValue(_layer, out instance))
            {
                logger_.Error("instance:${0}$ not found", _layer);
                return;
            }

        }

        public void OnInTransitionEnter(string _layer, string _pattern, float _duration)
        {
            MyInstance instance;
            if (!instances.TryGetValue(_layer, out instance))
            {
                logger_.Error("instance:${0}$ not found", _layer);
                return;
            }

            instance.rootUI.gameObject.SetActive(true);
            instance.rootWorld.gameObject.SetActive(true);
        }

        public void OnInTransitionExit(string _layer, string _pattern)
        {
            MyInstance instance;
            if (!instances.TryGetValue(_layer, out instance))
            {
                logger_.Error("instance:${0}$ not found", _layer);
                return;
            }
        }

        public void OnOutTransitionEnter(string _layer, string _pattern, float _duration)
        {
            MyInstance instance;
            if (!instances.TryGetValue(_layer, out instance))
            {
                logger_.Error("instance:${0}$ not found", _layer);
                return;
            }

        }

        public void OnOutTransitionExit(string _layer, string _pattern)
        {
            MyInstance instance;
            if (!instances.TryGetValue(_layer, out instance))
            {
                logger_.Error("instance:${0}$ not found", _layer);
                return;
            }
            instance.rootUI.gameObject.SetActive(false);
            instance.rootWorld.gameObject.SetActive(false);
        }

    }
}

