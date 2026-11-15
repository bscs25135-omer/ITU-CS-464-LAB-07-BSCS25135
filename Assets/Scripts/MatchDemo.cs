using UnityEngine;

public class MatchDemo : MonoBehaviour
{
    [SerializeField] HealthBar playerBar;
    [SerializeField] int max = 5;
    int hp;

    public void ResetMatch() { hp = max; playerBar.Set(hp, max); }
    public void Hit() { hp = Mathf.Max(0, hp - 1); playerBar.Set(hp, max); }
}