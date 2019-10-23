using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public class ConstantData
    {

        public static string EntityRoot = "EntityRoot";
        public static string LandRoot = "LandRoot";
        public static string CameraRoot = "EntityCameraRoot";

        public static Dictionary<LandType, string> LandItemPathByTypeDic = new Dictionary<LandType, string>()
        {
              {LandType.Ground,LandEntityPath.GrandItemPath},
              {LandType.Water,LandEntityPath.WaterItemPath},
              {LandType.WaterLight,LandEntityPath.WaterLightItemPath},
              {LandType.WaterDeep,LandEntityPath.WaterDeepItemPath},


        };




        #region UIDef

        public static string UICamera = "UICamera";
        public static string UIBaseLayer = "BaseLayer";
        public static string UIWindowLayer = "WindowLayer";
        public static string UIModelLayer = "ModelLayer";
        public static string UITopLayer = "TopLayer";


        #endregion
    }

    public enum LandType
    {
        Ground,
        Water,
        WaterLight,
        WaterDeep,

    }

    public class LandEntityPath
    {
        public static string LandItemPath = "EntityPrefabs/LandItem";
        /// <summary>
        /// 平地
        /// </summary>
        public static string GrandItemPath = "EntityPrefabs/GrandItem";
        /// <summary>
        /// 浅水
        /// </summary>
        public static string WaterLightItemPath = "EntityPrefabs/WaterLightItem";
        /// <summary>
        /// 一般的海
        /// </summary>
        public static string WaterItemPath = "EntityPrefabs/WaterItem";
        /// <summary>
        /// 深海
        /// </summary>
        public static string WaterDeepItemPath = "EntityPrefabs/WaterDeepItem";


    }

    public static class BuildingDef
    {
        public static string BornArchitecture01 = "Buildings/BornPos";
       
    }

    public static class UIDef
    {
        public static string UILogin = "Page/UILoginPage";
        public static string UISelectLevel = "Page/UISelectLevel";
        public static string UIGame = "Page/UIGamePage";

    }

    public static class ModuleDef
    {
        public const string NameSpace = "GamePloy.Modules";
        public const string NativeAssemblyName = "GamePoly";

        public const string LoginModule = "LoginModule";
        public const string GameModule = "GameModule";

        public const string SettingModule = "SettingModule";
        public const string ActivityModule = "ActivityModule";
        public const string DailyCheckInModule = "DailyCheckInModule";
        public const string ShopModule = "ShopModule";
        public const string ShareModule = "ShareModule";
        public const string PVEModule = "PVEModule";
        public const string PVPModule = "PVPModule";
        public const string HostModule = "HostModule";
    }
}
