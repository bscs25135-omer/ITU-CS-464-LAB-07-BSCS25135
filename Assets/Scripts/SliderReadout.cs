using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderReadout : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text label;

    void Start()
    {
        slider.onValueChanged.AddListener(Show);
        Show(slider.value);
    }

    void Show(float v) { label.text = Mathf.RoundToInt(v).ToString(); }
}