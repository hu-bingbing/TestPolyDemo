using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    /// <summary>
    /// 地表砖块
    /// </summary>
    public class LandSurfaceItem : BaseLandItem
    {
        protected override void OnCreateLandSurface()
        {
            this.gameObject.name = "x:" + m_landData.Index_X + "y:" + m_landData.Index_Y + " z:" + m_landData.Index_Z;
            if(m_landData.Index_X == 0 || m_landData.Index_Y == 0|| m_landData.Index_Z == 0)
            {
                //modelPoint.localPosition = new Vector3(0, 2, 0);
            }
        }

        protected override void OnCreateBuilding(object args = null)
        {
            GameObject _objBuilding = Instantiate(Resources.Load<GameObject>(args.ToString()));
            ObjectUtil.Attach(_objBuilding.transform, modelPoint);
        }

        protected override void OnRelease()
        {
           
        }
    }
}

