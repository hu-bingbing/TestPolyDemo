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

        private Dictionary<int, List<ConfigTechnologyData>> m_technologyEffect;
        public Dictionary<int, List<ConfigTechnologyData>> TechnologyEffectDic
        {
            get { return m_technologyEffect; }
        }

        private List<ConfigTechnologyData> m_needTechnologyList;
        public List<ConfigTechnologyData> NeedTechnologyList
        {
            get { return m_needTechnologyList; }
        }



        public void Initialize(object args = null)
        {
            m_technologyEffect = new Dictionary<int, List<ConfigTechnologyData>>();
            m_needTechnologyList = new List<ConfigTechnologyData>();
        }

        public void SetNeedTechnology(int _effectid)
        {
            if (m_technologyEffect.ContainsKey(_effectid))
            {
                //m_needTechnologyList.Clear();
                m_needTechnologyList = m_technologyEffect[_effectid];
            }
        }

        public void SetBornTechnology(ConfigTechnologyData _tempData)
        {
            m_bornTechnology = _tempData;
            AddToTechnologyDic(m_bornTechnology);
        }

        public void AddToTechnologyDic(ConfigTechnologyData _tempData)
        {
            if(_tempData.EffectDataList!= null && _tempData.EffectDataList.Count > 0)
            {
                for(int i = 0;i < _tempData.EffectDataList.Count; i++)
                {
                    var _tempEffectData = _tempData.EffectDataList[i];
                    var _effectid = _tempEffectData.EffectId;
                    var _resultId = _tempEffectData.ResultNum;
                    if (!m_technologyEffect.ContainsKey(_effectid))
                    {
                        m_technologyEffect.Add(_effectid, new List<ConfigTechnologyData>());
                    }
                    m_technologyEffect[_effectid].Add(_tempData);
                }
            }
        }

        public void ToUpdate()
        {
           
        }
    }
}

