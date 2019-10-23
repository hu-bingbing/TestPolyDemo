
using GamePoly.Hex;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public abstract class BaseLevelData
    {
        protected GameObject objLandItem;
        protected GameObject objGroundItem;
        protected Transform objParent;
        protected LandItem thisBornLandItem;
        protected List<LandItem> m_landList;
        protected int count;
        protected int countx;
        protected int county;
        protected float radius;
        
        public void Create(Transform parent,object arg = null)
        {
            objParent = parent;
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

        #region 外部override

        protected abstract void OnCreate(Transform parent, object arg = null);

        protected abstract void OnSetBornPos();
        #endregion
    }
    

}

