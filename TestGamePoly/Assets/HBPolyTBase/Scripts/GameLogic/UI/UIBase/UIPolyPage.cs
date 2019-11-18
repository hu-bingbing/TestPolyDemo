using SGF.Unity.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy.UI
{
    public class UIPolyPage : UIPage
    {
        protected override void OnAwake()
        {
          
        }

        protected override void OnClose(object arg = null)
        {
            base.OnClose(arg);
        }

        public void SetUILayer(UILayer layer,int layerDef)
        {
            UIMgr.Instance.SetUILayer(this.transform, layer);
            Layer = layerDef;
        }
    }
}

