using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public class EasyLevelData : BaseLevelData
    {
        private Dictionary<LandSurfaceData, LandSurfaceItem> m_landDic;
        private Dictionary<Vector3, LandSurfaceItem> m_landIndexDic;
   

        protected override void OnCreate(Transform parent, object arg = null)
        {
            count = 20;
            countx =24;
            county = 24;
            radius = 5.06f;
            m_landDic = new Dictionary<LandSurfaceData, LandSurfaceItem>();
            m_landIndexDic = new Dictionary<Vector3, LandSurfaceItem>();
            m_landList = new List<LandSurfaceItem>();
            objLandItem = Resources.Load<GameObject>(LandEntityPath.LandItemPath);
            SetLand(parent);
          
        }
        
        void SetLand(Transform parent)
        {
            for (int x = -countx; x <= countx; x++)
            {
                for (int y = -county; y <= county; y++)
                {
                    float posx = x * radius + y * radius * (float)Math.Cos(Math.PI / 3);
                    float posy = y * radius * (float)Math.Sin(Math.PI / 3);
                    if (Math.Abs(posx) < count * radius && Math.Abs(posy) < count * radius)
                    {
                        LandSurfaceItem _landItem = UnityEngine.Object.Instantiate(objLandItem).GetComponent<LandSurfaceItem>();
                        int z = 0 - x - y;
                        LandSurfaceData _new = new LandSurfaceData(new Vector3(posx, 0.5f, posy), x, y, z);

                        _landItem.CreateSurface(_new, parent, ShowFogBrick);
                        m_landDic.Add(_new, _landItem);
                        m_landIndexDic.Add(new Vector3(x, y, z), _landItem);
                        m_landList.Add(_landItem);
                    }
                }
            }
        }

        int outCount = 0;

        public void ShowFogBrick(BaseLandItem landitem, int distance)
        {
            Vector3 tempCenterPos = landitem.thisLandData.IndexPos;
            List<Vector3> neighborList = new List<Vector3>();
            List<Vector3> tempneighborList = new List<Vector3>();
         
            while (outCount < distance)
            {
                if(outCount == 0)
                {
                    tempneighborList = landitem.NeighborIndexList;
                }
                else
                {

                    tempneighborList.Clear();
                   
                    for (int i = 0; i < neighborList.Count; i++)
                    {
                        var tempIn = neighborList[i];
                        if (m_landIndexDic.ContainsKey(tempIn))
                        {
                            var tempItem = m_landIndexDic[tempIn];
                            var tempItemLi = tempItem.NeighborIndexList;
                            for (int j = 0; j < tempItemLi.Count; j++)
                            {
                                var tempIndexJ = tempItemLi[j];
                                if (!tempneighborList.Contains(tempIndexJ))
                                {
                                    tempneighborList.Add(tempIndexJ);
                                }
                            }
                        }
                    }
                    if (tempneighborList.Contains(tempCenterPos))
                    {
                        tempneighborList.Remove(tempCenterPos);
                    }
                }
                
                for (int i = 0; i < tempneighborList.Count; i++)
                {
                    var _thisTempV = tempneighborList[i];
                    if (m_landIndexDic.ContainsKey(_thisTempV) && !neighborList.Contains(_thisTempV))
                    {
                        neighborList.Add(_thisTempV);
                    }
                }
                outCount += 1;
            }

            for(int i = 0; i < neighborList.Count; i++)
            {
                var neightItem = m_landIndexDic[neighborList[i]];
                neightItem.SetHighlight();
            }
      
        }
        
        protected override void OnSetBornPos()
        {
            int _randomIndex = UnityEngine.Random.Range(0, m_landList.Count);
            Debug.Log("_randomIndex" + _randomIndex);
            thisBornLandItem = m_landList[_randomIndex];
            thisBornLandItem.CreateBuilding(BuildingDef.BornArchitecture01);
            LevelManager.Instance.SetCameraTarget(thisBornLandItem.transform);
        }


    }
}

