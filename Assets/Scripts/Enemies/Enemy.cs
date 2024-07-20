using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public EnemyType enemyType;
    public abstract  void OnTriggerEnter2D(Collider2D collision);
    public abstract void Initialize(EnemyStatsContainer enemyStats);
   
}



