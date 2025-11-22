using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class BaseHealthChanged : MonoBehaviour
{
    
    [SerializeField] private BaseHeath baseHeath;
    [SerializeField] private Image healthBar;
    [SerializeField] private CanvasGroup healthBarGroup;

    [SerializeField] private float fadeDuration = 0.25f;
    [SerializeField] private float fillDuration = 0.5f;

    private Coroutine currentRoutine;

    private void Awake()
    {
        if (baseHeath != null)
            baseHeath.OnHealthChanged.AddListener(OnHealthChanged);
        IternalFill();
    }

    private void IternalFill()
    {
        healthBar.fillAmount = Mathf.Clamp01(YG2.saves.BaseHealth/baseHeath.MaxHealth);
    }
    

    private void OnHealthChanged(float currentHealth, float maxHealth)
    {
        if (healthBar == null || healthBarGroup == null) return;

        float targetFill = (maxHealth > 0f) ? Mathf.Clamp01(currentHealth / maxHealth) : 0f;

        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(FadeAndFill(targetFill));
    }

    private IEnumerator FadeAndFill(float targetFill)
    {
        // Fade alpha to 1
        float startAlpha = healthBarGroup.alpha;
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            healthBarGroup.alpha = Mathf.Lerp(startAlpha, 1f, fadeDuration > 0f ? elapsed / fadeDuration : 1f);
            yield return null;
        }
        healthBarGroup.alpha = 1f;

        // Fill image smoothly
        float startFill = healthBar.fillAmount;
        elapsed = 0f;
        while (elapsed < fillDuration)
        {
            elapsed += Time.deltaTime;
            healthBar.fillAmount = Mathf.Lerp(startFill, targetFill, fillDuration > 0f ? elapsed / fillDuration : 1f);
            yield return null;
        }
        healthBar.fillAmount = targetFill;

        currentRoutine = null;
    }

    private void OnDestroy()
    {
        baseHeath.OnHealthChanged.RemoveListener(OnHealthChanged);
    }
}
