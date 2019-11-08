using GamePloy;
using GamePloy.UI;
using SGF.Unity.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePage : UIPolyPage
{
    public Button btnLearn;
    public ScrollRect selectScroll;
    private List<ItemTechnology> m_btnItemList;

    protected override void OnOpen(object arg = null)
    {
        SetUILayer(UILayer.BASE_LAYER, UILayerDef.Page);
        InitScroll();
        AddUIClickListener(btnLearn.name, OnClickLearn);
        GameManager.Instance.OnClickMapItem += OnClickMapItem;
    }

    void InitScroll()
    {
        SetScroll(true);
        m_btnItemList = new List<ItemTechnology>();
        var _tempArray = FindList<ItemTechnology>();
        foreach(var value in _tempArray)
        {
            value.gameObject.SetActive(false);
            m_btnItemList.Add(value);
        }
        Debug.Log("array: " + _tempArray.Length);
        SetScroll();
    }

    private void OnClickLearn(string obj)
    {
        Debug.Log("OnClcikLearn----");
    }

    private void OnClickMapItem()
    {
        var list = TechnologyManager.Instance.NeedTechnologyList;
        if(list != null && list.Count > 0)
        {
            SetScroll(true);
            for(int i = 0; i < list.Count; i++)
            {
                var _tempCon = list[i];
                if(i < m_btnItemList.Count)
                {
                    m_btnItemList[i].gameObject.SetActive(true);
                    m_btnItemList[i].Create(_tempCon);
                }
                else
                {
                    var tempnewObj = Instantiate(Resources.Load<GameObject>(UIDef.uiTechnologyItem));

                    ObjectUtil.Attach(tempnewObj.transform, selectScroll.content);
                    m_btnItemList.Add(tempnewObj.GetComponent<ItemTechnology>());
                    m_btnItemList[i].Create(_tempCon);
                }
            }
        }
    }

    public void SetScroll(bool isshow = false)
    {
        selectScroll.gameObject.SetActive(isshow);
    }

    protected override void OnClose(object arg = null)
    {
        Debug.Log("closeGamePage----");
        m_btnItemList.Clear();
        RemoveUIClickListener(btnLearn.name, OnClickLearn);
        GameManager.Instance.OnClickMapItem -= OnClickMapItem;
        ModuleManager.Instance.GetModule(ModuleDef.GameModule).Release();
    }

}
