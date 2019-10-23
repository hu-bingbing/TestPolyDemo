using UnityEngine;
using System.Collections;

namespace GamePloy
{
    public class ObjectUtil
    {
        /// <summary>
        /// 更改object以及下属的所有子项的层级
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="newLayer"></param>
        public static void ChangeLayerAll(GameObject obj, int newLayer)
        {
            if (newLayer < 0)
                return;
            obj.layer = newLayer;
            Transform[] trs = obj.GetComponentsInChildren<Transform>(true);
            if (trs.Length > 0)
            {
                for (int i = 0; i < trs.Length; i++)
                {
                    trs[i].gameObject.layer = newLayer;
                }
            }
        }

        public static void Attach(Transform child,Transform parent)
        {
            child.SetParent(parent, false);
            child.localPosition = Vector3.zero;
            child.localScale = Vector3.one;
            child.localRotation = Quaternion.identity;
        }

        public static void Detatch(Transform child, Transform parent)
        {
            GameObject.DestroyImmediate(child.gameObject);
        }
    }
}