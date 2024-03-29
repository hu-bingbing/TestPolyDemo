﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePloy.UI
{
    public abstract class UIItem : MonoBehaviour
    {
       
        public void Create(object arg = null)
        {
            OnCreate(arg);
        }
        
        public void Show(bool isShow)
        {

        }

        public void Release()
        {
            OnRelease();
        }

        protected abstract void OnCreate(object arg = null);
        protected abstract void OnShow(bool isShow);
        protected abstract void OnRelease();

    }
}

