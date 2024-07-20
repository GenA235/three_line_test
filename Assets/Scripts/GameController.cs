using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameSettings gameSettings;
    [SerializeField]
    private EnemySpawner EnemySpawner;
    private List<IMovable> movableEnemies = new List<IMovable>();

    [SerializeField]
    private Text needToWin;
    private int NeedEnemiesToWin = 0;

    void Start()
    {
        DamageEventSystem.Instance.EnemyWasKilled.AddListener(EnemyWasKilled);
    }
    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }
    public void StopGame()
    {
       StopAllCoroutines();
       Debug.Log("GameStopeed");
    }

    IEnumerator StartGameCoroutine()
    {
        NeedEnemiesToWin = gameSettings.GetRandomEnemyAmountToWin;

        needToWin.text = "ЕЩЕ " + NeedEnemiesToWin + " ВРАГОВ ДЛЯ ПОБЕДЫ: ";
        while (true)
        {
            var en = EnemySpawner.SpawnRandomEnemyOnRandomPoint();
            if (en is IMovable mEnemy && !movableEnemies.Contains(mEnemy)) movableEnemies.Add(mEnemy);
            yield return new WaitForSeconds(gameSettings.GetRandomEnemySpawnTime);
        }
    }


    public void EnemyWasKilled()
    {
        NeedEnemiesToWin -= 1;
        needToWin.text = "ЕЩЕ " + NeedEnemiesToWin + " ВРАГОВ ДЛЯ ПОБЕДЫ: ";
        if(NeedEnemiesToWin<=0){
            GameStateController.Instance.CurrentState = GameState.Win;
        }
    }

    void FixedUpdate()
    {
        foreach (var mEnemy in movableEnemies)
        {
            mEnemy.Move();
        }
    }


}
