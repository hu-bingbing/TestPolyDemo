using SGF.Utils;
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
        private LevelType m_currentLevelType;
        public LevelType CurrentLevelType
        {
            get { return m_currentLevelType; }
        }

        private BaseLevelData m_currentLevelData;
        public BaseLevelData CurrentLevelData
        {
            get { return m_currentLevelData; }
        }

        private Transform m_landRoot;
        private Transform m_cameraRoot;

        public int interval
        {
            get { return 1; }
        }

        public void Initialize(object args = null)
        {
            m_landRoot = EntityRoot.Find(ConstantData.EntityRoot, ConstantData.LandRoot);
            m_cameraRoot = EntityRoot.Find(ConstantData.EntityRoot, ConstantData.CameraRoot);
        }

        public void LoadLevelEntity(LevelType _type)
        {
            m_currentLevelType = _type;

            #region 实体加载

            CreateLevelData(_type, m_landRoot);
            #endregion

            #region 相机加载
            //SetCameraTarget(m_landRoot);
            #endregion
        }

        public void CreateLevelData(LevelType _type, Transform parent, object arg = null)
        {
            if (_type == LevelType.EASY)
            {
                m_currentLevelData = CreateLevelData<EasyLevelData>(parent, arg);
            }
        }

        public T CreateLevelData<T>(Transform parent, object arg = null) where T : BaseLevelData,new()
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
        }


        public void ToUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}

