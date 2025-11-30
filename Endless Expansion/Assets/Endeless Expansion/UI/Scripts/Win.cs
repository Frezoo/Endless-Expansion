using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Win : MonoBehaviour
{
    
    [SerializeField] private GameObject winPanel;
    [SerializeField] private CanvasGroup winPanelCanvasGroup;
    [SerializeField] private CanvasGroup GameCanvasGroup;
    [SerializeField] private CanvasGroup settingsCanvasGroup;

    [SerializeField] private OpenCloseSettings openCloseSettings;
    
    [SerializeField] private TMP_Text clickedCountsText;
    [SerializeField] private TMP_Text killedAliensText;
    [SerializeField] private TMP_Text allMoneyText;
   
    public static Win instance;

    private void Awake()
    {
        instance = this;
    }

    public void OnWin()
    {
        winPanel.SetActive(true);
        float t = 0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime;
            winPanelCanvasGroup.alpha = Mathf.Clamp01(t / 0.5f);
        }
        winPanelCanvasGroup.alpha = 1f;
        GameCanvasGroup.interactable = false;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.alpha = 0;
        openCloseSettings.CanBeOpen = false;

        clickedCountsText.text = YG2.saves.ClickCount.ToString();
        killedAliensText.text = YG2.saves.KilledAliensCount.ToString();
        allMoneyText.text = YG2.saves.AllMoney.ToString();
        
        Time.timeScale = 0.01f;
    }
    
    public void GoToMainMenu()
    {
        SaveManager.Instance.SetDefaultParams();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    
    
}
