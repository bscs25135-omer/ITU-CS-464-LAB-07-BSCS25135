using UnityEngine;

public class ShopTabs : MonoBehaviour
{
    [SerializeField] GameObject[] pages;
    [SerializeField] RectTransform[] tabs;
    [SerializeField] RectTransform underline;
    Coroutine running;

    void Start() { Select(0); }

    public void Select(int i)
    {
        for (int k = 0; k < pages.Length; k++) pages[k].SetActive(k == i);
        if (running != null) StopCoroutine(running);
        float from = underline.anchoredPosition.x;
        float to = tabs[i].anchoredPosition.x;
        float y = underline.anchoredPosition.y;
        running = StartCoroutine(Tween.Run(0.2f, Ease.OutCubic,
            t => underline.anchoredPosition = new Vector2(Mathf.LerpUnclamped(from, to, t), y)));
    }
}