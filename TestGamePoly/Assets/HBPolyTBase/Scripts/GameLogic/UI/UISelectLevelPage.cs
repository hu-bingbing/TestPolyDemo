using GamePloy;
using GamePloy.UI;
using SGF.Module;
using SGF.Unity.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelectLevelPage : UIPolyPage
{
    public Button btnEasy;

    protected override void OnOpen(object arg = null)
    {
        SetUILayer(UILayer.BASE_LAYER, UILayerDef.Page);
        btnEasy.onClick.AddListener(OnClickEasy);
    }

    private void OnClickEasy()
    {
        ModuleManager.Instance.ShowModule(ModuleDef.GameModule);
    }

    protected override void OnClose(object arg = null)
    {
        btnEasy.onClick.RemoveListener(OnClickEasy);
    }
}
