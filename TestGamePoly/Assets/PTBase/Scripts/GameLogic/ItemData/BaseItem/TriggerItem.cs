using UnityEngine;
using System.Collections;
using System;

[DisallowMultipleComponent]
public abstract class TriggerItem : MonoBehaviour
{
    public int index = 0;
    [NonSerialized]
    public int checkLayer = 0;
    [NonSerialized]
    public ElemItem host;

    public TriggerType type = TriggerType.PASSIVITY;

    public bool isOn = true;

    protected int m_len = 0;
    public int triggerLen
    {
        get
        {
            return m_len;
        }
    }

    public abstract void ResetSize();

    public abstract IList GetCurrentTrigger();
}

public enum TriggerType
{
    INITIATIVE,
    PASSIVITY,
}