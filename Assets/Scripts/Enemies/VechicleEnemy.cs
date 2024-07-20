using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VechicleEnemy : Enemy, IMovable, IDamagable, IDamager
{
    public  ViewDamage ViewDamage;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    private float moveSpeed = 2;

    public float DamagePower { get => _damagePower; set => _damagePower = value; }
    private float _damagePower = 2;

    public float Health { get => _health; set => _health = value; }
    private float _health = 2;
    private float start_health = 2;

    public void Move()
    {
        if (!gameObject.activeSelf)
            return;

        transform.Translate(MoveSpeed * Time.deltaTime * -Vector2.up);
    }


    public override void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                Damage();
                break;
            case "Bullet":
                var bul = collision.GetComponent<Bullet>();
                TakeDamage((int)bul.BulletDamage);
                bul.ReturnBulletToPool();
                break;
        }
    }

    public void TakeDamage(int value)
    {
        Health -= value;
        ViewDamage.Invoke(Health / start_health, "");
        if (Health <= 0)
        {
            EnemyPool.Instance.ReturnEnemy(this);
            ViewDamage.Invoke(1, "");
            DamageEventSystem.Instance.EnemyWasKilled.Invoke();
        }
    }

    public void Damage()
    {
        DamageEventSystem.Instance.TriggerPlayerDamageEvent((int)_damagePower);
        EnemyPool.Instance.ReturnEnemy(this);
    }

    public override void Initialize(EnemyStatsContainer enemyStats)
    {
        MoveSpeed = enemyStats.GetRandomSpeed;
        DamagePower = enemyStats.EnemyDamageAmount;
        Health = start_health = enemyStats.EnemyHealth;
        ViewDamage.Invoke(1, "");
    }
}