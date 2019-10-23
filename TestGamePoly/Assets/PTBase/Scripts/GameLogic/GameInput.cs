using SGF.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public class GameInput : Singleton<GameInput>
    {
        public static Action<int, float, float> onVKey;
        
        void Update()
        {
            HandleKey(KeyCode.A, OperationDef.MoveX, -1, 0);
            HandleKey(KeyCode.D, OperationDef.MoveX, 1, 0);
            HandleKey(KeyCode.W, OperationDef.MoveY, 1, 0);
            HandleKey(KeyCode.S, OperationDef.MoveY, -1, 0);
            //HandleKey(KeyCode.L, GameVKey.StartLevel, 1, 37);
            HandleClick();
        }


        private void HandleVKey(int vkey, float arg1, float arg2)
        {
            if (onVKey != null)
            {
                onVKey(vkey, arg1, arg2);
            }
        }

        private void HandleKey(KeyCode key, int vkey, float arg1, float arg2)
        {
            if (Input.GetKeyDown(key))
            {
                HandleVKey(vkey, arg1, arg2);
            }
        }

        private void HandleClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleVKey(OperationDef.Tap, Input.mousePosition.x, Input.mousePosition.y);
            }
        }

        public void HandleGesture(Vector2 dir)
        {
            if (dir.x != 0 /*&& !GameManager.Instance.stopReceive && !GameManager.Instance.inBattleMode*/)
            {
                HandleVKey(OperationDef.MoveX, dir.x, 0);
            }
            else if (dir.y != 0 /*&& /*!GameManager.Instance.stopReceive && !GameManager.Instance.inBattleMode*/)
            {
                HandleVKey(OperationDef.MoveY, dir.y, 0);
            }
        }
    }
}
