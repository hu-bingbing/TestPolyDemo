using UnityEngine;
using System.Collections;
using System;

[AddComponentMenu("Battle/Trigger2D/Rect")]
[RequireComponent(typeof(BoxCollider2D))]
public class TriggerRectCom : TriggerColliderItem
{
    public BoxCollider2D rect
    {
        get
        {
            return cld as BoxCollider2D;
        }
    }

    private Vector2 m_sourceSize = Vector2.zero;
    public Vector2 sourceSize
    {
        get
        {
            return m_sourceSize;
        }
    }

    protected override void OnInit()
    {
        m_sourceSize = rect.size;
    }

    public override IList GetCurrentTrigger()
    {
        if (!enabled)
            m_len = 0;
        else
        {
            Bounds bds = rect.bounds;

            m_len = Physics2D.OverlapAreaNonAlloc(bds.min, bds.max, m_results, checkLayer);
        }
        return m_results;
    }

    public override void ResetSize()
    {
        rect.offset = Vector2.zero;
        rect.size = m_sourceSize;
    }
}
