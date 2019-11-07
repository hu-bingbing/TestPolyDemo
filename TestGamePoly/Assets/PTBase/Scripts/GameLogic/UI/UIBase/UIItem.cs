using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIItem : MonoBehaviour
{
    public Button selfBtn;
    public Text contentText;

    public void Create(object arg = null)
    {
        selfBtn.onClick.AddListener(OnClickSelf);
        OnCreate(arg);
    }

    private void OnClickSelf()
    {
        OnClickSelfBtn();
    }

    public void Release()
    {
        selfBtn.onClick.RemoveListener(OnClickSelf);
        OnRelease();
    }

    protected abstract void OnCreate(object arg = null);
    protected abstract void OnClickSelfBtn();
    protected abstract void OnRelease();

}
