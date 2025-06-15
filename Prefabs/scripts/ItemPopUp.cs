using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemPopup : MonoBehaviour
{
    public Image popupImage;        // Drag the UI Image used for pickup
    public float fadeDuration = 0.5f;
    public float displayTime = 1.5f;

    public void ShowPopup(Sprite icon)
    {
        if (popupImage != null)
        {
            popupImage.sprite = icon;
            StopAllCoroutines();
            StartCoroutine(FadeInAndOut());
        }
    }

    IEnumerator FadeInAndOut()
    {
        Color c = popupImage.color;

        // Fade in
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            popupImage.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }

        popupImage.color = new Color(c.r, c.g, c.b, 1);
        yield return new WaitForSeconds(displayTime);

        // Fade out
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            popupImage.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }

        popupImage.color = new Color(c.r, c.g, c.b, 0);
    }
}
