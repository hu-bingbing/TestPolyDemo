using SGF.Module;
using SGF.Unity.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy.Modules
{
    public class GameModule : GeneralModule
    {
        public override void Create(object args = null)
        {
          
        }

        protected override void Show(object arg)
        {
            LevelManager.Instance.LoadLevelEntity(LevelType.EASY);
            UIManager.Instance.OpenPage(UIDef.UIGame);
        }
        
    }
}

