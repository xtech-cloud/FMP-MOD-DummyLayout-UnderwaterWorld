
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.86.0.  DO NOT EDIT!
//*************************************************************************************

using Microsoft.AspNetCore.Components;
using AntDesign;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.MVCS;

namespace XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.Razor
{
    public partial class HealthyComponent
    {
        private HealthyFacade? getFacade()
        {
            if (null == facade_)
            {
                if (null == framework_)
                {
                    logger_?.Error("framework_ is null");
                    return null;
                }
                var entry = framework_.getUserData("XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.MVCS.Entry") as Entry;
                if (null == entry)
                {
                    logger_?.Error("entry is null");
                    return null;
                }
                permissionS_ = entry.getPermissionS();
                facade_ = entry?.getDynamicHealthyFacade("default");
                if (null == facade_)
                {
                    logger_?.Error("facade_ is null");
                    return null;
                }
                facade_?.setUiBridge(new HealthyUiBridge(this));
            }
            return facade_;
        }

        /// <summary>
        /// 注入的MVCS框架
        /// </summary>
        [Inject] Framework? framework_ { get; set; }

        /// <summary>
        /// 注入的日志
        /// </summary>
        [Inject] Logger? logger_ { get; set; }

        /// <summary>
        /// 注入的全局提示服务
        /// </summary>
        [Inject] MessageService? messageService_ { get; set; }

        /// <summary>
        /// 直系UI装饰层
        /// </summary>
        private HealthyFacade? facade_;

        /// <summary>
        /// 权限列表
        /// </summary>
        private Dictionary<string, string> permissionS_ = new Dictionary<string, string>();
    }
}
