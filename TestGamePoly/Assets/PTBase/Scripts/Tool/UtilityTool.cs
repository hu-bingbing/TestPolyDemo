using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class UtilityTool
{

    public static GameObject GetChild(GameObject go, string name, bool includeSelf = false)
    {
        if ((go != null) && !string.IsNullOrEmpty(name))
        {
            if (includeSelf && (go.name == name))
            {
                return go;
            }

            Transform transform = go.transform;
            Transform transform2 = null;
            if (name.IndexOf('/') != -1)
            {
                var arr = name.Split('/').ToList();
                if (arr.Count > 0)
                {
                    var ch = GetChild(go, arr[0], includeSelf);
                    arr.RemoveAt(0);
                    return GetChild(ch, string.Join("/", arr.ToArray()), includeSelf);
                }
                return null;
            }
            transform2 = transform.Find(name);
            if (transform2 != null)
            {
                return transform2.gameObject;
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject obj = GetChild(transform.GetChild(i).gameObject, name, false);
                if (obj != null)
                {
                    return obj;
                }
            }
        }
        return null;
    }


}

public class ObjFindTool
{
    public static ObjFindTool Create(GameObject obj)
    {
        return new ObjFindTool(obj);
    }

    private Dictionary<string, GameObject> objectDic = new Dictionary<string, GameObject>();

    public ObjFindTool(GameObject obj)
    {
        ResetObj(obj);
    }

    public void ResetObj(GameObject obj)
    {
        Transform[] trs = obj.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < trs.Length; i++)
        {
            Transform item = trs[i];
            objectDic[item.name.ToLower()] = item.gameObject;
        }

        string sn = obj.name.ToLower();
        if (sn.Contains("(clone)"))
            sn.Replace("(clone)", "");
        objectDic[sn] = obj;
    }

    public bool HasObject(string objName)
    {
        if (string.IsNullOrEmpty(objName))
            return false;
        objName = objName.ToLower();
        return objectDic.ContainsKey(objName);
    }

    public GameObject GetObject(string objName)
    {
        if (string.IsNullOrEmpty(objName))
            return null;

        objName = objName.ToLower();
        GameObject obj = null;
        objectDic.TryGetValue(objName, out obj);
        return obj;
    }
     
    public T GetChildComponent<T>(string objName) where T : Component
    {
        if (string.IsNullOrEmpty(objName))
            return null;

        GameObject cobj = GetObject(objName);
        if (cobj == null)
            return null;

        return cobj.GetComponent<T>();
    }


}
