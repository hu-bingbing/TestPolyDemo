using GamePloyConfigData;
using SGF.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public class TechnologyManager : Singleton<TechnologyManager>, IClue
    {
        public int interval
        {
            get { return 2; }
        }

        private ConfigTechnologyData m_bornTechnology;
        public ConfigTechnologyData BornTechnology
        {
            get { return m_bornTechnology; }
        }

        private Dictionary<int, List<int>> m_technologyEffect;
        public Dictionary<int, List<int>> TechnologyEffectDic
        {
            get { return m_technologyEffect; }
        }


        public void Initialize(object args = null)
        {
            m_technologyEffect = new Dictionary<int, List<int>>();
        }


        public void SetBornTechnology(ConfigTechnologyData _tempData)
        {
            m_bornTechnology = _tempData;
        }

        public void AddToTechnologyDic(ConfigTechnologyData _tempData)
        {

        }

        public void ToUpdate()
        {
           
        }
    }
}

