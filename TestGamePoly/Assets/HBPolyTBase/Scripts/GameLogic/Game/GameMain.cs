using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public class GameMain
    {
        private static int m_runFrame = 0;

        public static int runFrame
        {
            get { return m_runFrame; }
        }

        private static MonoBehaviour m_gameBase;

        public static MonoBehaviour GameBase
        {
            get { return m_gameBase; }
        }

        private static List<IClue> processList = new List<IClue>();
        private static List<IClue> addList = new List<IClue>();
        private static List<IClue> removeList = new List<IClue>();
        private static Dictionary<IClue, int> processFrameDic = new Dictionary<IClue, int>();

        public static void start(MonoBehaviour root)
        {
            if(m_gameBase != null)
            {
                return;
            }
            m_gameBase = root;
            m_gameBase.gameObject.AddComponent<UpdateBehaviour>();
        }

        public static void destroy()
        {

        }


        /// <summary>
        /// 添加到主循环
        /// </summary>
        /// <param name="item"></param>
        public static void AddProcess(IClue item)
        {
            if (!processFrameDic.ContainsKey(item))
            {
                addList.Add(item);
                processFrameDic.Add(item, m_runFrame);
                Debug.LogFormat("添加IUpdate: {0},当前队列数量 {1}", item, processFrameDic.Count);
            }
        }

        /// <summary>
        /// 从主循环移除
        /// </summary>
        /// <param name="item"></param>
        public static void RemoveProcess(IClue item)
        {
            if (processFrameDic.ContainsKey(item))
            {
                processFrameDic.Remove(item);
                removeList.Add(item);
                Debug.LogFormat("移除IUpdate: {0},当前队列数量 {1}", item, processFrameDic.Count);
            }
        }

        public static int processNum
        {
            get { return processFrameDic.Count; }
        }

        public static void update()
        {
            m_runFrame++;
            int len = removeList.Count;
            for (int i = 0; i < len; ++i)
            {
                processList.Remove(removeList[i]);
            }
            removeList.Clear();

            len = addList.Count;
            for (int i = 0; i < len; ++i)
            {
                processList.Add(addList[i]);
            }
            addList.Clear();

            len = processList.Count;
            for (int i = 0; i < len; ++i)
            {
                IClue item = processList[i];
                try
                {
                    if (processFrameDic.ContainsKey(item))
                    {
                        int lastFrame = m_runFrame - processFrameDic[item];
                        if (lastFrame % item.interval == 0)
                        {
                            item.ToUpdate();
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    continue;
                }
            }
        }

        public class UpdateBehaviour : MonoBehaviour
        {
            void LateUpdate()
            {
                GameMain.update();
            }
        }
    }
}

