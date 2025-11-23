using UnityEngine;
using System.Collections;
public class ThrowAlerts : MonoBehaviour
{
    [SerializeField] private GameObject HaveNotEnoughMoneyAlert;
    [SerializeField] private GameObject AlienAttackAlert;
    public static ThrowAlerts Instance;
    private Coroutine coroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    
    public void ThrowNotEnoughMoneyAlert()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            if (HaveNotEnoughMoneyAlert != null)
            {
                HaveNotEnoughMoneyAlert.SetActive(false);
            }
        }
        coroutine =  StartCoroutine(ShowAndHideAlert(0.25f, 1.5f, HaveNotEnoughMoneyAlert));
    }
    
    public void ThrowAlienAttackAlert()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            if (AlienAttackAlert != null)
            {
                AlienAttackAlert.SetActive(false);
            }
        }
        coroutine =  StartCoroutine(ShowAndHideAlert(0.25f, 1.5f, AlienAttackAlert));
    }
    

    private IEnumerator ShowAndHideAlert(float fadeDuration, float visibleTime, GameObject alert)
    {
        if (alert == null) yield break;

        CanvasGroup cg = alert.GetComponent<CanvasGroup>();
        if (cg == null) cg = alert.AddComponent<CanvasGroup>();

        alert.SetActive(true);

        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }
        cg.alpha = 1f;

        yield return new WaitForSeconds(visibleTime);

        t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Clamp01(1f - t / fadeDuration);
            yield return null;
        }
        cg.alpha = 0f;
        alert.SetActive(false);
    }
}
