using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonEffects : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private RectTransform rectTransform;
    
    [Header("Покачивание")]
    [SerializeField] private float duration;
    [SerializeField] private float angle;
    
    [Header("Увеличение/Уменьшение")]
    [SerializeField] private float scaleFactor;
    [SerializeField] private float scaleDuration;
    private Vector3 originalScale;
    
    
    

    private void Awake()
    {
        button.GetComponent<Button>().onClick.AddListener(OnClickReScale);
        rectTransform = button.GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
        button.transform.DORotate(Vector3.forward * angle, duration, RotateMode.LocalAxisAdd).SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }


    private void OnClickReScale()
    {
        rectTransform.DOScale(originalScale * scaleFactor, scaleDuration)
            .SetEase(Ease.OutSine)
            .OnComplete(() => {
                rectTransform.DOScale(originalScale, scaleDuration)
                    .SetEase(Ease.InSine);
            });
    }
}