using UnityEngine;
using System.Collections;
using GamePloy;

public abstract class TriggerColliderItem : TriggerItem
{
    Collider m_cld;

    public Collider cld
    {
        get
        {
            if (m_cld == null)
                m_cld = GetComponent<Collider>();
            return m_cld;
        }
    }

    protected Collider2D[] m_results;
    protected Transform m_trans;
    void Awake()
    {
        m_results = new Collider2D[BattleConst.maxCollection];
        m_trans = transform;
        //cld.enabled = false;
        OnInit();
    }

    protected abstract void OnInit();
}
