using GamePloy;
using GamePloy.UI;
using SGF.Unity.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePage : UIPolyPage
{
    public Button btnLearn;

    protected override void OnOpen(object arg = null)
    {
        SetUILayer(UILayer.BASE_LAYER, UILayerDef.Page);
    }

    protected override void OnClose(object arg = null)
    {
       
    }

}
