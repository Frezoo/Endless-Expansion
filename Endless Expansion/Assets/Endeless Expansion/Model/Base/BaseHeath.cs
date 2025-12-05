using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using YG;

public class BaseHeath : MonoBehaviour
{
    [SerializeField] private float health = 15;
    private float maxHealth => YG2.saves.MaxBaseHealth;

    public UnityEvent<float,float> OnHealthChanged;
    public UnityEvent GameOver;
    
    public float MaxHealth => maxHealth;

    private void Awake()
    {
        health = YG2.saves.BaseHealth;
        if (health == 0)
        {
            GameOver?.Invoke();
        }
    }

    public void TakeDamage(float amount)
    {
        YG2.saves.BaseHealth -= amount;
        health = Mathf.Clamp(YG2.saves.BaseHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(health, maxHealth);
        YG2.saves.BaseHealth = health;
        if (health == 0)
        {
            GameOver?.Invoke();
        }
    }
}
