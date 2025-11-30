using UnityEngine;
using System.Collections;
public class ThrowAlerts : MonoBehaviour
{
    [SerializeField] private GameObject HaveNotEnoughMoneyAlert;
    [SerializeField] private GameObject AlienAttackAlert;
    [SerializeField] private GameObject AlienAttackEndAlert;
    [SerializeField] private GameObject NewPhaseAlert;
    [SerializeField] private GameObject Phase1Alert;
    [SerializeField] private GameObject Phase2Alert;
    [SerializeField] private GameObject Phase3Alert;
    public static ThrowAlerts Instance;
    private Coroutine coroutine;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    
    
    public void ThrowNotEnoughMoneyAlert()
    {
        if (coroutine != null)
        {
            
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
            
            if (AlienAttackAlert != null)
            {
                AlienAttackAlert.SetActive(false);
            }
        }
        coroutine =  StartCoroutine(ShowAndHideAlert(0.25f, 1.5f, AlienAttackAlert));
    }
    
    public void ThrowAlienAttackEndAlert()
    {
        if (coroutine != null)
        {
            if (AlienAttackEndAlert != null)
            {
                AlienAttackEndAlert.SetActive(false);
            }
        }
        coroutine =  StartCoroutine(ShowAndHideAlert(0.25f, 1.5f, AlienAttackEndAlert));
    }
    
    public void ThrowNewPhaseAlert()
    {
        if (coroutine != null)
        {
            if (NewPhaseAlert != null)
            {
                NewPhaseAlert.SetActive(false);
            }
        }
        coroutine =  StartCoroutine(ShowAndHideAlert(0.25f, 1.5f, NewPhaseAlert));
    }
    
    public void ThorPhase1Alert()
    {
        if (coroutine != null)
        {
            if (Phase1Alert != null)
            {
                Phase1Alert.SetActive(false);
            }
        }
        coroutine =  StartCoroutine(ShowAndHideAlert(0.25f, 3f, Phase1Alert));
    }
    public void ThorPhase2Alert()
    {
        if (coroutine != null)
        {
            if (Phase2Alert != null)
            {
                Phase2Alert.SetActive(false);
            }
        }
        coroutine =  StartCoroutine(ShowAndHideAlert(0.25f, 3f, Phase2Alert));
    }
    public void ThorPhase3Alert()
    {
        if (coroutine != null)
        {
            if (Phase3Alert != null)
            {
                Phase3Alert.SetActive(false);
            }
        }
        coroutine =  StartCoroutine(ShowAndHideAlert(0.25f, 3f, Phase3Alert));
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
