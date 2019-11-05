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

        public static Dictionary<LandSurfaceType, string> LandItemPathByTypeDic = new Dictionary<LandSurfaceType, string>()
        {
              {LandSurfaceType.Ground,LandEntityPath.GrandItemPath},
              {LandSurfaceType.Water,LandEntityPath.WaterItemPath},
              {LandSurfaceType.WaterLight,LandEntityPath.WaterLightItemPath},
              {LandSurfaceType.WaterDeep,LandEntityPath.WaterDeepItemPath},


        };

        public static Dictionary<LandFeatureType, string> LandFeaturePathDic = new Dictionary<LandFeatureType, string>()
        {
              {LandFeatureType.BornPoint,BuildingDef.BornArchitecture01},
             


        };



        #region UIDef

        public static string UICamera = "UICamera";
        public static string UIBaseLayer = "BaseLayer";
        public static string UIWindowLayer = "WindowLayer";
        public static string UIModelLayer = "ModelLayer";
        public static string UITopLayer = "TopLayer";


        #endregion
    }
    /// <summary>
    /// 地表类型
    /// </summary>
    public enum LandSurfaceType
    {
        Ground,
        Water,
        WaterLight,
        WaterDeep,

    }
    /// <summary>
    /// 建筑类型
    /// </summary>
    public enum LandFeatureType
    {

        BornPoint,
    }

    public class LandEntityPath
    {
        /// <summary>
        /// 平地
        /// </summary>
        public static string LandItemPath = "EntityPrefabs/LandItem";
        
        /// <summary>
        /// 草地
        /// </summary>
        public static string GrandItemPath = "EntityPrefabs/GrandItem";
        /// <summary>
        /// 森林
        /// </summary>
        public static string ForestItemPath = "EntityPrefabs/ForestItem";
        /// <summary>
        /// 小山
        /// </summary>
        public static string HillItemPath = "EntityPrefabs/HillItem06";

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
        public static string BornArchitecture01 = "Buildings/MidPoint";
       
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
    
    public static class OperationDef
    {
        public const int MoveX = 11;
        public const int MoveY = 12;
        public const int Tap = 20;
    }

    public enum ConfigDataType
    {
        ArchitectureData,
        CityData,
        ConstantData,
        GoodsData,
        TerrainData,

    }
}
