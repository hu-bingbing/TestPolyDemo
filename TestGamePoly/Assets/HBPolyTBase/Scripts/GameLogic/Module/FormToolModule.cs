using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using SGF.Utils;
using SGF.Module;

namespace GamePloy.Modules
{
    public class FormToolModule : GeneralModule
    {

        public override void Create(object args = null)
        {
           
        }

        public void SetWork(int effectId, object[] arg = null)
        {
            var tempMethodName = ConfigDataManager.Instance.ConstantDataDic[effectId].Data;
            Debug.Log(tempMethodName);
            SetWork(tempMethodName, arg);
        }

        public void SetWork(string name, object[] args = null)
        {
            var tempMethod = this.GetType().GetMethod(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            Debug.Log(" " + tempMethod);
            if (tempMethod != null)
            {

                tempMethod.Invoke(this, args);

                //var tempMethod = this.GetType().GetMethod(name, BindingFlags.Default);
                //if (tempMethod != null)
                //{
                //    Debug.Log(" " + tempMethod);
                //    var res = tempMethod.Invoke(null, arg);
                //}
            }
        }

        public void WorkOnTechnology(object[] arg = null)
        {
            Debug.Log("--WorkOnTechnology--");

        }

        private void WorkOnArmy(object arg = null)
        {
            Debug.Log("--WorkOnArmy--");

        }

        public  void WorkOnArchitecture(object[] arg = null)
        {
            Debug.Log("--WorkOnArchitecture--");

        }

        public static void WorkOnGoods(object[] arg = null)
        {

        }

        public static void WorkInTerrain()
        {

        }

    }
}

