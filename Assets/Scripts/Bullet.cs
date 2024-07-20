using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direcction;
    private Vector3 startPos;
    private float bulletSpeed;
    private float distance;
    public float BulletDamage;
    public void Initialize(Vector3 _startPos, Vector3 _direction, GameSettings _settings)
    {
        direcction = _direction;
        bulletSpeed = _settings.PlayerBulletSpeed;
        startPos = _startPos;
        transform.position = startPos;
        distance = _settings.PlayerAttackRadius;
        BulletDamage = _settings.PlayerDamageValue;
        gameObject.SetActive(true);
    }
    void FixedUpdate()
    {
        transform.Translate(direcction * bulletSpeed * Time.deltaTime);
        var dist = Vector2.Distance(transform.position, startPos);
        if (dist >= distance)
        ReturnBulletToPool();
    }

    public void ReturnBulletToPool(){
BulletsPool.Instance.ReturnBullet(this);
    }
}
