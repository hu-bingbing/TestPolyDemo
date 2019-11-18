using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.Networking;
using SGF.Utils;
using GamePloyConfigData;


namespace GamePloy
{
    public class ConfigDataManager : Singleton<ConfigDataManager>, IClue
    {
        private Dictionary<byte, string> configPaths;
        private Dictionary<byte, Dictionary<string, object>> configData;
        private string path;
        private StreamReader reader;


        #region 本地配置表数据


        private Dictionary<int, ConfigConstantData> m_constantDataDic;
        public Dictionary<int, ConfigConstantData> ConstantDataDic
        {
            get { return m_constantDataDic; }
        }

        private Dictionary<int, ConfigTechnologyData> m_technologyDic;
        public Dictionary<int, ConfigTechnologyData> TechnologyDic
        {
            get { return m_technologyDic; }
        }
     
        private Dictionary<LandFeatureType, ConfigArchitectureData> m_architectureDataByFeatureType;
        public Dictionary<LandFeatureType, ConfigArchitectureData> ArchitectureDataByFeatureType
        {
            get { return m_architectureDataByFeatureType; }
        }
        
        private Dictionary<int, ConfigTerrainData> m_terrainDataDic;
        public Dictionary<int, ConfigTerrainData> TerrainDataDic
        {
            get { return m_terrainDataDic; }
        }
        private Dictionary<LandSurfaceType, ConfigTerrainData> m_terrainDataByLandType;
        public Dictionary<LandSurfaceType, ConfigTerrainData> TerrainDataByLandType
        {
            get { return m_terrainDataByLandType; }
        }
        
        #endregion

        public int interval
        {
            get { return 2; }
        }
        
        public void Initialize(object args = null)
        {

            path = Application.persistentDataPath + "/Data/";
            configPaths = new Dictionary<byte, string>
            {
                   { (byte)ConfigDataType.ConstantData,"ConstantData"},
                   { (byte)ConfigDataType.TerrainData,"TerrainData"},
                   { (byte)ConfigDataType.ArchitectureData,"ArchitectureData"},
                   { (byte)ConfigDataType.TechnologyData,"TechnologyData"},


            };
            configData = new Dictionary<byte, Dictionary<string, object>>();

#if UNITY_STANDALONE_WIN || UNITY_EDITOR
            if (GameEntry.Instance.isLocal)
            {
                LoadPrototype();
            }
            else
            {
                LoadAndroidPrototype();
            }

#elif UNITY_ANDROID || UNITY_IOS
                  LoadAndroidPrototype();
#endif
            LoadAndSaveConfigData();
        }

        private void LoadPrototype()
        {
            foreach (KeyValuePair<byte, string> item in configPaths)
            {
                if (!configData.ContainsKey(item.Key))
                {
                    TextAsset textJson = Resources.Load<TextAsset>("Data/" + item.Value);
                    Dictionary<string, object> dic = MiniJson.Json.Deserialize(textJson.text) as Dictionary<string, object>;
                    configData.Add(item.Key, dic);
                }
            }
        }

        private void LoadAndroidPrototype()
        {
            foreach (KeyValuePair<byte, string> item in configPaths)
            {
                if (!configData.ContainsKey(item.Key))
                {
                    string originPath = path + item.Value + ".json";
                    //最后再加载
                    FileInfo file = new FileInfo(originPath);
                    {
                        string text = File.ReadAllText(originPath);

                        Dictionary<string, object> dic = MiniJson.Json.Deserialize(text) as Dictionary<string, object>;
                        configData.Add(item.Key, dic);
                    }
                }
            }
        }

        /// <summary>
        /// 保存本地
        /// </summary>
        private void LoadAndSaveConfigData()
        {
            InitConfigDataDic();
            InitConcreteConfig();
            ReworkConfigData();
        }

