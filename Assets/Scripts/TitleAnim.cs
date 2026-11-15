using System.Collections;
using UnityEngine;

public class TitleAnim : MonoBehaviour
{
    [SerializeField] RectTransform logo;
    [SerializeField] CanvasGroup tapPrompt;

    public void Play()
    {
        StopAllCoroutines();
        StartCoroutine(Tween.Run(0.6f, Ease.OutBack,
            t => logo.localScale = Vector3.one * Mathf.LerpUnclamped(0.8f, 1f, t)));
        StartCoroutine(Pulse());
    }

    IEnumerator Pulse()
    {
        while (true)
        {
            yield return StartCoroutine(Tween.Run(1.2f, Ease.InOutQuad,
                t => tapPrompt.alpha = Mathf.Lerp(0.35f, 1f, t)));
            yield return StartCoroutine(Tween.Run(1.2f, Ease.InOutQuad,
                t => tapPrompt.alpha = Mathf.Lerp(1f, 0.35f, t)));
        }
    }
}