using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public abstract class BaseBuildingItem : BaseBrickItem
    {

        #region 外部调用

        public void CreateBuildingFeature()
        {


            OnCreateBuildingFeature();
        }



        #endregion
        /// <summary>
        /// 创建地图建筑
        /// </summary>
        protected abstract void OnCreateBuildingFeature();
    }
}

