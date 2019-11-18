using SGF.Module;
using SGF.Unity.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy.Modules
{
    public class LoginModule: GeneralModule
    {
        public override void Create(object args = null)
        {
            Debug.Log("CreateLoginModule-----" + args);
            
        }

        protected override void Show(object arg)
        {
            UIManager.Instance.OpenPage(UIDef.UILogin);
        }

        public void OnClickLogin()
        {

        }

    }
}

