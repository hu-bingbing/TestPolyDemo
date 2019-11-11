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

        public DeleOnRefreshNewTech OnRefreshTech;

        private ConfigTechnologyData m_bornTechnology;
        public ConfigTechnologyData BornTechnology
        {
            get { return m_bornTechnology; }
        }
        /// <summary>
        /// 作用类型
        /// </summary>
        private Dictionary<int, List<ConfigTechnologyData>> m_technologyEffect;
        public Dictionary<int, List<ConfigTechnologyData>> OwnTechnologyEffectDic
        {
            get { return m_technologyEffect; }
        }

        /// <summary>
        /// 不同的模块用到不同的科技
        /// </summary>
        private List<ConfigTechnologyData> m_needTechnologyList;
        public List<ConfigTechnologyData> NeedTechnologyList
        {
            get { return m_needTechnologyList; }
        }

        /// <summary>
        /// 第一等级的科技
        /// </summary>
        private List<ConfigTechnologyData> m_topTechnologyList;
        public List<ConfigTechnologyData> TopTechnologyList
        {
            get { return m_topTechnologyList; }
        }
        /// <summary>
        /// 已经点开的科技
        /// </summary>
        private List<ConfigTechnologyData> m_ownTechList;
        public List<ConfigTechnologyData> OwnTechList
        {
            get { return m_ownTechList; }
        }
        /// <summary>
        /// 解锁的科技
        /// </summary>
        private List<ConfigTechnologyData> m_unlockTectList;
        public List<ConfigTechnologyData> UnlockTectList
        {
            get { return m_unlockTectList; }
        }
        
        public void Initialize(object args = null)
        {
            m_technologyEffect = new Dictionary<int, List<ConfigTechnologyData>>();
            m_topTechnologyList = new List<ConfigTechnologyData>();
            m_needTechnologyList = new List<ConfigTechnologyData>();
            m_ownTechList = new List<ConfigTechnologyData>();
        }

        public void SetNeedTechnology(int _effectid)
        {
            if (m_technologyEffect.ContainsKey(_effectid))
            {
                //m_needTechnologyList.Clear();
                m_needTechnologyList = m_technologyEffect[_effectid];
            }
        }
        /// <summary>
        /// 初始科技
        /// </summary>
        /// <param name="_tempData"></param>
        public void SetBornTechnology(ConfigTechnologyData _tempData)
        {
            m_bornTechnology = _tempData;
            AddToTechnologyDic(m_bornTechnology);
        }
        
        public void AddToTechnologyDic(ConfigTechnologyData _tempData)
        {
            if (!m_ownTechList.Contains(_tempData))
            {
                Debug.LogWarning("-------addown:" + _tempData.Id);
                m_ownTechList.Add(_tempData);
            }

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

            if(OnRefreshTech != null)
            {
                OnRefreshTech();
            }
        }

        public void AddToTopTech(ConfigTechnologyData _data)
        {
            m_topTechnologyList.Add(_data);
        }

        public void ToUpdate()
        {
           
        }
    }
}

