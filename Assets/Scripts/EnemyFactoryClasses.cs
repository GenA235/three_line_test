using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using UnityEngine;
public class EnemyFactory : MonoBehaviour
{
    public List<Enemy> allPossibleEnemies = new List<Enemy>();
    public Enemy CreateEnemy(EnemyType enemyType) =>
     Instantiate((allPossibleEnemies.Where(t => t.enemyType == enemyType).FirstOrDefault()));
}

public enum EnemyType
{
    Bike,
    Car,
    Tank
}