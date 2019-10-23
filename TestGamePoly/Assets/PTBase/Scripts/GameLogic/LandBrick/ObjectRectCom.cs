using UnityEngine;
using System.Collections;
using System;

[AddComponentMenu("Battle/Object2D/rect")]
[RequireComponent(typeof(BoxCollider))]
public class ObjectRectCom : ObjectColliderItem
{
    public BoxCollider rect
    {
        get
        {
            if (m_cld == null)
                m_cld = GetComponent<BoxCollider>();
            return m_cld as BoxCollider;
        }
    }

    private Vector2 m_sourceSize;
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

    public override void ResetSize()
    {
        rect.size = m_sourceSize;
        rect.center = Vector3.zero;
    }
    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public override RaycastHit2D[] GetCurrentCast(Vector2 dir, float distance)
    {
        if (!enabled)
        {
            m_len = 0;
            return m_results;
        }
        Vector3 pos = m_trans.position + new Vector3(rect.center.x, rect.center.y, rect.center.z);
        m_len = Physics2D.BoxCastNonAlloc(pos, rect.size, 0, dir, m_results, distance, checkLayer);
        return m_results;
    }
}
