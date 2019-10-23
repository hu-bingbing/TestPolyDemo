using UnityEngine;
using System.Collections;
using GamePloy;

public abstract class ObjectColliderItem : ObjectItem
{
    protected Collider2D m_cld;
    public Collider2D cld
    {
        get
        {
            if (m_cld == null)
                m_cld = GetComponent<Collider2D>();
            return m_cld;
        }
    }
    protected RaycastHit2D[] m_results;
    protected Transform m_trans;

    void Awake()
    {
        m_results = new RaycastHit2D[BattleConst.maxCollection];
        m_trans = transform;
        OnInit();
    }

    protected abstract void OnInit();

    public abstract RaycastHit2D[] GetCurrentCast(Vector2 dir, float distance);
}
