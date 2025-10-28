using UnityEngine;
using UnityEngine.UI;
using YG;

public class SwitchLanguage : MonoBehaviour
{
    [Header("Кнопки")]
    [SerializeField] private Button RussianButton;
    [SerializeField] private Button EnglishButton;
    [SerializeField] private Button TurkishButton;
    
    private void Awake()
    {
        EnglishButton.onClick.AddListener(SwitchToEnglish);
        TurkishButton.onClick.AddListener(SwitchToTurkish);
        RussianButton.onClick.AddListener(SwitchToRussian);
    }

    private void SwitchToRussian()
    {
        YG2.SwitchLanguage("ru");
    }

    private void SwitchToEnglish()
    {
        YG2.SwitchLanguage("en");
    }

    private void SwitchToTurkish()
    {
        YG2.SwitchLanguage("tr");
    }
    
}
