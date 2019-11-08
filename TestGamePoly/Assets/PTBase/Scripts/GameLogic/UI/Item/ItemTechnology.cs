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
        ConfigTechnologyData thisTechnologyData;

        protected override void OnCreate(object arg = null)
        {
            if (arg != null)
            {
                thisTechnologyData = (ConfigTechnologyData)arg;
            }
            selfBtn.onClick.AddListener(OnClickSelf);
            selfBtn.image.sprite = Resources.Load<Sprite>(thisTechnologyData.IconAssetPath);
            contentText.text = thisTechnologyData.Id.ToString();
        }

        protected void OnClickSelf()
        {

        }

        protected override void OnRelease()
        {
            selfBtn.onClick.RemoveListener(OnClickSelf);
        }
    }
}

