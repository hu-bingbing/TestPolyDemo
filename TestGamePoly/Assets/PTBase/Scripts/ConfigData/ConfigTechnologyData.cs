using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloyConfigData
{
    public class ConfigTechnologyData : BaseConfigData
    {
        public int Id;
        public string Name;
        public string TechnologyName;
        public int TechnologyLv;
        public int TechnologyPreId;
        /// <summary>
        /// 原始花费
        /// </summary>
        public int OriginalCost;
        private int m_effect00;
        private int m_result00;
        private int m_effect01;
        private int m_result01;
        private int m_effect02;
        private int m_result02;


        protected override void OnLoad(object obj)
        {
            Dictionary<string, object> dic = obj as Dictionary<string, object>;
            Id = int.Parse(dic["id"].ToString());
            Name = dic["name"].ToString();
            TechnologyName = dic["assetName"].ToString();
            TechnologyLv = int.Parse(dic["technologyLv"].ToString());
            TechnologyPreId = int.Parse(dic["preTechnologyId"].ToString());
            switch (TechnologyLv)
            {
                case 0:
                    OriginalCost = 1;
                    break;
                case 1:
                    OriginalCost = 5;
                    break;
                case 2:
                    OriginalCost = 6;
                    break;
                case 3:
                    OriginalCost = 7;
                    break;
            }
            if(dic["effect00"] != null)
            {
                m_effect00 = int.Parse(dic["effect00"].ToString());
                m_result00 = int.Parse(dic["result00"].ToString());
            }

            if(dic["effect01"] != null)
            {
                m_effect01 = int.Parse(dic["effect01"].ToString());
                m_result01 = int.Parse(dic["result01"].ToString());
            }

            if(dic["effect02"] != null)
            {
                m_effect02 = int.Parse(dic["effect02"].ToString());
                m_result02 = int.Parse(dic["result02"].ToString());
            }
            
            
           
        }
    }
}

