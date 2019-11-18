using UnityEngine;
using System.Collections;

namespace GamePloy
{
    public class BattleConst
    {
        public static int maxCollection = 500;

        public static float gravity = 0.015f;

        public static float maxDownSpeed = 1f;

        public static float maxWindSpeed = 0.1999f;

        public static float windPower = 0.02f;

        public static float g = 9.8f;
    }

    public enum BattleStatus
    {
        NOT_READY,
        INITIALIZED,//初始化完毕
        HALF_IN,//中途加入或断线重连
        WAIT,//等待累积帧
        RUNNING,//运行中
        ACCELERATE,//加速
        RESULT,//结算中
        ERROR,//错误
    }

    public class BattleSetting
    {
        public int waitStepCheck = 300;
        /// <summary>
        /// 服务器每次发送帧数
        /// </summary>
        public int serverFramePer = 1;
        /// <summary>
        /// 缓存帧数量,抗延迟
        /// </summary>
        public int waitFrameMax = 10;
    }
}