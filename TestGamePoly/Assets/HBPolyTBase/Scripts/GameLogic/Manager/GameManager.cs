using SGF.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GamePloy
{
    public class GameManager : Singleton<GameManager>, IClue
    {
        public DeleClickTechBtn OnClickTechBtn;
        public DeleAction OnClickMapItem;
        public DeleAction OnRefreshGameUI;
        public DeleChangeFigure OnChangeGameGold;
        public DeleChangeFigure OnChangeGameScore;
        public DeleChangeFigure OnChangeGameTurn;

        public int interval
        {
            get { return 2; }
        }
      
        private int m_gold;
        /// <summary>
        /// 游戏中金币数
        /// </summary>
        public int GameGold
        {
            get { return m_gold; }
        }

        private int m_score;
        /// <summary>
        /// 分数
        /// </summary>
        public int GameScore
        {
            get { return m_score; }
        }

        private int m_turn;
        /// <summary>
        /// 回合数
        /// </summary>
        public int GameTurn
        {
            get { return m_turn; }
        }

        public void Initialize(object args = null)
        {
            OnChangeGameGold += SetGold;
            OnChangeGameScore += SetScore;
            OnChangeGameTurn += SetTurn;
        }

        public void SetGold(int _gold)
        {
            m_gold += _gold;
            RefreshGameUI();
        }
        public void SetScore(int _score)
        {
            m_score += _score;
            RefreshGameUI();
        }
        public void SetTurn(int _turn)
        {
            m_turn += _turn;
            RefreshGameUI();
        }

        void RefreshGameUI()
        {
            if(OnRefreshGameUI != null)
            {
                OnRefreshGameUI();
            }
        }

        public void ClickGameMapItem(BaseLandItem _item)
        {
            Debug.Log("---clickMapItem:" + _item.name);
            TechnologyManager.Instance.SetNeedTechnology(106);
            if(OnClickMapItem != null)
            {
                OnClickMapItem();
            }
        }

        public void ToUpdate()
        {
            
        }

        public void Release(object args = null)
        {

        }


    }
}

