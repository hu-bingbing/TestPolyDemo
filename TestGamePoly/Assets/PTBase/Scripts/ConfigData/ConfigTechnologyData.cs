using GamePloy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloyConfigData
{
    public class TechnologyEffectData
    {
        public int EffectId;
        public int ResultNum;

        public TechnologyEffectData(int _id,int _num)
        {
            EffectId = _id;
            ResultNum = _num;
        }
    }

    public class ConfigTechnologyData : BaseConfigData
    {
        public int Id;
        public string Name;
        public string TechnologyName;
        private string m_iconName;
        public string IconAssetPath;
        public int TechnologyLv;
        public int TechnologyPreId;
        /// <summary>
        /// 原始花费
        /// </summary>
        public int OriginalCost;
        public List<TechnologyEffectData> EffectDataList;
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
            m_iconName = dic["iconName"].ToString();
            IconAssetPath = UIDef.TechnologyIconPath + m_iconName;
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
            EffectDataList = new List<TechnologyEffectData>();
            if (dic["effect00"] != null)
            {
                m_effect00 = int.Parse(dic["effect00"].ToString());
                m_result00 = int.Parse(dic["result00"].ToString());
                EffectDataList.Add(new TechnologyEffectData(m_effect00, m_result00));
            }

            if(dic["effect01"] != null)
            {
                m_effect01 = int.Parse(dic["effect01"].ToString());
                m_result01 = int.Parse(dic["result01"].ToString());
                EffectDataList.Add(new TechnologyEffectData(m_effect01, m_result01));
            }

            if(dic["effect02"] != null)
            {
                m_effect02 = int.Parse(dic["effect02"].ToString());
                m_result02 = int.Parse(dic["result02"].ToString());
                EffectDataList.Add(new TechnologyEffectData(m_effect02, m_result02));
            }
            
            
           
        }
    }
}

