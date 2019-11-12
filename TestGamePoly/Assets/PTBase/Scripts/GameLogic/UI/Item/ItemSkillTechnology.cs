using GamePloyConfigData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePloy.UI
{
    public class ItemSkillTechnology : UIItem
    {
        public Button techBtn;
        public Image btnShowImg;
        public Text contentText;
        public Text normalText;
        public ItemSkillTechnology[] PostItems;

        private ConfigTechnologyData m_thisTechData;
        private int m_thisTechId;
        private int m_costGold;
        private string m_showName;

        protected override void OnCreate(object arg = null)
        {
            if(arg != null)
            {
                m_thisTechData = (ConfigTechnologyData)arg;
                m_thisTechId = m_thisTechData.Id;
                m_costGold = m_thisTechData.OriginalCost;
                btnShowImg.sprite = Resources.Load<Sprite>(m_thisTechData.IconAssetPath);
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
                else if (PostItems.Length > 0 && m_thisTechData.SonList.Count <= 0)
                {
                    for(int i = 0; i < PostItems.Length; i++)
                    {
                        PostItems[i].gameObject.SetActive(false);
                    }
                }

                if (TechnologyManager.Instance.OwnTechList.Contains(m_thisTechData))
                {
                    Debug.LogWarning("Contain--" + m_thisTechId);
                    btnShowImg.gameObject.SetActive(true);
                }
                else
                {
                    btnShowImg.gameObject.SetActive(false);
                }
            }
            techBtn.onClick.AddListener(OnClickTech);
        }

        private void OnClickTech()
        {
            Debug.Log("onclickTech:" + m_showName);
            string _content = "解锁: " + m_showName + " 需要消耗" + m_costGold + "个金币";
            UIManager.Instance.OpenTipWindow("科技提示", _content, "确定|取消", OnClickTipBtn);
        }

        private void OnClickTipBtn(object arg)
        {
            if((int)arg == 1)
            {
                if(GameManager.Instance.GameGold < m_costGold)
                {
                    Debug.Log("-----金币不够---");
                    UIManager.Instance.OpenTipWindow("提示", "金币不够", "");
                }
                else
                {
                    GameManager.Instance.OnChangeGameGold(-m_costGold);
                    TechnologyManager.Instance.AddToTechnologyDic(m_thisTechData);
                }
            }
            else if((int)arg == 2)
            {

            }

        }

        protected override void OnShow(bool isShow)
        {
            techBtn.gameObject.SetActive(isShow);
            Debug.Log("---techshow:--");
        }

        protected override void OnRelease()
        {
            techBtn.onClick.RemoveListener(OnClickTech);
        }
    }
}

