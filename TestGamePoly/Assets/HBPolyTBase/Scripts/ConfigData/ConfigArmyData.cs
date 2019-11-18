using GamePloy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloyConfigData
{
    public class ConfigArmyData : BaseConfigData
    {
        public int Id;
        public string Name;
        private string m_assetName;
        public string AssetPath;
        private int m_armyType;
        public ArmyType ArmyType;
        /// <summary>
        /// 生命
        /// </summary>
        public int HP;
        /// <summary>
        /// 攻击
        /// </summary>
        public int AttackNum;
        /// <summary>
        /// 防御
        /// </summary>
        public int DefenseNum;
        /// <summary>
        /// 攻击距离
        /// </summary>
        public int AttackDistance;
        /// <summary>
        /// 移动力
        /// </summary>
        public int Mobility;

        protected override void OnLoad(object obj)
        {
            Dictionary<string, object> dic = obj as Dictionary<string, object>;
            Id = int.Parse(dic["id"].ToString());
            Name = dic["name"].ToString();
            m_assetName = dic["assetName"].ToString();
            AssetPath = UIDef.ArmyPrefabsPath + m_assetName;
            HP = int.Parse(dic["hp"].ToString());
            AttackNum = int.Parse(dic["attackNum"].ToString());
            DefenseNum = int.Parse(dic["defenseNum"].ToString());
            AttackDistance = int.Parse(dic["attackDistance"].ToString());
            Mobility = int.Parse(dic["mobility"].ToString());
        }
    }
}

