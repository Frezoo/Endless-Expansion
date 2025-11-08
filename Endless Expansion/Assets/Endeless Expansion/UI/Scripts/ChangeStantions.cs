using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStantions : MonoBehaviour
{
    [Header("Станции")]
    [SerializeField] private GameObject baseStantion;
    [SerializeField] private GameObject colonyStantion;
    [SerializeField] private GameObject labaratoryStantion;

    [Header("Кнопки-активаторы")]
    [SerializeField] private Button baseStantionButton;
    [SerializeField] private Button colonyStantionButton;
    [SerializeField] private Button labaratoryStantionButton;

    [Header("Анимация")]
    [SerializeField] private float fadeDuration = 0.25f;

    private GameObject activeStantion;
    private Coroutine transition;

    private void Awake()
    {
        if (baseStantionButton != null) baseStantionButton.onClick.AddListener(EnableBasePanel);
        if (colonyStantionButton != null) colonyStantionButton.onClick.AddListener(EnableColonyPanel);
        if (labaratoryStantionButton != null) labaratoryStantionButton.onClick.AddListener(EnableLaboratoryPanel);
        
        SetInstantActive(baseStantion, true);
        SetInstantActive(colonyStantion, false);
        SetInstantActive(labaratoryStantion, false);
        activeStantion = baseStantion;
    }

    public void EnableBasePanel() => CrossFadeTo(baseStantion);
    public void EnableColonyPanel() => CrossFadeTo(colonyStantion);
    public void EnableLaboratoryPanel() => CrossFadeTo(labaratoryStantion);

    private void CrossFadeTo(GameObject newPanel)
    {
        if (newPanel == null) return;
        if (newPanel == activeStantion) return;

        if (transition != null) StopCoroutine(transition);
        transition = StartCoroutine(CrossFadeCoroutine(newPanel));
    }

    private IEnumerator CrossFadeCoroutine(GameObject newPanel)
    {
        var newCg = newPanel.GetComponent<CanvasGroup>();
        var oldCg = activeStantion != null ? activeStantion.GetComponent<CanvasGroup>() : null;
        
        newPanel.SetActive(true);
        newCg.alpha = 0f;
        newCg.interactable = false;
        newCg.blocksRaycasts = false;

        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;
            float p = Mathf.Clamp01(t / fadeDuration);
            if (oldCg != null) oldCg.alpha = Mathf.Lerp(1f, 0f, p);
            newCg.alpha = Mathf.Lerp(0f, 1f, p);
            yield return null;
        }

        // Завершение переключения
        if (oldCg != null)
        {
            oldCg.alpha = 0f;
            oldCg.interactable = false;
            oldCg.blocksRaycasts = false;
            if (activeStantion != null) activeStantion.SetActive(false);
        }

        newCg.alpha = 1f;
        newCg.interactable = true;
        newCg.blocksRaycasts = true;

        activeStantion = newPanel;
        transition = null;
    }

    private void SetInstantActive(GameObject panel, bool on)
    {
        if (panel == null) return;
        var cg = panel.GetComponent<CanvasGroup>();
        if (cg == null) cg = panel.AddComponent<CanvasGroup>();
        panel.SetActive(on);
        cg.alpha = on ? 1f : 0f;
        cg.interactable = on;
        cg.blocksRaycasts = on;
    }
    
}