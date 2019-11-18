using GamePloyConfigData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy.UI
{
    public class ItemSkill : UIItem
    {
        public ItemSkillTechnology firstItem;
        private int m_skillId;
        private ConfigTechnologyData thisTopData;

        protected override void OnCreate(object arg = null)
        {
            if(arg != null)
            {
                thisTopData = (ConfigTechnologyData)arg;
                m_skillId = thisTopData.Id;
                firstItem.Create(thisTopData);
            }
        }

        public void SetSkillId(int _id)
        {
            m_skillId = _id;
        }

        protected override void OnShow(bool isShow)
        {
           
        }
        
        protected override void OnRelease()
        {
            
        }
    }
}

