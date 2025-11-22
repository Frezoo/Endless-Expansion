using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine; 

public class AlienAttackEvent : MonoBehaviour
{
    [SerializeField] private Alien alienPrefab;
    [SerializeField] private List<RectTransform> spawnPoints = new();
    [SerializeField] private List<RectTransform> usedSpawnPoints = new();
    
    [SerializeField] private List<Alien> aliens = new();
    [SerializeField] private float spawnDelay;
    
    [SerializeField] private RectTransform attackTarget;
    [SerializeField] private bool isAttackActive;

    public bool IsAttackActive
    {
        get => isAttackActive;
    }

    public void StartAlienAttack(int alienCount)
    {
        Debug.Log("Alien Attack Started!");
        isAttackActive = true;
        StartCoroutine(SpawnAlies(alienCount));
    }

    private IEnumerator SpawnAlies(int alienCount)
    {
        for (int i = 0; i < alienCount; i++)
        {
            var available = Enumerable.Where(spawnPoints, sp => !usedSpawnPoints.Contains(sp));
            var availableList = Enumerable.ToList(available);
            if (availableList.Count == 0)
            {
                usedSpawnPoints.Clear();
                availableList = Enumerable.ToList(spawnPoints);
            }
            
            var spawnPoint = availableList[Random.Range(0, availableList.Count)];
            usedSpawnPoints.Add(spawnPoint);
            var alien = Instantiate(alienPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
            alien.AddBase(attackTarget);
            aliens.Add(alien);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
