using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonEffects : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private RectTransform rectTransform;
    
    [Header("Увеличение/Уменьшение")] [SerializeField]
    private float scaleFactor = 1.07f;

    [Header("Длительность увеличения/уменьшения")]
    [SerializeField] private float scaleDuration = 0.02f;
    private Vector3 originalScale;


    private void Awake()
    {
        if (button == null)
        {
            button = gameObject;
            Debug.Log($"Компонент кнопки взят с игрового объекта {gameObject.name}");
        }

        button.GetComponent<Button>().onClick.AddListener(OnClickReScale);
        rectTransform = button.GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }


    private void OnClickReScale()
    {
        rectTransform.DOScale(originalScale * scaleFactor, scaleDuration)
            .SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                rectTransform.DOScale(originalScale, scaleDuration)
                    .SetEase(Ease.InSine);
            });
    }
}