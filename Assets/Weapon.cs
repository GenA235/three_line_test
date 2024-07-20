using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public WeaponMode WeaponMode;
    [SerializeField]
    private GameSettings gameSettings;
    public BulletsPool BulletsPool;
    public EnemyPool EnemyPool;

    public LayerMask layerMask;
    private float shotDistance;
    private float attackFrequency;

    private float currentDistance;
    private float timeFromLatestShot;
    private Enemy targetEnemy;

    
    void Start()
    {
        shotDistance = gameSettings.PlayerAttackRadius;
        attackFrequency = gameSettings.PlayerAttackFrequency;
    }
    void Update()
    {
        if(WeaponMode!= WeaponMode.Around) return;
        targetEnemy = null;
        currentDistance = Mathf.Infinity;
        foreach (var enemy in EnemyPool.enemiesInGame)
        {
            var dist = Vector2.Distance(transform.position,enemy.transform.position);
            if (dist < shotDistance && dist < currentDistance)
            {
                targetEnemy = enemy;
                currentDistance = dist;
            }
        }
        if (targetEnemy == null) return;

        if (Time.time > (timeFromLatestShot + attackFrequency))
        {
            var bullet = BulletsPool.GetBullet();
            bullet.Initialize(transform.position, (targetEnemy.transform.position - transform.position).normalized, gameSettings);
            timeFromLatestShot = Time.time;
        }

    }

    void FixedUpdate()
    {
        if (WeaponMode != WeaponMode.ForwardOnly) return;
        targetEnemy = null;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, gameSettings.PlayerAttackRadius, layerMask);
   
      
        if (hit.collider == null)
            return;
        targetEnemy = hit.collider.GetComponent<Enemy>();

        if (Time.time > (timeFromLatestShot + attackFrequency))
        {
            var bullet = BulletsPool.GetBullet();
            bullet.Initialize(transform.position, (Vector2.up), gameSettings);
            timeFromLatestShot = Time.time;
        }
    }

    public void Attack(Vector3 Direction){

    }
}

public enum WeaponMode
{
ForwardOnly,
Around
}
