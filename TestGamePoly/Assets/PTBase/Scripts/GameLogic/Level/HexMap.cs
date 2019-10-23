using GamePloy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePoly.Hex
{
    public class HexMap
    {
        private int[] data;
        private List<LandItem> m_landList;
        public List<LandItem> LandList
        {
            set
            {
                m_landList = new List<LandItem>();
                m_landList = value;
                data = new int[m_landList.Count];
            }
        }


        public int this[int dataIndex]
        {
            get { return data[dataIndex]; }
        }

        public bool Generate( System.Action<float> progressCallback = null)
        {
            return Generate(GetRandomSeeds(), progressCallback);
        }

        public bool Generate(float[] seeds, System.Action<float> progressCallback = null)
        {
            int[] tempData = new int[m_landList.Count];
            for(int i = 0; i < seeds.Length; i++)
            {
                int seedData = (int)(seeds[i] * (2f - 0.0001f));
                tempData[i] = seedData;
            }

            // Copy to Data
            tempData.CopyTo(data, 0);


            return true;
        }

        public float[] GetRandomSeeds()
        {
            float[] seeds = new float[m_landList.Count];
            for(int i = 0; i < seeds.Length; i++)
            {
                seeds[i] = Random.value;
            }
            //for (int i = 0; i < width; i++)
            //{
            //    for (int j = 0; j < height; j++)
            //    {
            //        seeds[j * width + i] = Random.value;
            //    }
            //}
            return seeds;
        }
        
        public void SpawnToScene(GameObject prefabBirthPoint = null)
        {
            int landIndex = 0;
            int waterIndex = 0;
            for(int i = 0; i < m_landList.Count; i++)
            {
                int alt = this[i];
                var tempLandItem = m_landList[i];
                var tempLandData = tempLandItem.thisLandData;
                LandType tempType;
                if(alt == 0)
                {
                    tempType = LandType.Water;
                    waterIndex += 1;
                }
                else
                {
                    tempType = LandType.Ground;
                    landIndex += 1;
                }
                tempLandItem.SetLandType(tempType);
                //string sourcePath = alt == 0 ? _typeWater : _typeGround;
                //GameObject tempgo = Object.Instantiate(Resources.Load<GameObject>(sourcePath));
                //tempgo.transform.SetParent(tempLandItem.modelPoint);
                //tempgo.transform.localPosition = Vector3.zero;
                //tempgo.transform.localScale = Vector3.one;

            }
            Debug.LogWarning("waterIndex:" + waterIndex);
            Debug.LogWarning("landIndex:" + landIndex);
        }
    }
}

