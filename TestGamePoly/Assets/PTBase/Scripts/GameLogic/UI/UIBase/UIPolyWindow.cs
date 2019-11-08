using SGF.Unity.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy.UI
{
    public class UIPolyWindow : UIWindow
    {

        public void SetUILayer(UILayer layer, int layerDef)
        {
            UIMgr.Instance.SetUILayer(this.transform, layer);
            Layer = layerDef;
        }
    }
}

