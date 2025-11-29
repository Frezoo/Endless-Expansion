using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PVOLogic : MonoBehaviour
{
    [SerializeField] private AlienAttackEvent alienAttackEvent;
    [SerializeField] private float attackDelay;

    [SerializeField] private RectTransform head;
    [SerializeField] private Transform firePoint;
    
    
    [SerializeField] private Bullet bullet;
    
    [SerializeField] private RectTransform target;
    [SerializeField] private Alien targetAlien;
    

    private void Awake()
    {
        alienAttackEvent.StartAttack.AddListener(OnAttackStarted);
        alienAttackEvent.EndAttack.AddListener(OnAttackEnded);
    }

    private void OnAttackStarted()
    { 
        targetAlien = alienAttackEvent.Aliens[Random.Range(0, alienAttackEvent.Aliens.Count)];
        targetAlien.DiedEvent.AddListener(GetNewTarget);
        target = targetAlien.GetComponent<RectTransform>();
        StartCoroutine(AtackRoutine());
    }
    
    private IEnumerator AtackRoutine()
    {
        StartCoroutine(FixOnTargetRoutine());
        while (true)
        {
            var rocket = Instantiate(bullet,firePoint.position,transform.rotation,transform);
            rocket.StartCoroutine(rocket.RocketAttackRoutine(target));
            yield return new WaitForSeconds(attackDelay);
        }
        
    }

    private IEnumerator FixOnTargetRoutine()
    {
        while (true)
        {
            if (target != null)
            {   
                Vector2 headWorldPos = head.position; 
                Vector2 targetWorldPos = target.position;
                
                Vector2 direction = (targetWorldPos - headWorldPos).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                head.rotation = Quaternion.Euler(0, 0, angle);
                
                yield return null;
            }
            yield return null;
        }
    }

    private void GetNewTarget()
    {
        targetAlien.DiedEvent.RemoveListener(GetNewTarget);
        if (alienAttackEvent.Aliens.Count >= 1)
        {
            targetAlien = alienAttackEvent.Aliens[Random.Range(0, alienAttackEvent.Aliens.Count)];
            targetAlien.DiedEvent.AddListener(GetNewTarget);
            target = targetAlien.GetComponent<RectTransform>();
        }
        
    }
    
    private void OnAttackEnded()
    {
        StopAllCoroutines();
    }
}
