using GamePloyConfigData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemGamePageTechnology :UIItem
{
    ConfigTechnologyData thisTechnologyData;

    protected override void OnCreate(object arg = null)
    {
        if(arg != null)
        {
            thisTechnologyData = (ConfigTechnologyData)arg;
        }
        selfBtn.image.sprite = Resources.Load<Sprite>(thisTechnologyData.IconAssetPath);
        contentText.text = thisTechnologyData.Id.ToString();
    }

    protected override void OnClickSelfBtn()
    {
      
    }

    protected override void OnRelease()
    {
     
    }
}
