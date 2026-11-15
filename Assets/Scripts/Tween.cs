using System;
using System.Collections;
using UnityEngine;

public static class Ease
{
    public static float OutCubic(float t) => 1f - Mathf.Pow(1f - t, 3f);
    public static float InCubic(float t) => t * t * t;
    public static float InOutQuad(float t) =>
        t < 0.5f ? 2f * t * t : 1f - Mathf.Pow(-2f * t + 2f, 2f) / 2f;
    public static float OutBack(float t)
    {
        const float c1 = 1.70158f;
        const float c3 = c1 + 1f;
        return 1f + c3 * Mathf.Pow(t - 1f, 3f) + c1 * Mathf.Pow(t - 1f, 2f);
    }
}

public static class Tween
{
    // Runs apply(easedValue) from 0 to 1 over duration seconds, on unscaled time.
    public static IEnumerator Run(float duration, Func<float, float> ease,
                                  Action<float> apply, Action done = null)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            apply(ease(Mathf.Clamp01(t / duration)));
            yield return null;
        }
        apply(ease(1f));
        done?.Invoke();
    }
}