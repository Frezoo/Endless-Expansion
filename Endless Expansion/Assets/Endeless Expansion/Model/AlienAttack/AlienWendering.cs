using System.Collections;
using UnityEngine;
using DG.Tweening;

[DisallowMultipleComponent]
public class AlienWendering : MonoBehaviour
{
    [Header("Target RectTransform (оставьте пустым, если компонент на том же объекте)")]
    [SerializeField] private RectTransform rectTransform;

    [Header("Параметры блуждания")]
    [SerializeField] private float wanderRadius = 2f;
    [SerializeField] private float wanderMinDuration = 0.8f;
    [SerializeField] private float wanderMaxDuration = 1.6f;
    [SerializeField] private float pauseBetweenWanders = 0.1f;

    private Vector2 homePosition;
    private Coroutine wanderRoutine;
    private bool isWandering;

    private void Reset()
    {
        if (rectTransform == null)
            rectTransform = GetComponent<RectTransform>();
    }

    private void Awake()
    {
        if (rectTransform == null)
            rectTransform = GetComponent<RectTransform>();
        homePosition = rectTransform.anchoredPosition;
    }

    public void Initialize(RectTransform rect = null)
    {
        if (rect != null) rectTransform = rect;
        if (rectTransform == null) rectTransform = GetComponent<RectTransform>();
        homePosition = rectTransform.anchoredPosition;
    }

    public void StartWandering()
    {
        StopWandering();
        homePosition = rectTransform.anchoredPosition;
        isWandering = true;
        wanderRoutine = StartCoroutine(WanderLoop());
    }

    public void StopWandering()
    {
        isWandering = false;
        if (wanderRoutine != null)
        {
            StopCoroutine(wanderRoutine);
            wanderRoutine = null;
        }
        rectTransform.DOKill();
    }
    

    private IEnumerator WanderLoop()
    {
        while (isWandering)
        {
            Vector2 rnd = Random.insideUnitCircle * wanderRadius;
            Vector2 dest = homePosition + rnd;
            float duration = Random.Range(wanderMinDuration, wanderMaxDuration);

            var tween = rectTransform.DOAnchorPos(dest, duration)
                .SetEase(Ease.InOutSine)
                .SetLink(gameObject);

            yield return tween.WaitForCompletion();

            if (!isWandering) yield break;

            yield return new WaitForSeconds(pauseBetweenWanders);
        }
    }
    
    public void SetWanderCenter(Vector2 newCenter)
    {
        homePosition = newCenter;
    }
}