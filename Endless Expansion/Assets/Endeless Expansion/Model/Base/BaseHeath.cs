using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using YG;

public class BaseHeath : MonoBehaviour
{
    [SerializeField] private float health = 15;
    private float maxHealth = 15;

    public UnityEvent<float,float> OnHealthChanged;
    
    public float MaxHealth => maxHealth;

    private void Awake()
    {
        health = YG2.saves.BaseHealth == 0? maxHealth : YG2.saves.BaseHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        OnHealthChanged?.Invoke(health, maxHealth);
        YG2.saves.BaseHealth = health;
        if (health == 0)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene(0);
        SaveManager.Instance.SetDefaultParams();
    }
}
