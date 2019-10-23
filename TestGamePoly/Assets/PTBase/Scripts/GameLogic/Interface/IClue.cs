using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public interface IClue
    {
        /// <summary>
        /// 更新间隔
        /// </summary>
        int interval { get; }
        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize(object args = null);

        /// <summary>
        /// 规定间隔下update更新
        /// </summary>
        void ToUpdate();
    }
}

