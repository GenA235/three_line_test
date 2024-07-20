using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameSettings gameSettings;
    public CameraBounds CameraBounds;
    public Transform PlayerCharacter;


    void Update()
    {
        if (GameStateController.Instance.CurrentState != GameState.Game) return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f) * gameSettings.PlayerMovementSpeed * Time.deltaTime;
        Vector3 newPosition = PlayerCharacter.position + movement;

        newPosition = CameraBounds.GetClampedPosition(newPosition);

        PlayerCharacter.position = newPosition;
    }



    public void PlayerMove()
    {

    }
}
