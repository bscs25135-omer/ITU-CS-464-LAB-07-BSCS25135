using TMPro;
using UnityEngine;

public class CountUp : MonoBehaviour
{
    [SerializeField] TMP_Text label;
    [SerializeField] int target = 1250;

    public void Play()
    {
        StopAllCoroutines();
        StartCoroutine(Tween.Run(0.8f, Ease.OutCubic,
            t => label.text = Mathf.RoundToInt(target * t).ToString()));
    }
}