        private void InitConfigDataDic()
        {
            m_constantDataDic = new Dictionary<int, ConfigConstantData>();
            m_technologyDic = new Dictionary<int, ConfigTechnologyData>();
            m_terrainDataDic = new Dictionary<int, ConfigTerrainData>();
            m_terrainDataByLandType = new Dictionary<LandSurfaceType, ConfigTerrainData>();
            m_architectureDataByFeatureType = new Dictionary<LandFeatureType, ConfigArchitectureData>();
        }

        private void InitConcreteConfig()
        {
            var tempConstantDic = GetDic<ConfigConstantData>(ConfigDataType.ConstantData);
            foreach(var value in tempConstantDic.Values)
            {
                m_constantDataDic.Add(value.Id, value);
            }

            var tempTechDic = GetDic<ConfigTechnologyData>(ConfigDataType.TechnologyData);
            foreach (var value in tempTechDic.Values)
            {
                m_technologyDic.Add(value.Id, value);
            }

            var tempArchitectureDic = GetDic<ConfigArchitectureData>(ConfigDataType.ArchitectureData);
            foreach (var value in tempArchitectureDic.Values)
            {
                if (value.FeatureType != LandFeatureType.None)
                {
                    m_architectureDataByFeatureType.Add(value.FeatureType, value);
                }
            }
            
            var tempTerrainDic = GetDic<ConfigTerrainData>(ConfigDataType.TerrainData);
            foreach (var value in tempTerrainDic.Values)
            {
                m_terrainDataDic.Add(value.Id, value);
                m_terrainDataByLandType.Add(value.SurfaceType, value);
            }
        }

        private void ReworkConfigData()
        {
            foreach(var value in m_technologyDic.Values)
            {
                int _tempValueLv = value.TechnologyLv;
                //初始科技
                if (_tempValueLv == 0)
                {
                    TechnologyManager.Instance.SetBornTechnology(value);
                }
                else if (_tempValueLv == 1)
                {
                    TechnologyManager.Instance.AddToTopTech(value);
                }
                int _tempPreId = value.TechnologyPreId;
                if(_tempPreId != 0)
                {
                    if (m_technologyDic.ContainsKey(_tempPreId))
                    {
                        m_technologyDic[_tempPreId].AddToSonList(value);
                    }
                }
            }
        }

        /// <summary>
        /// 获取指定id的数据 --- 已经加载的表数据应该缓存下来
        /// </summary>
        /// <typeparam name="T">数据对象类型</typeparam>
        /// <param name="t">数据表类型</param>
        /// <param name="id">数据id</param>
        /// <returns></returns>
        public T GetData<T>(ConfigDataType t, int id, bool willNull = false) where T : BaseConfigData, new()
        {
            T tdata = new T();
            Dictionary<string, object> dic;
            if (configData.TryGetValue((byte)t, out dic))
            {
                object o;
                //表类型和ID配置错误
                if (dic.TryGetValue(id.ToString(), out o))
                {
                    tdata.Load(o);
                    return tdata;
                }
            }
            if (!willNull) Debug.LogError(string.Format("EPropertyType: {0} id: {1} 的本地配置表查找不到", t, id));
            return null;
        }
        /// <summary>
        /// 获取指定类型数据的集合 --- 已经加载的表数据应该缓存下来
        /// </summary>
        /// <typeparam name="T">数据对象类型</typeparam>
        /// <param name="t">数据表类型</param>
        /// <returns></returns>
        public Dictionary<string, T> GetDic<T>(ConfigDataType t) where T : BaseConfigData, new()
        {
            Dictionary<string, T> tDic = new Dictionary<string, T>();
            List<T> Tlist = new List<T>();
            Dictionary<string, object> dic;
            if (configData.TryGetValue((byte)t, out dic))
            {
                foreach (var key in dic.Keys)
                {
                    T tdata = new T();
                    tdata.Load(dic[key]);
                    tDic.Add(key, tdata);
                }
            }
            return tDic;
        }

        public void ToUpdate()
        {

        }
        public void Release(object args = null)
        {

        }
    }
}

