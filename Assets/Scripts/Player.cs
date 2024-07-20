using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]

public class Player : MonoBehaviour, IDamagable
{
    public  ViewDamage ViewDamage;
    public GameSettings GameSettings;
    public float Health { get => health; set => health = value; }
    private float health = 100;
    private float start_health = 100;
    public void TakeDamage(int amount)
    {
       Health -= amount;
        ViewDamage.Invoke(Health/start_health, "ХП ИГРОКА: " + Health);
        if (Health <= 0)
        {
          GameStateController.Instance.CurrentState = GameState.Lose;
        }
    }
    public void SetPlayerHP()
    {
        health = start_health = GameSettings.PlayerHealth;
        ViewDamage.Invoke(Health/start_health, "ХП ИГРОКА: " + Health);
    }

    private void OnEnable()
    {
        DamageEventSystem.Instance.OnPlayerDamageTaken.AddListener(TakeDamage);
    }

    private void OnDisable()
    {
        DamageEventSystem.Instance.OnPlayerDamageTaken.RemoveListener(TakeDamage);
    }



    void Update()
    {
        
    }
}
