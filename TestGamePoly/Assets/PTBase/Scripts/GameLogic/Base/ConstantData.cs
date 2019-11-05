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
        Land = 0,
        WaterDeep,
        Water,
        WaterLight,
        Ground,
        CropGround,   //沃土
        Forest = 6,   //森林
        Hill = 7,     //高山
        Mine = 8,     //矿山

    }
    /// <summary>
    /// 建筑类型
    /// </summary>
    public enum LandFeatureType
    {

        BornPoint,
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

        public static string TerrianPath = "EntityPrefabs/";

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
