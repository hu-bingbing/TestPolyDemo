using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public class EntityRoot : MonoBehaviour
    {
        public static Transform Find(string rootName,string findRootName)
        {
            GameObject root = GameObject.Find(rootName);
            Transform _getRoot = null;
            _getRoot = UtilityTool.GetChild(root, findRootName, true).transform;
            return _getRoot;
        }
    }
}

