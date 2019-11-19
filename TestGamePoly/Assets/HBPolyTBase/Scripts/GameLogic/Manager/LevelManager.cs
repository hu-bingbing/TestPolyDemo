using GamePloyConfigData;
using SGF.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public enum LevelType
    {
        EASY,
        HARD
    }

    public class LevelManager : Singleton<LevelManager>, IClue
    {
        private bool m_clickBlock;
        public bool IsClickBolck
        {
            get { return m_clickBlock; }
        }

        private LevelType m_currentLevelType;
        public LevelType CurrentLevelType
        {
            get { return m_currentLevelType; }
        }

        private BaseLevelMapData m_currentLevelData;
        public BaseLevelMapData CurrentLevelData
        {
            get { return m_currentLevelData; }
        }

        private BaseLandItem m_currentClickLandItem;
        public BaseLandItem CurrentClickLandItem
        {
            get { return m_currentClickLandItem; }
        }


        private Transform m_landRoot;
        private Transform m_cameraRoot;

        private Camera m_gameCamera;
        public Camera GameCamera
        {
            get { return m_gameCamera; }
        }

        public int interval
        {
            get { return 1; }
        }

        public void Initialize(object args = null)
        {
            m_landRoot = EntityRoot.Find(ConstantData.EntityRoot, ConstantData.LandRoot);
            m_cameraRoot = EntityRoot.Find(ConstantData.EntityRoot, ConstantData.CameraRoot);
            SetClickBolck(false);
        }

        public void SetClickBolck(bool _iscan)
        {
            m_clickBlock = _iscan;
        }

        public void LoadLevelEntity(LevelType _type)
        {
            m_currentLevelType = _type;
            GameManager.Instance.OnChangeGameGold(5);

            #region 实体加载

            CreateLevelData(_type, m_landRoot);
            SetClickBolck(true);
            #endregion

            #region 相机加载
            //SetCameraTarget(m_landRoot);
            #endregion

            GestureManager.Instance.OnGestureTap += OnGestureClickTap;
            GameManager.Instance.OnClickTechBtn += OnClickTech;
        }

        private void OnClickTech(ConfigTechnologyData techData)
        {
            Debug.Log("--onclik--tech:" + techData.Id + "  listnum: " + techData.EffectDataList.Count);

            SetClickBolck(false);
        }

        private void OnGestureClickTap(Vector3 gesturePos)
        {
            if (m_clickBlock)
            {
                RayTheMap(gesturePos);
            }
        }
        /// <summary>
        /// 点击到世界地图上的砖块
        /// </summary>
        /// <param name="_pos"></param>
        public void RayTheMap(Vector3 _pos)
        {
            RaycastHit hit;
            Ray ray = m_gameCamera.ScreenPointToRay(_pos);

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("rayhit:" + hit.transform.name);
                var temp = hit.transform.GetComponent<BaseLandItem>();
                m_currentClickLandItem = temp;
                temp.RayThisLand();
                GameManager.Instance.ClickGameMapItem(temp);
            }
        }

        public void CreateLevelData(LevelType _type, Transform parent, object arg = null)
        {
            if (_type == LevelType.EASY)
            {
                m_currentLevelData = CreateLevelData<EasyLevelMapData>(parent, arg);
            }
        }

        public T CreateLevelData<T>(Transform parent, object arg = null) where T : BaseLevelMapData,new()
        {
            T leveldata = new T();
            leveldata.Create(parent, arg);
            return leveldata;
        }

        public void SetCameraTarget(Transform target)
        {
            InitEntityCamera(target);
        }

        void InitEntityCamera(Transform target)
        {
            if (m_cameraRoot.GetComponent<CameraFollow>() == null)
            {
                m_cameraRoot.gameObject.AddComponent<CameraFollow>();
            }
            m_cameraRoot.GetComponent<CameraFollow>().target = target;
            m_gameCamera = UtilityTool.GetChild(m_cameraRoot.gameObject, "Camera", true).GetComponent<Camera>();
        }
        
        public void ToUpdate()
        {
            if (Input.GetMouseButtonDown(0) && m_gameCamera != null && m_clickBlock)
            {
               // RayTheMap();
            }
        }



        public void ReleaseMap()
        {
            GestureManager.Instance.OnGestureTap -= OnGestureClickTap;
            GameManager.Instance.OnClickTechBtn -= OnClickTech;
            m_currentLevelData.Release();
            m_currentLevelData = null;
        }

        public void Release(object args = null)
        {

        }
    }
}

