using SGF.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GamePloy
{
    public class GameManager : Singleton<GameManager>, IClue
    {
        public Action OnClickMapItem;

        public int interval
        {
            get { return 2; }
        }

        public void Initialize(object args = null)
        {
            
        }

        public void ClickGameMapItem(BaseLandItem _item)
        {
            TechnologyManager.Instance.SetNeedTechnology(106);
            if(OnClickMapItem != null)
            {
                OnClickMapItem();
            }
        }

        public void ToUpdate()
        {
            
        }

    
    }
}

