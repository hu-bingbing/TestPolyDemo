using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public class GameBase : MonoBehaviour
    {
        public bool reporterDebug = true;
        public bool isLocal = true;

        void Awake()
        {
            GameCreate();
        }

        private void Start()
        {
            OnAppStart();
        }

        void GameCreate()
        {
            OnPreAppCreate();
            GameMain.start(this);
            OnAppCreate();
        }

        void OnApplicationPause()
        {
            OnAppPause();
        }

        void OnApplicationQuit()
        {
            GameMain.destroy();
            OnAppQuit();
        }

        protected virtual void OnPreAppCreate() { }

        protected virtual void OnAppCreate() { }

        protected virtual void OnAppStart() { }
        protected virtual void OnAppPause() { }

        protected virtual void OnAppQuit() { }
    }
}
