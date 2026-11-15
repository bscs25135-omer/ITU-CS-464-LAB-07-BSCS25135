using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonFeedback : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    Coroutine running;

    public void OnPointerDown(PointerEventData e) { ScaleTo(0.94f, 0.08f, Ease.OutCubic); }
    public void OnPointerUp(PointerEventData e)   { ScaleTo(1f, 0.2f, Ease.OutBack); }
    public void OnPointerExit(PointerEventData e) { ScaleTo(1f, 0.2f, Ease.OutBack); }

    void ScaleTo(float target, float duration, Func<float, float> ease)
    {
        if (running != null) StopCoroutine(running);
        float start = transform.localScale.x;
        running = StartCoroutine(Tween.Run(duration, ease,
            t => transform.localScale = Vector3.one * Mathf.LerpUnclamped(start, target, t)));
    }
}