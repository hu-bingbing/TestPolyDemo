using GamePloyConfigData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePloy.UI
{
    public class ItemSkillTechnology : UIItem
    {
        public Button techBtn;
        public Text contentText;
        public Text normalText;
        public ItemSkillTechnology[] PostItems;

        private ConfigTechnologyData m_thisTechData;
        private int m_thisTechId;
        private string m_showName;

        protected override void OnCreate(object arg = null)
        {
            if(arg != null)
            {
                m_thisTechData = (ConfigTechnologyData)arg;
                m_thisTechId = m_thisTechData.Id;
                techBtn.image.sprite = Resources.Load<Sprite>(m_thisTechData.IconAssetPath);
                m_showName = m_thisTechData.Name;
                contentText.text = m_showName;
                normalText.text = m_showName;
                if(PostItems.Length >0 && m_thisTechData.SonList.Count > 0)
                {
                    for (int i = 0; i < PostItems.Length; i++)
                    {
                        PostItems[i].Create(m_thisTechData.SonList[i]);
                    }
                }
            }
        }

        protected override void OnShow(bool isShow)
        {
            techBtn.gameObject.SetActive(isShow);
        }

        protected override void OnRelease()
        {
           
        }
    }
}

