using GamePloy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloyConfigData
{
    public class ConfigTerrainData : BaseConfigData
    {
        public int Id;
        public string Des;
        public int Height;
        public int MoveSpend;
        public LandSurfaceType SurfaceType;
        public string TerrainAssetPath;
        private int m_landTypeIndex;
        private string m_assetName;

        protected override void OnLoad(object obj)
        {
            Dictionary<string, object> dic = obj as Dictionary<string, object>;
            Id = int.Parse(dic["id"].ToString());
            Des = dic["desc"].ToString();
            Height = int.Parse(dic["height"].ToString());
            MoveSpend = int.Parse(dic["moveSpend"].ToString());
            m_landTypeIndex = int.Parse(dic["landSurfaceType"].ToString());
            SurfaceType = (LandSurfaceType)m_landTypeIndex;
            m_assetName = dic["assetName"].ToString();
            TerrainAssetPath = UIDef.TerrianPath + m_assetName;
        }
        
    }
}

