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


        public void Initialize(object args = null)
        {
            
        }


        public void InitBornTechnology(ConfigTechnologyData _tempData)
        {
            m_bornTechnology = _tempData;
        }

        public void ToUpdate()
        {
           
        }
    }
}

