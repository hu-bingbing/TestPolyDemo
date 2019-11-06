using SGF;
using SGF.Module;
using SGF.Unity.UI;
using SGF.Unity.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy
{
    public class GameEntry : GameBase
    {
        public static GameEntry m_instance = null;
        public static GameEntry Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = FindObjectOfType<GameEntry>();
                return m_instance;
            }
        }

        [SerializeField]
        private Reporter reporter;

        protected override void OnPreAppCreate()
        {
            reporter.gameObject.SetActive(reporterDebug);
            Application.runInBackground = true;
            Application.targetFrameRate = 30;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            GameManager.Instance.Initialize();
            ConfigDataManager.Instance.Initialize();
            LevelManager.Instance.Initialize();
            GestureManager.Instance.Initialize();
            UIManager.Instance.Initialize("UI/");
            ModuleManager.Instance.Initialize();

        }

        protected override void OnAppCreate()
        {
            GameMain.AddProcess(GameManager.Instance);
            GameMain.AddProcess(LevelManager.Instance);
        }

        protected override void OnAppStart()
        {
            InitServices();
            InitBusiness();
            ModuleManager.Instance.ShowModule(ModuleDef.LoginModule);
        }

        private void InitServices()
        {
            Debuger.Log("---initServices----");
            NetUtils.CheckSelfIPAddress();
            
            ModuleManager.Instance.RegisterModuleActivator(new NativeModuleActivator(ModuleDef.NameSpace, ModuleDef.NativeAssemblyName));

        }

        private void InitBusiness()
        {
            ModuleManager.Instance.CreateModule(ModuleDef.LoginModule);
            ModuleManager.Instance.CreateModule(ModuleDef.GameModule);
            ModuleManager.Instance.CreateModule(ModuleDef.ConfigConstantMethodModule);

        }

        protected override void OnAppPause()
        {
          
        }

        protected override void OnAppQuit()
        {
         
        }


    }
}

