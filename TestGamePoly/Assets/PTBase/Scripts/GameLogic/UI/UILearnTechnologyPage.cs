using GamePloy;
using GamePloy.UI;
using SGF.Unity.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILearnTechnologyPage : UIPolyWindow
{
    public ItemSkill[] skillItemArray;
    

    protected override void OnOpen(object arg = null)
    {
        SetUILayer(UILayer.BASE_LAYER, UILayerDef.Page);
        var _templist = TechnologyManager.Instance.TopTechnologyList;
        for(int i = 0; i < skillItemArray.Length; i++)
        {
            var value = _templist[i];
            skillItemArray[i].Create(value);
        }
    }


    protected override void OnClose(object arg = null)
    {
      
    }
}
