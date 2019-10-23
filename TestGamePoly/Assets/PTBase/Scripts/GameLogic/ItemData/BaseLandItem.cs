using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public class LandData
    {
        public Vector3 Pos;
        public Vector3 IndexPos;
        public int Index_X;
        public int Index_Y;
        public int Index_Z;
        
        public LandData(Vector3 _pos, int _x,int _y,int _z)
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
        private LandType m_landType;
        public LandType thisLandType
        {
            get { return m_landType; }
        }

        protected LandData m_landData;
        public LandData thisLandData
        {
            get { return m_landData; }
        }

        protected GameObject m_objItem;
        public GameObject thisLandObj
        {
            get { return m_objItem; }
        }

        private List<Vector3> m_neighborIndexList;
        public List<Vector3> NeighborIndexList
        {
            get { return m_neighborIndexList; }
        }

        private Action<BaseLandItem, int> m_showFogCallback;



        public void Create(LandData _landData, Transform parent, System.Action<BaseLandItem, int> showFogCallback = null)
        {
            m_landData = _landData;
            this.transform.SetParent(parent, true);
            this.transform.position = _landData.Pos;
            m_showFogCallback = showFogCallback;
            OnCreateBaseLand();
            m_neighborIndexList = new List<Vector3>();
            m_neighborIndexList = GetNeighborBrick(m_landData.IndexPos);
        }

        public void SetLandType(LandType _type)
        {
            m_landType = _type;
        }

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

        public void CreateLand()
        {
            m_objItem = Instantiate(Resources.Load<GameObject>(ConstantData.LandItemPathByTypeDic[thisLandType]));

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
            CreateLand();
        }

        public List<Vector3> GetNeighborBrick(Vector3 centrePos)
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

        protected abstract void OnCreateBaseLand();
        protected abstract void OnCreateBuilding(object args = null);
        protected abstract void OnRelease();
     
    }
}

