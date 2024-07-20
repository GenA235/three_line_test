using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    public Vector2 EnemyAmountToWin_Range;
    public Vector2 NextEnemySpawnTimeout_Range;
    public float PlayerAttackRadius;
    public float PlayerAttackFrequency;
    public float PlayerDamageValue;
    public float PlayerBulletSpeed;
    public float PlayerMovementSpeed;
    public float PlayerHealth;
    
    public int GetRandomEnemyAmountToWin => Random.Range((int)EnemyAmountToWin_Range.x,(int)EnemyAmountToWin_Range.y);
    public float GetRandomEnemySpawnTime => Random.Range(NextEnemySpawnTimeout_Range.x,NextEnemySpawnTimeout_Range.y);

}

