using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
public class EnemyStats : ScriptableObject
{
   public List<EnemyStatsContainer> enemyStatsContainers = new List<EnemyStatsContainer>();
   public EnemyStatsContainer GetStatsByType(EnemyType type) => enemyStatsContainers.Where(c=>c.EnemyType == type).FirstOrDefault();
}
[Serializable]
public class EnemyStatsContainer{
public EnemyType EnemyType;
public int EnemyDamageAmount;
public int EnemyHealth;
public Vector2 EnemySpeedRange;

public float GetRandomSpeed => UnityEngine.Random.Range(EnemySpeedRange.x, EnemySpeedRange.y);
}