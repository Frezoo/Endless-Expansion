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
