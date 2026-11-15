using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class ScreenPanel : MonoBehaviour
{
    public ScreenId id;
    public bool isOverlay;
    public RectTransform content;   // the Safe child: slides during transitions
    public RectTransform card;      // overlays only: the box that pops in
    public UnityEvent onShown;
    [HideInInspector] public CanvasGroup group;

    void Awake() { group = GetComponent<CanvasGroup>(); }
}