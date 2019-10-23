using GamePloy;
using GamePloy.UI;
using SGF.Unity.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILoginPage : UIPolyPage
{
    public Button btnLogin;
    
    protected override void OnOpen(object arg = null)
    {
        btnLogin.onClick.AddListener(OnClickLogin);
        SetUILayer(UILayer.BASE_LAYER, UILayerDef.Page);
    }

    private void OnClickLogin()
    {
        UIManager.Instance.OpenPage(UIDef.UISelectLevel);
    }

    protected override void OnClose(object arg = null)
    {
        Debug.Log("---closeLogin--");
        btnLogin.onClick.RemoveListener(OnClickLogin);

    }
}
