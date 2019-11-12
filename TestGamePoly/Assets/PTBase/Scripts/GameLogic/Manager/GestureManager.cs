using SGF.Unity.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    [RequireComponent(typeof(PinchRecognizer))]
    [RequireComponent(typeof(DragRecognizer))]
    [RequireComponent(typeof(TapRecognizer))]
    public class GestureManager : MonoSingleton<GestureManager>,IClue
    {
        public int interval
        {
            get { return 1; }
        }
        bool m_isGesture;
        public bool IsGesture
        {
            get { return m_isGesture; }
        }

        public DeleGestureTap OnGestureTap;

        public void Initialize(object args = null)
        {
            this.transform.GetComponent<TapRecognizer>().OnGesture += OnTap;
            SetGesture(true);
       
        }

        private void OnTap(TapGesture gesture)
        {
            if (m_isGesture)
            {
                if (OnGestureTap != null)
                {
                    OnGestureTap(gesture);
                }
            }

        }

        /// <summary>
        /// 设置gesture是否打开
        /// </summary>
        /// <param name="_ison"></param>
        public void SetGesture(bool _ison)
        {
            m_isGesture = _ison;
        }

        public void ToUpdate()
        {
            
        }

        public void Release(object args = null)
        {
            this.transform.GetComponent<TapRecognizer>().OnGesture -= OnTap;
        }
    }
}

