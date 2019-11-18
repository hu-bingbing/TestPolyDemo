using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GamePloy
{
    public class CommonButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        private const float FadeTime = 0.3f;
        public Color OnHoverColor = new Color(0.80f, 0.80f, 0.80f);
        public Color OnClickColor = new Color(0.78f, 0.78f, 0.78f);
        private float Alpha = 1;
         
        private Color m_ImageColor;

        private bool m_IsActivate = false;
        
        [SerializeField]
        public Image m_Image = null;

        [SerializeField]
        public GameObject lockObj = null;

        [SerializeField]
        public bool isHoverColor = true;

        [SerializeField]
        public bool isClickColor = true;

        [SerializeField]
        public UnityEvent m_OnHover = null;

        [SerializeField]
        public UnityEvent m_OnClick = null;
        
        public void ActivateButton(bool isActivate)
        {
            if (m_IsActivate != isActivate)
            {
                m_IsActivate = isActivate;
                if (m_IsActivate && lockObj != null)
                    lockObj.SetActive(false);
            }
        }

        public void SetClickEffect(bool isHoverColor, bool isClickColor, Color hColor, Color cColor)
        {
            this.isHoverColor = isHoverColor;
            this.isClickColor = isClickColor;
            if (hColor.a > 0 && isHoverColor)
                OnHoverColor = hColor;
            if (cColor.a > 0 && isClickColor)
                OnClickColor = cColor;
        }

        private void Awake()
        {
            if(m_Image == null)
            {
                m_Image = this.transform.GetComponent<Image>();
            }
            if(lockObj == null)
            {
                lockObj = this.gameObject;
            }

            m_ImageColor = m_Image.color;
            Alpha = m_ImageColor.a;
            OnHoverColor.a = Alpha;
            OnClickColor.a = Alpha;
            if (lockObj != null)
                lockObj.SetActive(true);
        }

        private void OnDisable()
        {
            //m_Image.color = m_ImageColor;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            m_OnClick.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!m_IsActivate)
                return;
            if (isHoverColor)
            {
                StopAllCoroutines();
                StartCoroutine(m_Image.FadeToColor(OnHoverColor, FadeTime));
            }
            m_OnHover.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!m_IsActivate)
                return;
            if (isHoverColor)
            {
                StopAllCoroutines();
                StartCoroutine(m_Image.FadeToColor(m_ImageColor, FadeTime));
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!m_IsActivate)
                return;
            if (isClickColor)
                m_Image.color = OnClickColor;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!m_IsActivate)
                return;
            if (isClickColor)
                m_Image.color = m_ImageColor;
        }
    }
}
