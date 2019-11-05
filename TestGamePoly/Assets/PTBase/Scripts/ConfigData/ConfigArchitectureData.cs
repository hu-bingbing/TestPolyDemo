using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloyConfigData
{
    public class ConfigArchitectureData : BaseConfigData
    {
        public int Id;
        public string Name;
        public int TerrainId;
        public int NearBuildingId;
        public int GoldCost;
        /// <summary>
        /// 作用类型:
        ///1：直接增加人口
        ///2：根据周边某块建筑的数量增加人口
        ///3：直接增加金币
        ///4：根据周围某建筑的数量增加回合金币
        /// </summary>
        public int ActionType;
        public int ActionEffect;
        public string AssetName;

        protected override void OnLoad(object obj)
        {
            Dictionary<string, object> dic = obj as Dictionary<string, object>;
            Id = int.Parse(dic["id"].ToString());
            Name = dic["name"].ToString();
            TerrainId = int.Parse(dic["terrainId"].ToString());
            NearBuildingId = int.Parse(dic["nearBuilding"].ToString());
            GoldCost = int.Parse(dic["goldCost"].ToString());
            ActionType = int.Parse(dic["actionType"].ToString());
            ActionEffect = int.Parse(dic["actionEffect"].ToString());
            AssetName = dic["assetName"].ToString();
        }

    }
}

