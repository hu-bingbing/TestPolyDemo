using SGF.Unity.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePloy.UI
{
    public class UITipArg
    {
        public string Title = "";
        public string Content = "";
        public string BtnNameArgs;//"确定|取消|关闭"
    }

    public class UITipWindow : UIPolyWindow
    {
        private UITipArg m_arg;
        public Text textTitle;
        public Text textContent;
        public Button[] tipButtons;


        protected override void OnOpen(object arg = null)
        {
            SetUILayer(UILayer.BASE_LAYER, UILayerDef.NormalWindow);

            m_arg = arg as UITipArg;
            textContent.text = m_arg.Content;
            string[] btnTexts = m_arg.BtnNameArgs.Split('|');

            SetChildText(textTitle, m_arg.Title);

            float btnWidth = 200;
            float btnStartX = (1 - btnTexts.Length) * btnWidth / 2;

            for (int i = 0; i < tipButtons.Length; i++)
            {
                if (i < btnTexts.Length)
                {
                    SetChildBtnText(tipButtons[i], btnTexts[i]);
                    SetChildActive(tipButtons[i].gameObject, true);
                    Vector3 pos = tipButtons[i].transform.localPosition;
                    pos.x = btnStartX + i * btnWidth;
                    tipButtons[i].transform.localPosition = pos;
                }
                else
                {
                    SetChildActive(tipButtons[i].gameObject, false);
                }
            }


        }

        public void OnBtnClick(int btnIndex)
        {
            Button btn = tipButtons[btnIndex];
            this.Close(btnIndex);
        }

        protected override void OnClose(object arg = null)
        {
            base.OnClose(arg);
        }
    }

}
