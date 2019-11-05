using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloyConfigData
{
    public class BaseConfigData
    {
        public void Load(object obj) { OnLoad(obj); }
        protected virtual void OnLoad(object obj) { }

        protected List<string> GetList(string content, char m)
        {
            string[] arr = content.Split(m);
            List<string> list = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                list.Add(arr[i]);
            }
            return list;
        }
        protected List<int> GetIntList(string content, char m = ',')
        {
            string[] arr = content.Split(m);
            List<int> list = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                list.Add(int.Parse(arr[i]));
            }
            return list;
        }
    }
}

