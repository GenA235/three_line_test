using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPool : MonoBehaviour
{

    public static EnemyPool Instance;
    public List<Enemy> enemiesInPool = new List<Enemy>();
    public List<Enemy> enemiesInGame = new List<Enemy>();

    private UnityEvent<Enemy> onEnemySpawned;
    private UnityEvent<Enemy> onEnemyDespawned;

    public int initialPoolSize = 20;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        onEnemySpawned ??= new UnityEvent<Enemy>();
        onEnemyDespawned ??= new UnityEvent<Enemy>();

    }

    public void InitializePool(EnemyFactory factory)
    {
        var enumLenght = EnemyType.GetValues(typeof(EnemyType)).Length;

        for (int i = 0, j = 0; i < initialPoolSize; i++, j++)
        {
            if (j >= factory.allPossibleEnemies.Count) j = 0;
            EnemyType enemyType = factory.allPossibleEnemies[j].enemyType;
            Enemy enemy = factory.CreateEnemy(enemyType);
            enemy.gameObject.SetActive(false);
            enemiesInPool.Add(enemy);

        }

    }

    public Enemy GetRandomEnemy()
    {
        int randomEnemy = Random.Range(0, enemiesInPool.Count);
        Enemy enemy = enemiesInPool[randomEnemy];
        enemiesInPool.RemoveAt(randomEnemy);
        enemiesInGame.Add(enemy);
        enemy.gameObject.SetActive(true);
        onEnemySpawned.Invoke(enemy);
        return enemy;
    }

    public void ReturnEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        enemiesInGame.Remove(enemy);
        enemiesInPool.Add(enemy);
        onEnemyDespawned.Invoke(enemy);
    }

    public void ReturnAllEnemiesToPool()
    {
        for (int i = 0; i < enemiesInGame.Count; i++)
        {
            try
            {
                Enemy enemy = enemiesInGame[i];
                ReturnEnemy(enemy);
            }
            catch (System.Exception ex)
            {
                Debug.LogException(ex);
            }
        }
    }
}

