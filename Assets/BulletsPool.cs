using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    private Queue<Bullet> pool = new Queue<Bullet>();
    public Bullet bulletPrefab;
    public static BulletsPool Instance;
    public int initialPoolSize = 100;

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
InitializePool();
    }

    public  void InitializePool()
    {
        for (int i = 0;  i < initialPoolSize; i++)
        {
            var bul = Instantiate(bulletPrefab, bulletPrefab.transform.parent);
            bul.gameObject.SetActive(false);
            pool.Enqueue(bul);    
        }        
    }

      public Bullet GetBullet()
    {
  
            Bullet obj = pool.Dequeue();
            //obj.gameObject.SetActive(true);
            return obj;    
    }

     public void ReturnBullet(Bullet obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}
