using UnityEngine;
using System.Collections;

public abstract class ElemItem : MonoBehaviour
{
    public Transform modelPoint;
}

public enum ElemLayer
{
    Default = 0,
    Player = 20,
    Nature = 21,
    Creature = 22,
    Trigger = 23,
    Item = 24,
    Nonlife = 25,
    Spell = 26,
    Pet = 27,
}