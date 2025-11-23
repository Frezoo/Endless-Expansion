using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using YG;

public class Alien : MonoBehaviour
{

    [Header("Показатели")] [SerializeField]
    private float health;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackDelay;
    [SerializeField] private float maxDistanceBeyondTarget = 350f;
    private bool isAttacking;

    [Header("Fake Collider")] [SerializeField]
    private Button fakeColliderButton;

    [Header("Цель атаки")] [SerializeField]
    private RectTransform target;

    private BaseHeath baseHealth;

    [Header("Параметры анимаций")] [SerializeField]
    private float spawnAnimationDuration;

    [Header("Цветовая реакция на урон")] [SerializeField]
    private Color damagedColor;

    [SerializeField] private Color currentColor;
    [SerializeField] private float damagedColorDuration;
    [SerializeField] private int damagedBlinkCount;

    [Header("Масштабная реакция на урон")] [SerializeField]
    private Vector3 damagedReScale;

    [SerializeField] private float damagedReScaleDuration;

    [Header("Смерть инопланетянина")] [SerializeField]
    private float diedFadeDuration;

    [SerializeField] private Image alienImage;

    [Header("Блуждание")] [SerializeField] private AlienWendering wander;

    private bool wasAttackingInThisTurn = false;

    [Header("Позиция")] [SerializeField] private RectTransform alienTransform;
    
    private AlienAttackEvent alienAttackEvent;

    public RectTransform Target
    {
        set => target = value;
    }

    private void SpawnAnimation()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, spawnAnimationDuration).SetEase(Ease.OutBack);
    }

    private void Awake()
    {
        wander.Initialize();
        wander.StartWandering();
        StartCoroutine(AttackLoop());
        InitAnimations();
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        if (distance <= 5 && !wasAttackingInThisTurn)
        {
            Debug.Log($"Дистанция {distance} пришленец {gameObject.name}");
            baseHealth.TakeDamage(attackDamage);
            wasAttackingInThisTurn = true;
        }
    }


    private void InitAnimations()
    {
        SpawnAnimation();
        currentColor = alienImage.color;

    }

    public void GetDamage(float damageValue)
    {
        Debug.Log("Получен урон: " + damageValue);
        PlayDamageAnimation();
        health -= damageValue;
        if (health <= 0)
        {
            Died();
        }
    }

    private void PlayDamageAnimation()
    {
        var seq = DOTween.Sequence();
        seq.Append(alienImage.DOColor(damagedColor, damagedColorDuration).SetEase(Ease.Linear));
        seq.Append(transform.DOScale(damagedReScale, damagedReScaleDuration).SetEase(Ease.OutBack));
        seq.Append(alienImage.DOColor(currentColor, damagedColorDuration).SetEase(Ease.Linear));
        seq.Append(transform.DOScale(Vector3.one, damagedReScaleDuration).SetEase(Ease.OutBack));
        seq.SetLoops(damagedBlinkCount, LoopType.Restart);
        seq.OnComplete(() => alienImage.color = currentColor);
    }

    private IEnumerator AttackRoutine()
    {
        if (target == null) yield break;

        Debug.Log("Начало атаки инопланетянина!");
        wasAttackingInThisTurn = false;
        wander.StopWandering();

        Vector3 fromWorld = alienTransform.position;
        Vector3 toWorld = target.position;
        Vector3 dir = toWorld - fromWorld;

        if (dir.sqrMagnitude < Mathf.Epsilon)
            dir = Vector3.up;

        Vector3 limitedDir = Vector3.ClampMagnitude(dir, maxDistanceBeyondTarget);
        Vector3 destWorld = toWorld + limitedDir;

        float distance = (destWorld - fromWorld).magnitude;
        float attackDuration = Mathf.Clamp(distance / 200f, 0.3f, 1.5f);

        Vector3 destLocal = alienTransform.parent.InverseTransformPoint(destWorld);
        Vector2 attackEndPosition = new Vector2(destLocal.x, destLocal.y);

        // Выполняем атаку и ждём её завершения
        yield return alienTransform.DOAnchorPos(attackEndPosition, attackDuration)
            .SetEase(Ease.Linear)
            .SetLink(gameObject)
            .WaitForCompletion();

        // После атаки — возобновляем блуждание
        wander.SetWanderCenter(alienTransform.anchoredPosition);
        wander.StartWandering();
    }

    private IEnumerator AttackLoop()
    {
        while (true)
        {
            yield return StartCoroutine(AttackRoutine());
            yield return new WaitForSeconds(attackDelay);
        }
    }


    private void Died()
    {
        Debug.Log("Инопланетянин уничтожен!");
        fakeColliderButton.interactable = false;
        alienImage.DOFade(0.0f, diedFadeDuration).SetEase(Ease.OutBack).OnComplete(() =>
        {
            alienAttackEvent.RemoveAlien(this);
            Destroy(gameObject);
        });
        YG2.saves.KilledAliensCount++;
    }

    public void AddStartInfo(RectTransform Target, AlienAttackEvent AlienEvent)
    {
        target = Target;
        baseHealth = Target.GetComponent<BaseHeath>();
        alienAttackEvent = AlienEvent;
    }

}
