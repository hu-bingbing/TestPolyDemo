using GamePloyConfigData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePloy.UI
{
    public class ItemTechnology : UIItem
    {
        public Button selfBtn;
        public Text contentText;
        public Text normalText;
        ConfigTechnologyData thisTechnologyData;

        protected override void OnCreate(object arg = null)
        {
            if (arg != null)
            {
                thisTechnologyData = (ConfigTechnologyData)arg;
            }
            var tempEffectId = TechnologyManager.Instance.TechEffectId;
           // FormTool.Instance.SetWork(tempEffectId);
            selfBtn.onClick.AddListener(OnClickSelf);
            selfBtn.image.sprite = Resources.Load<Sprite>(thisTechnologyData.IconAssetPath);


            string _showname = thisTechnologyData.TechnologyName + " id:" + thisTechnologyData.Id.ToString();
            contentText.text = _showname;
            normalText.text = _showname;
        }

        protected void OnClickSelf()
        {
            if(GameManager.Instance.OnClickTechBtn != null)
            {
                GameManager.Instance.OnClickTechBtn(thisTechnologyData);
            }

        }

        protected override void OnShow(bool isShow)
        {
           
        }

        protected override void OnRelease()
        {
            selfBtn.onClick.RemoveListener(OnClickSelf);
        }
    }
}

