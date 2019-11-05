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
        public string AssetName;

        protected override void OnLoad(object obj)
        {
            Dictionary<string, object> dic = obj as Dictionary<string, object>;
            Id = int.Parse(dic["id"].ToString());
            Des = dic["desc"].ToString();
            Height = int.Parse(dic["height"].ToString());
            MoveSpend = int.Parse(dic["moveSpend"].ToString());
            AssetName = dic["assetName"].ToString();

        }
        
    }
}

