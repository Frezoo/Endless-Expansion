using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class OpenCloseSettings : MonoBehaviour
{
    
    [Header("Кнопка")]
    [SerializeField] private Button closeButton;
    [SerializeField] private Button openButton;
    
    [Header("Объект настроек")]
    [SerializeField] private GameObject settingsPanel;
    private RectTransform settingsPanelRectTransform;
    
    [Header("Анимация")]
    [SerializeField] private Vector3 defaultScale;
    [SerializeField] private float duration;
    private Vector3 lowScale = Vector3.zero;
    
    
    private void Awake()
    {
        settingsPanelRectTransform = settingsPanel.GetComponent<RectTransform>();
        closeButton.onClick.AddListener(CloseSettingsPanel);
        openButton.onClick.AddListener(OpenSettingsPanel);
    }

    private void CloseSettingsPanel()
    {
        settingsPanelRectTransform.DOScale(lowScale, duration)
            .SetEase(Ease.OutBack)
            .OnComplete((() =>
            {
                settingsPanel.SetActive(false);
            }));
        
    }

    private void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
        settingsPanelRectTransform.DOScale(defaultScale, duration)
            .SetEase(Ease.OutBack) ;
    }
}
