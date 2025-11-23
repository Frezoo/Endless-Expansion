using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PVOLogic : MonoBehaviour
{
    [SerializeField] private AlienAttackEvent alienAttackEvent;
    [SerializeField] private float attackDelay;
    
    
    [SerializeField] private Bullet bullet;
    
    private Coroutine attackCorutine;

    private void Awake()
    {
        alienAttackEvent.StartAttack.AddListener(OnAttackStarted);
        alienAttackEvent.EndAttack.AddListener(OnAttackEnded);
    }

    private void OnAttackStarted()
    {
        attackCorutine =  StartCoroutine(AtackRoutine());
    }
    
    private IEnumerator AtackRoutine()
    {
        while (true)
        {
            var rocket = Instantiate(bullet,transform.position,transform.rotation,transform);
            rocket.StartCoroutine(rocket.RocketAttackRoutine(alienAttackEvent.Aliens[Random.Range(0, alienAttackEvent.Aliens.Count)].GetComponent<RectTransform>()));
            yield return new WaitForSeconds(attackDelay);
        }
        
    }
    
    
    private void OnAttackEnded()
    {
        StopCoroutine(attackCorutine);
    }
}
