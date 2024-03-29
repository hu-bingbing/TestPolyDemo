﻿
using GamePloyConfigData;
using GamePoly.Hex;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public abstract class BaseLevelMapData
    {
        protected GameObject objLandItem;
        /// <summary>
        /// 基础地板数据
        /// </summary>
        protected ConfigTerrainData landTerrainData;
        /// <summary>
        /// 初始台地数据
        /// </summary>
        protected ConfigArchitectureData bornBuildingData;
        protected Transform objParent;
        protected LandSurfaceItem thisBornLandItem;
        protected List<LandSurfaceItem> m_landList;
        protected int count;
        protected int countx;
        protected int county;
        protected float radius;
        
        public void Create(Transform parent,object arg = null)
        {
            objParent = parent;
            landTerrainData = ConfigDataManager.Instance.TerrainDataByLandType[LandSurfaceType.Land];
            bornBuildingData = ConfigDataManager.Instance.ArchitectureDataByFeatureType[LandFeatureType.BornPoint];
            OnCreate(parent,arg);
            GenerateMap(countx, county);
            SetBornPos();
        }

        protected void GenerateMap(int _width,int _height)
        {
            HexMap map = new HexMap()
            {
                LandList = m_landList,
            };

            map.Generate();
            map.SpawnToScene();
        }

        public void SetBornPos()
        {
            OnSetBornPos();
        }

        public void Release()
        {
            OnRelease();
        }

        #region 外部override

        protected abstract void OnCreate(Transform parent, object arg = null);

        protected abstract void OnSetBornPos();

        protected abstract void OnRelease();
        #endregion
    }
    

}

