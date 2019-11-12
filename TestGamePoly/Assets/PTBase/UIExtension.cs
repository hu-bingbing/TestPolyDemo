using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public static class UIExtension
{
    public static IEnumerator FadeToAlpha(this CanvasGroup canvasGroup, float alpha, float duration)
    {
        float time = 0f;
        float originalAlpha = canvasGroup.alpha;
        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(originalAlpha, alpha, time / duration);
            yield return new WaitForEndOfFrame();
        }

        canvasGroup.alpha = alpha;
    }

    public static IEnumerator FadeToColor(this Image t_Image, Color color, float duration)
    {

        float time = 0f;
        float color_R = 0f;
        Color originalColor = t_Image.color;
        while (time < duration)
        {
            time += Time.deltaTime;
            color_R = Mathf.Lerp(originalColor.r, color.r, time / duration);
            t_Image.color = new Color(color_R, color_R, color_R, originalColor.a);
            yield return new WaitForEndOfFrame();
        }

        t_Image.color = color;
    }

    public static IEnumerator SmoothValue(this Slider slider, float value, float duration)
    {
        float time = 0f;
        float originalValue = slider.value;
        while (time < duration)
        {
            time += Time.deltaTime;
            slider.value = Mathf.Lerp(originalValue, value, time / duration);
            yield return new WaitForEndOfFrame();
        }

        slider.value = value;
    }

 
}

