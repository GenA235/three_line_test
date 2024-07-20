using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    public static GameStateController Instance;
    [SerializeField]
    private GameObject awaitStartPannel;
    [SerializeField]
    private GameObject gamePannel;
    [SerializeField]
    private Text awaitStartText;
    [SerializeField]
    private Text buttonText;
    private Button StartButton;
    public UnityEvent GameStarted;
    public UnityEvent Lose;
    public UnityEvent Win;


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

    }

    void Start(){
        CurrentState = GameState.AwaitStart;
        StartButton = buttonText.GetComponentInParent<Button>();
        StartButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked(){
        CurrentState = GameState.Game;
    }

    private GameState currentState;
    public GameState CurrentState
    {
        get => currentState;
        set
        {
            currentState = value;
            switch (value)
            {
                case GameState.AwaitStart:
                    awaitStartPannel.gameObject.SetActive(true);
                    gamePannel.SetActive(false);
                    awaitStartText.text = "НАЖМИТЕ СТАРТ ЧТОБЫ НАЧАТЬ ИГРУ";
                    buttonText.text = "СТАРТ";
                    //GameStarted.Invoke();

                    break;
                case GameState.Game:
                    awaitStartPannel.gameObject.SetActive(false);
                    gamePannel.SetActive(true);
                    GameStarted.Invoke();
                    break;
                case GameState.Win:
                    awaitStartPannel.gameObject.SetActive(true);
                    gamePannel.SetActive(false);
                    awaitStartText.text = "ПОБЕДА";
                    buttonText.text = "РЕСТАРТ";
                    Win.Invoke();
                    break;
                case GameState.Lose:
                    awaitStartPannel.gameObject.SetActive(true);
                    gamePannel.SetActive(false);
                    awaitStartText.text = "ПОРАЖЕНИЕ";
                    buttonText.text = "РЕСТАРТ";
                    Lose.Invoke();
                    break;
            }
        }
    }



}
public enum GameState
{
    AwaitStart,
    Game,
    Win,
    Lose

}