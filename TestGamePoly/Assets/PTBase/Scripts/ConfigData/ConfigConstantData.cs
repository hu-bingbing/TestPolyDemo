using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloyConfigData
{
    public class ConfigConstantData : BaseConfigData
    {
        public int Id;
        public string Des;
        public string Data;

        protected override void OnLoad(object obj)
        {
            Dictionary<string, object> dic = obj as Dictionary<string, object>;
            Id = int.Parse(dic["id"].ToString());
            Des = dic["desc"].ToString();
            Data = dic["data"].ToString();
        }

    }
}

