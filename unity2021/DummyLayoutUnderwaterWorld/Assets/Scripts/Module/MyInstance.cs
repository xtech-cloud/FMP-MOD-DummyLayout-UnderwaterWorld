

using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using LibMVCS = XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.Proto;
using XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.MVCS;
using UnityEngine.EventSystems;

namespace XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.Unity
{
    /// <summary>
    /// 实例类
    /// </summary>
    public class MyInstance : MyInstanceBase
    {
        public class UiRefenrence
        {
            public RectTransform renderer;
            public RectTransform cardTemplate;
            public RectTransform[] cardCloneS;
        }

        public class WorldRefenrence
        {
            public Camera camera;
        }

        private UiRefenrence uiRefenrence_ = new UiRefenrence();
        private WorldRefenrence worldRefenrence_ = new WorldRefenrence();
        private int columnWidth_ = 0;
        private Dictionary<string, MyConfig.Agent> agentConfigS = new Dictionary<string, MyConfig.Agent>();
        private Dictionary<GameObject, string> uriMapS_ = new Dictionary<GameObject, string>();

        public MyInstance(string _uid, string _style, MyConfig _config, MyCatalog _catalog, LibMVCS.Logger _logger, Dictionary<string, LibMVCS.Any> _settings, MyEntryBase _entry, MonoBehaviour _mono, GameObject _rootAttachments)
            : base(_uid, _style, _config, _catalog, _logger, _settings, _entry, _mono, _rootAttachments)
        {
        }

        /// <summary>
        /// 当被创建时
        /// </summary>
        /// <remarks>
        /// 可用于加载主题目录的数据
        /// </remarks>
        public void HandleCreated()
        {
            handleCreated();
        }

        /// <summary>
        /// 当被删除时
        /// </summary>
        public void HandleDeleted()
        {
        }

        /// <summary>
        /// 当被打开时
        /// </summary>
        /// <remarks>
        /// 可用于加载内容目录的数据
        /// </remarks>
        public void HandleOpened(string _source, string _uri)
        {
            rootUI.gameObject.SetActive(true);
            rootWorld.gameObject.SetActive(true);
        }

        /// <summary>
        /// 当被关闭时
        /// </summary>
        public void HandleClosed()
        {
            rootUI.gameObject.SetActive(false);
            rootWorld.gameObject.SetActive(false);
        }

