using System;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] private float damage = 3f;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private float bulletSpeed = 2000f;
    private RectTransform rectTransform;
    [SerializeField] private RectTransform target;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public IEnumerator RocketAttackRoutine(RectTransform target)
    {
        this.target = target;
        if (target == null || rectTransform.parent == null)
        {
            Destroy(gameObject);
            yield break;
        }
        
    
        Vector3 targetWorldPos = target.position;
        Vector3 localTarget = rectTransform.parent.InverseTransformPoint(targetWorldPos);
        Vector2 targetPos = new Vector2(localTarget.x, localTarget.y);

        Vector2 fixedDirection = (targetPos - rectTransform.anchoredPosition).normalized;
        float angle = Mathf.Atan2(fixedDirection.y, fixedDirection.x) * Mathf.Rad2Deg - 90f;
        rectTransform.localRotation = Quaternion.Euler(0, 0, angle);

        float elapsed = 0f;
        while (elapsed < lifeTime)
        {
            rectTransform.anchoredPosition += fixedDirection * bulletSpeed * Time.deltaTime;

            if (target != null)
            {
                targetWorldPos = target.position;
                localTarget = rectTransform.parent.InverseTransformPoint(targetWorldPos);
                targetPos = new Vector2(localTarget.x, localTarget.y);
                var distance = Vector2.Distance(rectTransform.anchoredPosition, targetPos);
                if (distance < 2f)
                {
                    Destroy(gameObject);
                }
                if (distance < 15f)
                {
                    var alien = target.GetComponent<Alien>();
                    if (alien != null)
                        alien.GetDamage(damage);
                    Destroy(gameObject);
                    yield break;
                }
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
   
    
}
