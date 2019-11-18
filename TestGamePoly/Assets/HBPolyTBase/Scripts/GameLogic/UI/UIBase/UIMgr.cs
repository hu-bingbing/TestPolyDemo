using SGF.Unity.UI;
using SGF.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePloy
{
    public class UIMgr : Singleton<UIMgr>
    {
        private static Dictionary<UILayer, RectTransform> m_layers = new Dictionary<UILayer, RectTransform>();


        #region UI相关属性

        private static GameObject m_root;
        /// <summary>
        /// UI根节点
        /// </summary>
        public static GameObject UIRoot
        {
            get { return m_root; }
        }
        
        private static Camera m_uiCamera;
        /// <summary>
        /// UI摄像机
        /// </summary>
        public static Camera UICamera
        {
            get { return m_uiCamera; }
        }
        private static Canvas m_uiScreen;
        /// <summary>
        /// UI屏幕
        /// </summary>
        public static Canvas UIScreen
        {
            get { return m_uiScreen; }
        }

        private static CanvasScaler m_uiScaler;
        /// <summary>
        /// 屏幕缩放
        /// </summary>
        public static CanvasScaler UIScaler
        {
            get { return m_uiScaler; }
        }

        /// <summary>
        /// 屏幕宽度
        /// </summary>
        public static float screenWidth
        {
            get
            {
                if (m_uiScreen == null)
                    return 0;
                return m_uiScreen.pixelRect.width / m_uiScreen.scaleFactor;
            }
        }
        /// <summary>
        /// 屏幕高度
        /// </summary>
        public static float screenHeight
        {
            get
            {
                if (m_uiScreen == null)
                    return 0;
                return m_uiScreen.pixelRect.height / m_uiScreen.scaleFactor;
            }
        }
        #endregion

        public static void Init()
        {
            if (m_root != null)
                return;

            m_root = GameObject.Find("UIRoot");

            if (m_root == null)
            {
                Debug.LogError("场景中缺少UIRoot!");
                return;
            }

            ObjFindTool rootObj = ObjFindTool.Create(m_root);
            m_uiCamera = rootObj.GetChildComponent<Camera>(ConstantData.UICamera);
            m_uiScreen = m_root.GetComponent<Canvas>();
            m_uiScaler = m_root.GetComponent<CanvasScaler>();

            m_uiCamera.clearFlags = CameraClearFlags.Depth;
            //矫正屏幕宽高比
            m_uiScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            float sw = screenWidth;
            float sh = screenHeight;
            if (sw != 0 && sh != 0)
            {
                float f = sw > sh ? sh / sw : sw / sh;
                m_uiScaler.matchWidthOrHeight = f;
            }

            AddUILayer(UILayer.BASE_LAYER, rootObj.GetChildComponent<RectTransform>(ConstantData.UIBaseLayer), 0f);
            AddUILayer(UILayer.WINDOW_LAYER, rootObj.GetChildComponent<RectTransform>(ConstantData.UIWindowLayer), -1000f);
            AddUILayer(UILayer.MODE_LAYER, rootObj.GetChildComponent<RectTransform>(ConstantData.UIModelLayer), -2000f);
            AddUILayer(UILayer.TOP_LAYER, rootObj.GetChildComponent<RectTransform>(ConstantData.UITopLayer), -3000f);
        }



        private static void AddUILayer(UILayer layer, RectTransform layerTransform, float z)
        {
            FitScreen(layerTransform);
            m_layers[layer] = layerTransform;
            layerTransform.anchoredPosition3D = new Vector3(0f, 0f, z);
        }

        public static void FitScreen(RectTransform rtf)
        {
            if (rtf.sizeDelta != Vector2.zero)
                rtf.sizeDelta = Vector2.zero;
            if (rtf.anchorMax != Vector2.one)
                rtf.anchorMax = Vector2.one;
            if (rtf.anchorMin != Vector2.zero)
                rtf.anchorMin = Vector2.zero;
            if (rtf.anchoredPosition != Vector2.zero)
                rtf.anchoredPosition = Vector2.zero;

            rtf.pivot = Vector2.one / 2f;
            if (rtf.localScale != Vector3.one)
                rtf.localScale = Vector3.one;
        }


        public void SetUILayer(Transform rt, UILayer layer)
        {
            if(GetLayerTransform(layer) != null)
            {
                rt.SetParent(GetLayerTransform(layer));
            }
        }

        /// <summary>
        /// 获取UI层
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        private static RectTransform GetLayerTransform(UILayer layer)
        {
            RectTransform trs = null;
            m_layers.TryGetValue(layer, out trs);
            if (trs == null)
            {
                trs = m_root.GetComponent<RectTransform>();
                Debug.LogFormat("{0}  UI层不存在", layer);
            }

            return trs;
        }
    }

    public enum UILayer
    {
        NONE,
        BASE_LAYER,
        WINDOW_LAYER,
        MODE_LAYER,
        TOP_LAYER,
    }
}


