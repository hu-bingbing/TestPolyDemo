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
        BornPoint = 0,   //初始台地



        None,
    }

    public enum ArmyType
    {
        OneSoldier = 0,
        Warrior = 1,           //勇士
        ShieldMan = 2,         //盾士
        SwordsMan = 3,         //剑士
        EliteSoldier = 4,      //精英战士
        Archer = 5,            //弓箭手
        QuickScout = 6,        //迅捷斥候
        knight = 7,            //骑士
        Attacker = 8,          //攻击
        Priests = 9,           //祭司
        Boat = 10,             //小船
        MediumShip = 11,       //中船
        GunBoat = 12,          //炮船
        StoneCatapult = 13,    //投石机

    }


    public static class UIDef
    {
        public static string UILogin = "Page/UILoginPage";
        public static string UISelectLevel = "Page/UISelectLevel";
        public static string UIGame = "Page/UIGamePage";

        #region uiitem

        public static string uiTechnologyItem = "UI/Page/Item/uiTechnologyItem";
        public static string uiSkillItem = "UI/Page/Item/uiSkillItem";


        #endregion

        public static string TechnologyIconPath = "Icon/";
        /// <summary>
        /// 地形路径
        /// </summary>
        public static string TerrianPath = "EntityPrefabs/";
        /// <summary>
        /// 建筑路径
        /// </summary>
        public static string ArchitecturePrefabsPath = "Buildings/";
        /// <summary>
        /// 士兵预制路径
        /// </summary>
        public static string ArmyPrefabsPath = "ArmPrefabs/";

    }

    public static class ModuleDef
    {
        public const string NameSpace = "GamePloy.Modules";
        public const string NativeAssemblyName = "GamePoly";

        public const string LoginModule = "LoginModule";
        public const string GameModule = "GameModule";
        public const string ConfigConstantMethodModule = "ConfigConstantMethodModule";

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
        TechnologyData,

    }
}
