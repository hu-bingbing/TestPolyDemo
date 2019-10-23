using SGF.Unity.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    [RequireComponent(typeof(PinchRecognizer))]
    [RequireComponent(typeof(DragRecognizer))]
    public class GestureManager : MonoSingleton<GestureManager>,IClue
    {
        public int interval
        {
            get { return 1; }
        }

        public void Initialize(object args = null)
        {
    
        }

        public void ToUpdate()
        {
            
        }
    }
}

