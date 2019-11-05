using GamePloyConfigData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    /// <summary>
    /// 地表数据
    /// </summary>
    public class LandSurfaceData
    {
        public Vector3 Pos;
        public Vector3 IndexPos;
        public int Index_X;
        public int Index_Y;
        public int Index_Z;

        public LandSurfaceData(Vector3 _pos, int _x, int _y, int _z)
        {
            Pos = _pos;
            Index_X = _x;
            Index_Y = _y;
            Index_Z = _z;
            IndexPos = new Vector3(_x, _y, _z);
        }
    }

    public abstract class BaseLandItem : ObjectRectCom
    {
        protected LandSurfaceType m_landType;
        /// <summary>
        /// 地形类型
        /// </summary>
        public LandSurfaceType thisLandFeatureType
        {
            get { return m_landType; }
        }

        protected ConfigTerrainData m_terrainData;
        public ConfigTerrainData thisTerrainData
        {
            get { return m_terrainData; }
        }


        protected LandSurfaceData m_landData;
        public LandSurfaceData thisLandData
        {
            get { return m_landData; }
        }

        protected GameObject m_objItem;
        public GameObject thisLandObj
        {
            get { return m_objItem; }
        }

        protected List<Vector3> m_neighborIndexList;
        public List<Vector3> NeighborIndexList
        {
            get { return m_neighborIndexList; }
        }

        protected bool m_isShow;
        /// <summary>
        /// 是否显示地形
        /// </summary>
        public bool IsFeatureShow
        {
            get { return m_isShow; }
        }

        protected Action<BaseLandItem, int> m_showFogCallback;

        #region 外部调用


        /// <summary>
        /// 新建地表
        /// </summary>
        /// <param name="_landData"></param>
        /// <param name="parent"></param>
        /// <param name="showFogCallback"></param>
        public void CreateSurface(LandSurfaceData _landData, Transform parent, System.Action<BaseLandItem, int> showFogCallback = null)
        {
            m_landData = _landData;
            this.transform.SetParent(parent, true);
            this.transform.position = _landData.Pos;
            m_showFogCallback = showFogCallback;
            OnCreateLandSurface();
            m_neighborIndexList = new List<Vector3>();
            m_neighborIndexList = GetNeighborBrick(m_landData.IndexPos);
            m_isShow = false;
        }

        public void SetLandType(LandSurfaceType _type)
        {
            m_landType = _type;
            m_terrainData = ConfigDataManager.Instance.TerrainDataByLandType[m_landType];
        }
        /// <summary>
        /// 设置显示
        /// </summary>
        public void SetHighlight()
        {
            var mesh = UtilityTool.GetChild(modelPoint.gameObject, "baseItem", true);
            var renderer = mesh.GetComponent<Renderer>();
            if (!renderer)
            {
                renderer = mesh.gameObject.AddComponent<Renderer>();
            }
            Material highlightMaterial = new Material(Shader.Find("Custom/RimLighting2"));
            if (highlightMaterial != null)
            {
                renderer.material = highlightMaterial;
                //highlightMaterial.SetTexture("_MainTex", modelTexture);
                //highlightMaterial.SetColor("_MainColor", mainColor);
            }
            CreateLandFeature();
            m_isShow = true;
        }


        public void RayThisLand()
        {
            Debug.Log("type:" + m_landType);
        }


        #endregion


        /// <summary>
        /// 
        /// </summary>
        public void SetNeighbor(int distance)
        {
            if(m_showFogCallback != null)
            {
                m_showFogCallback(this, distance);
            }
        }
        /// <summary>
        /// 创建地形
        /// </summary>
        public void CreateLandFeature()
        {
            m_objItem = Instantiate(Resources.Load<GameObject>(m_terrainData.TerrainAssetPath));

            ObjectUtil.Attach(m_objItem.transform, modelPoint);
            //ObjectUtil.Attach(this.transform, parent);

        }

        public void CreateBuilding(object args = null)
        {
            Debug.Log("CreateBuilding:" + args);
            Debug.LogWarning(m_landData.Index_X + "y:" + m_landData.Index_Y);
            OnCreateBuilding(args);
            SetNeighbor(2);
        }

     

        protected List<Vector3> GetNeighborBrick(Vector3 centrePos)
        {
            List<Vector3> tempNeighborBrick = new List<Vector3>();
            float tempX = centrePos.x;
            float tempY = centrePos.y;
            float tempZ = centrePos.z;

            tempNeighborBrick.Add(new Vector3(tempX, tempY - 1, tempZ + 1));
            tempNeighborBrick.Add(new Vector3(tempX, tempY + 1, tempZ - 1));

            tempNeighborBrick.Add(new Vector3(tempX + 1, tempY, tempZ - 1));
            tempNeighborBrick.Add(new Vector3(tempX - 1, tempY, tempZ + 1));

            tempNeighborBrick.Add(new Vector3(tempX + 1, tempY - 1, tempZ));
            tempNeighborBrick.Add(new Vector3(tempX - 1, tempY + 1, tempZ));
            return tempNeighborBrick;
        }

        public void Release()
        {
            OnRelease();
        }


        #region 需要Override 方法

        /// <summary>
        /// 创建地表
        /// </summary>
        protected abstract void OnCreateLandSurface();
        /// <summary>
        /// 创建地形
        /// </summary>
        /// <param name="args"></param>
        protected abstract void OnCreateBuilding(object args = null);
        /// <summary>
        /// 释放
        /// </summary>
        protected abstract void OnRelease();

        #endregion

    }
}

