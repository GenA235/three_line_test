using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DamageEvent : UnityEvent<int> { }
[System.Serializable]
public class ViewDamage : UnityEvent<float, string> { }
public class DamageEventSystem : MonoBehaviour
{
    public UnityEvent EnemyWasKilled;
    public static DamageEventSystem Instance;

    public DamageEvent OnPlayerDamageTaken;

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

        OnPlayerDamageTaken ??= new DamageEvent();
    }

    public void TriggerPlayerDamageEvent(int damageAmount)
    {
        OnPlayerDamageTaken?.Invoke(damageAmount);
    }
}