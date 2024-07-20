using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyStats enemyStats;
    [SerializeField]
    private List<Transform> SpawnPoints = new List<Transform>();
    public EnemyFactory _enemyFactory;
   

    void Awake()
    {
        EnemyPool.Instance.InitializePool(_enemyFactory);
    }
    public Enemy SpawnRandomEnemyOnRandomPoint()
    {
        var randomPoint = SpawnPoints[Random.Range(0, SpawnPoints.Count)];
        var en = EnemyPool.Instance.GetRandomEnemy();
        en.transform.position = randomPoint.position;
        var stats = enemyStats.GetStatsByType(en.enemyType);
        en.Initialize(stats);
        return en;

    }


}
