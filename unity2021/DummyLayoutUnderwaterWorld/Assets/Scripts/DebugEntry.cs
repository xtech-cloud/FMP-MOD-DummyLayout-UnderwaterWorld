
using System.Collections.Generic;
using UnityEngine;

namespace XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.Unity
{
    /// <summary>
    /// 调试入口
    /// </summary>
    /// <remarks>
    /// 不参与模块编译，仅用于在编辑器中开发调试
    /// </remarks>
    public class DebugEntry : MyEntry
    {
        /// <summary>
        /// 调试预加载
        /// </summary>
        public void __DebugPreload(GameObject _exportRoot)
        {
            processRoot(_exportRoot);
            runtime_.Preload((_percentage) =>
            {
            }, () =>
            {
                createInstances(() =>
                {
                    publishPreloadSubjects();
                });
            });
        }

        /// <summary>
        /// 调试创建
        /// </summary>
        /// <param name="_uid">实例的uid</param>
        /// <param name="_style">实例的样式名</param>
        /// <param name="_uiRoot">ui的根节点（需可见）</param>
        /// <param name="_uiSlot">ui挂载的路径</param>
        /// <param name="_worldRoot">world的根节点（需可见）</param>
        /// <param name="_worldSlot">world挂载的路径</param>
        public void __DebugCreate(string _uid, string _style, string _uiRoot, string _uiSlot, string _worldRoot, string _worldSlot)
        {
            var data = new Dictionary<string, object>();
            data["uid"] = _uid;
            data["style"] = _style;
            data["uiRoot"] = _uiRoot;
            data["uiSlot"] = _uiSlot;
            data["worldRoot"] = _worldRoot;
            data["worldSlot"] = _worldSlot;
            modelDummy_.Publish(MySubjectBase.Create, data);
        }

        /// <summary>
        /// 调试打开
        /// </summary>
        /// <param name="_uid">实例的uid</param>
        /// <param name="_source">内容的源的类型</param>
        /// <param name="_uri">内容的地址</param>
        /// <param name="_delay">延迟时间，单位秒</param>
        public void __DebugOpen(string _uid, string _source, string _uri, float _delay)
        {
            var data = new Dictionary<string, object>();
            data["uid"] = _uid;
            data["source"] = _source;
            data["uri"] = _uri;
            data["delay"] = _delay;
            modelDummy_.Publish(MySubjectBase.Open, data);
        }

        /// <summary>
        /// 调试显示
        /// </summary>
        /// <param name="_uid">实例的uid</param>
        /// <param name="_delay">延迟时间，单位秒</param>
        public void __DebugShow(string _uid, float _delay)
        {
            var data = new Dictionary<string, object>();
            data["uid"] = _uid;
            data["delay"] = _delay;
            modelDummy_.Publish(MySubjectBase.Show, data);
        }

        /// <summary>
        /// 调试隐藏
        /// </summary>
        /// <param name="_uid">实例的uid</param>
        /// <param name="_delay">延迟时间，单位秒</param>
        public void __DebugHide(string _uid, float _delay)
        {
            var data = new Dictionary<string, object>();
            data["uid"] = _uid;
            data["delay"] = _delay;
            modelDummy_.Publish(MySubjectBase.Hide, data);
        }

        /// <summary>
        /// 调试关闭
        /// </summary>
        /// <param name="_uid">实例的uid</param>
        /// <param name="_delay">延迟时间，单位秒</param>
        public void __DebugClose(string _uid, float _delay)
        {
            var data = new Dictionary<string, object>();
            data["uid"] = _uid;
            data["delay"] = _delay;
            modelDummy_.Publish(MySubjectBase.Close, data);
        }

        /// <summary>
        /// 调试删除
        /// </summary>
        /// <param name="_uid">实例的uid</param>
        public void __DebugDelete(string _uid)
        {
            var data = new Dictionary<string, object>();
            data["uid"] = _uid;
            modelDummy_.Publish(MySubjectBase.Delete, data);
        }

        /// <summary>
        /// 调试嵌入
        /// </summary>
        /// <param name="_layer"></param>
        /// <param name="_pattern"></param>
        /// <param name="_virtualResolutionWidth"></param>
        /// <param name="_virtualResolutionHeight"></param>
        /// <param name="_uiSlot"></param>
        public void __DebugOnInlay(string _layer, string _pattern, int _virtualResolutionWidth, int _virtualResolutionHeight, Transform _uiSlot)
        {
            var data = new Dictionary<string, object>();
            data["layer"] = _layer;
            data["pattern"] = _pattern;
            data["virtual_resolution_width"] = _virtualResolutionWidth;
            data["virtual_resolution_height"] = _virtualResolutionHeight;
            data["uiSlot"] = _uiSlot;
            modelDummy_.Publish("/XTC/VisionLayout/DummyLayout/OnInlay", data);
        }

        public void __DebugLayoutOnEnter(string _layer, string _pattern, float _duration)
        {
            var data = new Dictionary<string, object>();
            data["layer"] = _layer;
            data["pattern"] = _pattern;
            data["duration"] = _duration;
            modelDummy_.Publish("/XTC/VisionLayout/DummyLayout/OnEnter", data);
        }

        public void __DebugLayoutOnExit(string _layer, string _pattern, float _duration)
        {
            var data = new Dictionary<string, object>();
            data["layer"] = _layer;
            data["pattern"] = _pattern;
            modelDummy_.Publish("/XTC/VisionLayout/DummyLayout/OnExit", data);
        }

        public void __DebugInTransitionOnEnter(string _layer, string _pattern, float _duration)
        {
            var data = new Dictionary<string, object>();
            data["layer"] = _layer;
            data["pattern"] = _pattern;
            data["duration"] = _duration;
            modelDummy_.Publish("/XTC/VisionLayout/DummyInTransition/OnEnter", data);
        }

        public void __DebugInTransitionOnExit(string _layer, string _pattern)
        {
            var data = new Dictionary<string, object>();
            data["layer"] = _layer;
            data["pattern"] = _pattern;
            modelDummy_.Publish("/XTC/VisionLayout/DummyInTransition/OnExit", data);
        }

        public void __DebugOutTransitionOnEnter(string _layer, string _pattern, float _duration)
        {
            var data = new Dictionary<string, object>();
            data["layer"] = _layer;
            data["pattern"] = _pattern;
            data["duration"] = _duration;
            modelDummy_.Publish("/XTC/VisionLayout/DummyOutTransition/OnEnter", data);
        }

        public void __DebugOutTransitionOnExit(string _layer, string _pattern)
        {
            var data = new Dictionary<string, object>();
            data["layer"] = _layer;
            data["pattern"] = _pattern;
            modelDummy_.Publish("/XTC/VisionLayout/DummyOutTransition/OnExit", data);
        }

    }
}
