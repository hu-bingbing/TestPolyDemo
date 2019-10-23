using UnityEngine;
using System.Collections;

public abstract class ObjectItem : ElemItem
{
    public PhysicCollisionType cldType = PhysicCollisionType.NONE;

    /// <summary>
    /// 是否自律的(不主动与其他物体发生碰撞,并且被碰撞后,不修改自身任何物理属性)
    /// </summary>
    public bool autonomy = false;

    public bool useGravity = true;

    public float gravityRate = 1f;

    public bool useWind = false;

    public float mass = 1f;

    [System.NonSerialized]
    public int checkLayer = 0;

    protected int m_len = 0;
    public int castLen
    {
        get { return m_len; }
    }

    public abstract void ResetSize();
}

public enum PhysicCollisionType
{
    NONE = 0,//无物理效果
    UNLIMIT = 1,//完全弹性
    NORMAL = 2,//弹性
    CUSTOM_MULTI = 3,//自定义
}