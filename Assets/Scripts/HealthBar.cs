using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image fill, lag;
    [SerializeField] Gradient colour;   // Danger -> Gold -> Frost
    [SerializeField] float lagDelay = 0.4f, lagSpeed = 0.8f;
    float target = 1f, lagStartsAt;

    public void Set(int current, int max)
    {
        float next = Mathf.Clamp01((float)current / max);   // cast, or ints give 0
        if (next < target) lagStartsAt = Time.unscaledTime + lagDelay;
        else lag.fillAmount = next;
        target = next;
        fill.fillAmount = target;
        fill.color = colour.Evaluate(target);
    }

    void Update()
    {
        if (Time.unscaledTime < lagStartsAt) return;
        lag.fillAmount = Mathf.MoveTowards(lag.fillAmount, target,
            lagSpeed * Time.unscaledDeltaTime);
    }
}