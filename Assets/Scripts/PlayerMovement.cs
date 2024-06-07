using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private bool isAI;
    [SerializeField] private float speed;
    [SerializeField] private GameObject ball;
    private Rigidbody2D rigidb;
    private Vector2 playerMove;

    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();
    }

    void Update(){

        if(isAI){
            AIMove();
        }
        else{
            PlayerMove();
        }
    }

    public void PlayerMove(){
        // Get the position of the mouse in screen space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Set the y-coordinate of the player's position to match the y-coordinate of the mouse position
        Vector2 playerPosition = new Vector2(transform.position.x, mousePosition.y);
        // Calculate the direction towards the mouse
        playerMove = (playerPosition - rigidb.position).normalized;
    }
        

    private void AIMove()
    {
        // If the ball is above the AI racket
        if(ball.transform.position.y > transform.position.y + 0.5f){
            playerMove = new Vector2(0,1);
        }
        // If the ball is below the racket
        else if(ball.transform.position.y < transform.position.y - 0.5f ){
            playerMove = new Vector2(0,-1);
        }
        // If the ball is neither
        else{
            playerMove = new Vector2(0,0);
        }
    }

    private void FixedUpdate(){
        rigidb.velocity = playerMove * speed;
    }
}
