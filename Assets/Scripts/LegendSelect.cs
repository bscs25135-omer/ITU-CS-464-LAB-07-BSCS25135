using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Legend
{
    public string name, role;
    public Color colour;
    [Range(0, 1)] public float power, speed, defense;
}

public class LegendSelect : MonoBehaviour
{
    [SerializeField] Legend[] legends;
    [SerializeField] TMP_Text nameText, roleText;
    [SerializeField] Image accent, powerBar, speedBar, defenseBar;
    [SerializeField] RectTransform detail;
    Coroutine running;

    void Start() { Select(0); }

    public void Select(int i)
    {
        Legend l = legends[i];
        nameText.text = l.name;
        roleText.text = l.role;
        accent.color = l.colour;
        if (running != null) StopCoroutine(running);
        running = StartCoroutine(Animate(l));
        StartCoroutine(Tween.Run(0.25f, Ease.OutBack,
            t => detail.localScale = Vector3.one * Mathf.LerpUnclamped(0.94f, 1f, t)));
    }

    IEnumerator Animate(Legend l)
    {
        float p = powerBar.fillAmount, s = speedBar.fillAmount, d = defenseBar.fillAmount;
        yield return Tween.Run(0.4f, Ease.OutCubic, t =>
        {
            powerBar.fillAmount = Mathf.LerpUnclamped(p, l.power, t);
            speedBar.fillAmount = Mathf.LerpUnclamped(s, l.speed, t);
            defenseBar.fillAmount = Mathf.LerpUnclamped(d, l.defense, t);
        });
    }
}