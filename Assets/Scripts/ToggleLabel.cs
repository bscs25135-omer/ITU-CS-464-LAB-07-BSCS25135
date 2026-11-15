using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleLabel : MonoBehaviour
{
    [SerializeField] TMP_Text label;
    [SerializeField] string onText = "ON";
    [SerializeField] string offText = "OFF";
    [SerializeField] Color onColour = new Color(0.055f, 0.063f, 0.125f);
    [SerializeField] Color offColour = new Color(0.639f, 0.663f, 0.8f);
    Toggle toggle;

    void Awake()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(Show);
        Show(toggle.isOn);
    }

    void Show(bool on)
    {
        label.text = on ? onText : offText;
        label.color = on ? onColour : offColour;
    }
}