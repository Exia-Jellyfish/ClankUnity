using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int id = 0;
    public CharacterController controller;
    public Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    public float gravity = -9.81f;
    private float jumpHeight = 1.0f;

    public int Id { get => id;}

    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if (move != Vector3.zero && !PauseMenu.GameIsPaused)
        {
            controller.Move(move * playerSpeed * Time.deltaTime);
        }
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime); 

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            GameManager.GetInstance().Test();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Deck deck = GameObject.Find("Homer").GetComponent<Deck>();
            deck.AddCard(GameObject.Find("Gandalf"));
            deck.Shuffle();
            GameObject cardRemoved = deck.RemoveCard();
            deck.DebugLog();
        }
    }
}
