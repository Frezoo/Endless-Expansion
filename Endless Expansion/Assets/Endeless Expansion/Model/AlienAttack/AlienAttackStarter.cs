using System.Collections;
using UnityEngine;

public class AlienAttackStarter : MonoBehaviour
{
    [SerializeField][Range(0,1f)] private float alienAttackChance;
    [SerializeField] private float tryInterval;
    
    
    [SerializeField] private AlienAttackEvent alienAttackEvent;

    private void Awake()
    {
        StartCoroutine(TryStartAttack());
    }

    private IEnumerator TryStartAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(tryInterval);
            if (!alienAttackEvent.IsAttackActive)
            {
                if (Random.Range(0,1f) < alienAttackChance)
                {
                    alienAttackEvent.StartAlienAttack(3);
                }
            }
        }
    }
}
