using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameOver : MonoBehaviour
{
    [SerializeField] private BaseHeath baseHeath;
    
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private CanvasGroup gameOverPanelCanvasGroup;
    [SerializeField] private CanvasGroup gameCanvasGroup;
    [SerializeField] private CanvasGroup settingsCanvasGroup;

    [SerializeField] private OpenCloseSettings openCloseSettings;
    
    [SerializeField] private TMP_Text clickedCountsText;
    [SerializeField] private TMP_Text killedAliensText;
    [SerializeField] private TMP_Text allMoneyText;
   

    private void Awake()
    {
        baseHeath.GameOver.AddListener(OnGameOver);
    }

    private void OnGameOver()
    {
        gameOverPanel.SetActive(true);
        float t = 0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime;
            gameOverPanelCanvasGroup.alpha = Mathf.Clamp01(t / 0.5f);
        }
        gameOverPanelCanvasGroup.alpha = 1f;
        gameCanvasGroup.interactable = false;
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
