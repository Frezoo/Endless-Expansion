using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseSettings : MonoBehaviour
{
    [Header("Кнопка")] [SerializeField] private Button closeButton;
    [SerializeField] private Button openButton;

    [Header("Объект настроек")] [SerializeField]
    private GameObject settingsPanel;

    [SerializeField] private CanvasGroup settingsCanvasGroup;
    private RectTransform settingsPanelRectTransform;

    [Header("Анимация")] [SerializeField] private Vector3 defaultScale;
    [SerializeField] private float duration;
    private Vector3 lowScale = Vector3.zero;

    [Header("Ввод с клавиатуры")] [SerializeField]
    private InputController inputController;

    [Header("Canvas Group для блокировки ввода при анимации")] [SerializeField]
    private CanvasGroup otherCanvasGroup;
    
    private bool canBeOpen = true;

    public bool CanBeOpen
    {
        get => canBeOpen;
        set => canBeOpen = value;
    }

    private void Awake()
    {
        settingsPanelRectTransform = settingsPanel.GetComponent<RectTransform>();
        closeButton.onClick.AddListener(CloseSettingsPanel);
        openButton.onClick.AddListener(OpenSettingsPanel);
        inputController.OpenSettings.AddListener(OpenSettingsPanel);
        inputController.CloseSettings.AddListener(CloseSettingsPanel);
        CloseSettingsPanel();
    }


    private void CloseSettingsPanel()
    {
        inputController.IsOpen = false;
        settingsCanvasGroup.interactable = false;
        settingsPanelRectTransform.DOScale(lowScale, duration)
            .SetEase(Ease.OutBack)
            .OnComplete((() =>
            {
                settingsPanel.SetActive(false);
                otherCanvasGroup.interactable = true;
            }));
    }

    private void OpenSettingsPanel()
    {
        if (canBeOpen)
        {
            inputController.IsOpen = true;
            settingsPanel.SetActive(true);
            settingsPanelRectTransform.DOScale(defaultScale, duration)
                .SetEase(Ease.OutBack)
                .OnComplete((() =>
                        {
                            settingsCanvasGroup.interactable = true;
                            otherCanvasGroup.interactable = false;
                        }
                    ));
        }
        
    }
}