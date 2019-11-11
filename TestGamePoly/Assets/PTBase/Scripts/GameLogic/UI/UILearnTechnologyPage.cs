using GamePloy;
using GamePloy.UI;
using GamePloyConfigData;
using SGF.Unity.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILearnTechnologyPage : UIPolyWindow
{
    public ItemSkill[] skillItemArray;
    

    protected override void OnOpen(object arg = null)
    {
        SetUILayer(UILayer.BASE_LAYER, UILayerDef.Page);
        RefreshTech();
        LevelManager.Instance.SetClickBolck(false);
        TechnologyManager.Instance.OnRefreshTech += OnRefeshTechnology;
    }

    private void OnRefeshTechnology(ConfigTechnologyData techData)
    {
        RefreshTech();
    }

    void RefreshTech()
    {
        var _templist = TechnologyManager.Instance.TopTechnologyList;
        for (int i = 0; i < skillItemArray.Length; i++)
        {
            var value = _templist[i];
            skillItemArray[i].Create(value);
        }
    }

    protected override void OnClose(object arg = null)
    {
        LevelManager.Instance.SetClickBolck(true);
        TechnologyManager.Instance.OnRefreshTech -= OnRefeshTechnology;
    }
}
