using UnityEngine;
using UnityEngine.UI;
using YG;

public class SwitchLanguage : MonoBehaviour
{
    [Header("Кнопки")]
    [SerializeField] private Button russianButton;
    [SerializeField] private Button englishButton;
    [SerializeField] private Button turkishButton;
    
    private void Awake()
    {
        englishButton.onClick.AddListener(SwitchToEnglish);
        turkishButton.onClick.AddListener(SwitchToTurkish);
        russianButton.onClick.AddListener(SwitchToRussian);
        
        if (YG2.isSDKEnabled)
        {
            OnSavesReady();
        }
        else
        {
            Invoke("OnSavesReady", 0.03f);
        }
    }

    private void SwitchToRussian()
    {
        YG2.SwitchLanguage("ru");
        YG2.saves.Language = "ru";
    }

    private void SwitchToEnglish()
    {
        YG2.SwitchLanguage("en");
        YG2.saves.Language = "en";
    }

    private void SwitchToTurkish()
    {
        YG2.SwitchLanguage("tr");
        YG2.saves.Language = "tr";
    }
    
    private void OnSavesReady()
    {
        if (YG2.saves.Language != null)
        {
            Debug.Log("Language: " + YG2.saves.Language);
            YG2.SwitchLanguage(YG2.saves.Language);
        }
    }

    private void OnDisable()
    {
        YG2.SaveProgress();
    }
}
