
using System;
using LibMVCS = XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.Bridge;
using XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.MVCS;
using XTC.FMP.LIB.MVCS;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.Unity
{
    /// <summary>
    /// 虚拟视图，用于处理消息订阅
    /// </summary>
    public class DummyView : DummyViewBase
    {
        public DummyView(string _uid) : base(_uid)
        {
        }

        protected override void setup()
        {
            base.setup();
            addSubscriber("/XTC/VisionLayout/DummyLayout/OnInlay", handleDummyLayoutOnInlay);
            addSubscriber("/XTC/VisionLayout/DummyLayout/OnEnter", handleDummyLayoutOnEnter);
            addSubscriber("/XTC/VisionLayout/DummyLayout/OnExit", handleDummyLayoutOnExit);
            addSubscriber("/XTC/VisionLayout/DummyInTransition/OnEnter", handleDummyInTransitionOnEnter);
            addSubscriber("/XTC/VisionLayout/DummyInTransition/OnExit", handleDummyInTransitionOnExit);
            addSubscriber("/XTC/VisionLayout/DummyOutTransition/OnEnter", handleDummyOutTransitionOnEnter);
            addSubscriber("/XTC/VisionLayout/DummyOutTransition/OnExit", handleDummyOutTransitionOnExit);
        }

        private void handleDummyLayoutOnInlay(Model.Status _satus, object _data)
        {
            getLogger().Debug("handle /XTC/VisionLayout/DummyLayout/OnInlay with data: {0}", JsonConvert.SerializeObject(_data));
            string layer = "";
            string pattern = "";
            int virtual_resolution_width = 0;
            int virtual_resolution_height = 0;
            Transform uiSlot = null;
            try
            {
                Dictionary<string, object> data = _data as Dictionary<string, object>;
                layer = data["layer"] as string;
                pattern = data["pattern"] as string;
                virtual_resolution_width = (int)data["virtual_resolution_width"];
                virtual_resolution_height = (int)data["virtual_resolution_height"];
                uiSlot = data["uiSlot"] as Transform;
            }
            catch (Exception ex)
            {
                getLogger().Exception(ex);
            }

            runtime.Inlay(layer, pattern, virtual_resolution_width, virtual_resolution_height, uiSlot);
        }

        private void handleDummyLayoutOnEnter(Model.Status _satus, object _data)
        {
            getLogger().Debug("handle /XTC/VisionLayout/DummyLayout/OnEnter with data: {0}", JsonConvert.SerializeObject(_data));
            string layer = "";
            string pattern = "";
            float duration = 0;
            try
            {
                Dictionary<string, object> data = _data as Dictionary<string, object>;
                layer = data["layer"] as string;
                pattern = data["pattern"] as string;
                duration = (float)data["duration"];
            }
            catch (Exception ex)
            {
                getLogger().Exception(ex);
            }

            runtime.OnLayoutEnter(layer, pattern, duration);
        }

        private void handleDummyLayoutOnExit(Model.Status _satus, object _data)
        {
            getLogger().Debug("handle /XTC/VisionLayout/DummyLayout/OnExit with data: {0}", JsonConvert.SerializeObject(_data));
            string layer = "";
            string pattern = "";
            try
            {
                Dictionary<string, object> data = _data as Dictionary<string, object>;
                layer = data["layer"] as string;
                pattern = data["pattern"] as string;
            }
            catch (Exception ex)
            {
                getLogger().Exception(ex);
            }
            runtime.OnLayoutExit(layer, pattern);
        }

        private void handleDummyInTransitionOnEnter(Model.Status _satus, object _data)
        {
            getLogger().Debug("handle /XTC/VisionLayout/DummyInTransition/OnEnter with data: {0}", JsonConvert.SerializeObject(_data));
            string layer = "";
            string pattern = "";
            float duration = 0;
            try
            {
                Dictionary<string, object> data = _data as Dictionary<string, object>;
                layer = data["layer"] as string;
                pattern = data["pattern"] as string;
                duration = (float)data["duration"];
            }
            catch (Exception ex)
            {
                getLogger().Exception(ex);
            }
            runtime.OnInTransitionEnter(layer, pattern, duration);
        }

        private void handleDummyInTransitionOnExit(Model.Status _satus, object _data)
        {

            getLogger().Debug("handle /XTC/VisionLayout/DummyInTransition/OnExit with data: {0}", JsonConvert.SerializeObject(_data));
            string layer = "";
            string pattern = "";
            try
            {
                Dictionary<string, object> data = _data as Dictionary<string, object>;
                layer = data["layer"] as string;
                pattern = data["pattern"] as string;
            }
            catch (Exception ex)
            {
                getLogger().Exception(ex);
            }
            runtime.OnInTransitionExit(layer, pattern);
        }

        private void handleDummyOutTransitionOnEnter(Model.Status _satus, object _data)
        {

            getLogger().Debug("handle /XTC/VisionLayout/DummyOutTransition/OnEnter with data: {0}", JsonConvert.SerializeObject(_data));
            string layer = "";
            string pattern = "";
            float duration = 0;
            try
            {
                Dictionary<string, object> data = _data as Dictionary<string, object>;
                layer = data["layer"] as string;
                pattern = data["pattern"] as string;
                duration = (float)data["duration"];
            }
            catch (Exception ex)
            {
                getLogger().Exception(ex);
            }
            runtime.OnOutTransitionEnter(layer, pattern, duration);
        }

        private void handleDummyOutTransitionOnExit(Model.Status _satus, object _data)
        {
            getLogger().Debug("handle /XTC/VisionLayout/DummyOutTransition/OnExit with data: {0}", JsonConvert.SerializeObject(_data));
            string layer = "";
            string pattern = "";
            try
            {
                Dictionary<string, object> data = _data as Dictionary<string, object>;
                layer = data["layer"] as string;
                pattern = data["pattern"] as string;
            }
            catch (Exception ex)
            {
                getLogger().Exception(ex);
            }
            runtime.OnOutTransitionExit(layer, pattern);
        }
    }
}