        private void handleCreated()
        {
            uiRefenrence_.renderer = rootUI.transform.Find("renderer").GetComponent<RectTransform>();
            uiRefenrence_.renderer.gameObject.SetActive(true);
            uiRefenrence_.cardTemplate = rootUI.transform.Find("card").GetComponent<RectTransform>();
            uiRefenrence_.cardTemplate.gameObject.SetActive(false);
            uiRefenrence_.cardCloneS = new RectTransform[style_.card.column];
            worldRefenrence_.camera = rootWorld.transform.Find("Camera").GetComponent<Camera>();
            columnWidth_ = (int)(uiRefenrence_.renderer.rect.width / style_.card.column);
            foreach (var agent in style_.agentS)
            {
                agentConfigS[agent.name] = agent;
            }

            // 创建前置图层
            var frontLayer = rootUI.transform.Find("FrontLayerS/Layer").GetComponent<RawImage>();
            frontLayer.gameObject.SetActive(false);
            foreach (var layer in style_.frontLayerS)
            {
                var clone = GameObject.Instantiate(frontLayer.gameObject, frontLayer.transform.parent);
                loadTextureFromTheme(layer.image, (_texture) =>
                {
                    clone.GetComponent<RawImage>().texture = _texture;
                    clone.SetActive(true);
                }, () => { });
            }

            // 创建后置图层
            var backLayer = rootUI.transform.Find("BackLayerS/Layer").GetComponent<RawImage>();
            backLayer.gameObject.SetActive(false);
            foreach (var layer in style_.backLayerS)
            {
                var clone = GameObject.Instantiate(backLayer.gameObject, backLayer.transform.parent);
                loadTextureFromTheme(layer.image, (_texture) =>
                {
                    clone.GetComponent<RawImage>().texture = _texture;
                    clone.SetActive(true);
                }, () => { });
            }

            // 应用世界渲染选项
            {
                var position = rootWorld.transform.localPosition;
                position.y = style_.renderer.worldOptions.offsetY;
                rootWorld.transform.localPosition = position;
            }
            // 创建渲染纹理
            {
                int width = Screen.width;
                int height = Screen.height;
                var rtRoot = rootUI.GetComponent<RectTransform>();
                var rendererTexture = new RenderTexture(width, height, 32, RenderTextureFormat.ARGB32);
                worldRefenrence_.camera.targetTexture = rendererTexture;
                uiRefenrence_.renderer.GetComponent<RawImage>().texture = rendererTexture;
            }
            // 应用摄像机渲染选项
            {
                worldRefenrence_.camera.fieldOfView = style_.renderer.cameraOptions.fieldOfView;
                worldRefenrence_.camera.transform.localPosition = new Vector3(worldRefenrence_.camera.transform.localPosition.x, worldRefenrence_.camera.transform.localPosition.y, style_.renderer.cameraOptions.distance);
            }

            {
                for (int i = 0; i < style_.card.column; ++i)
                {
                    var clone = GameObject.Instantiate(uiRefenrence_.cardTemplate.gameObject, uiRefenrence_.cardTemplate.parent);
                    uiRefenrence_.cardCloneS[i] = clone.GetComponent<RectTransform>();
                    var x = columnWidth_ * i - uiRefenrence_.renderer.rect.width / 2 + columnWidth_ / 2;
                    clone.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, style_.card.offset);
                    clone.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        string uri;
                        if (!uriMapS_.TryGetValue(clone, out uri))
                            return;

                        clone.SetActive(false);
                        Dictionary<string, object> variableS = new Dictionary<string, object>();
                        variableS["{{uri}}"] = uri;
                        publishSubjects(style_.card.subjectS, variableS);
                    });
                    var btnClose = clone.transform.Find("btnClose").GetComponent<Button>();
                    btnClose.onClick.AddListener(() =>
                    {
                        clone.SetActive(false);
                    });
                    alignByAncor(btnClose.transform, style_.card.closeButton.anchor);
                    loadTextureFromTheme(style_.card.closeButton.image, (_texture) =>
                    {
                        btnClose.GetComponent<RawImage>().texture = _texture;
                    }, () => { });
                }
            }


            // 绑定事件
            //if(style_.renderer.uiOptions.mode == "Overlay")
            uiRefenrence_.renderer.GetComponent<Button>().onClick.AddListener(onRendererClick);

        }

        private void onRendererClick()
        {
            Vector2 pointInRect;
            // Input.mousePosition的屏幕左下角为(0,0)，右上角为(Screen.width, Screen.height)
            //cam 参数应为与此屏幕点关联的摄像机。对于设置为 Screen Space - Overlay 模式的 Canvas 中的 RectTransform，cam 参数应为 null。
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(uiRefenrence_.renderer, Input.mousePosition, null, out pointInRect))
                return;

            // 转换完成的pointInRect的左下角为(-rect.width, -rect.height),右上角为(rect.width, rect.height)
            // 视口坐标是标准化的、相对于摄像机的坐标。摄像机左下角为 (0,0)，右上角为 (1,1)。
            // 将Ui的Rect中的坐标转换为摄像机的Viewport中的坐标
            var pointInViewportX = (pointInRect.x + uiRefenrence_.renderer.rect.width / 2) / uiRefenrence_.renderer.rect.width;
            var pointInViewportY = (pointInRect.y + uiRefenrence_.renderer.rect.height / 2) / uiRefenrence_.renderer.rect.height;
            var pointInViewport = new Vector2(pointInViewportX, pointInViewportY);
            var ray = worldRefenrence_.camera.ViewportPointToRay(pointInViewport);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit))
                return;

            // 显示名牌
            int column = (int)((pointInRect.x + (uiRefenrence_.renderer.rect.width / 2)) / columnWidth_);
            MyConfig.Agent agent;
            if (agentConfigS.TryGetValue(hit.transform.gameObject.name, out agent))
            {
                uriMapS_[uiRefenrence_.cardCloneS[column].gameObject] = agent.uri;
                loadTextureFromTheme(agent.card, (_texture) =>
                {
                    var card = uiRefenrence_.cardCloneS[column];
                    card.GetComponent<RawImage>().texture = _texture;
                    card.sizeDelta = new Vector2((float)_texture.width / _texture.height * style_.card.height, style_.card.height);
                    card.gameObject.SetActive(true);
                }, () => { });
            }

            //Debug.Log(hit.transform.name);
            var animator = hit.transform.GetComponent<Animator>();
            if (null == animator)
                return;

        }

    }
}

