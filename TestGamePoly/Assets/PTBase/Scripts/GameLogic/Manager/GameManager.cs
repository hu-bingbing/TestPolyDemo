using SGF.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GamePloy
{
    public class GameManager : Singleton<GameManager>, IClue
    {
        public int interval
        {
            get { return 2; }
        }

        public void Initialize(object args = null)
        {
            
        }

        public void ToUpdate()
        {
            
        }
    }
}

