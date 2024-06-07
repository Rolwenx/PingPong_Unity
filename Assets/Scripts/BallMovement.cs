using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [SerializeField] private float startSpeed;
    // So that when ball hits, it gains speed and it isn't just continues.
    [SerializeField] private float extraSpeed;
    // This is used to constrain the increase in speed beyond the initial startSpeed.
    [SerializeField] private float maxExtraSpeed;
    public bool player1_start = true;

    private int number_of_hit = 0;
    private Rigidbody2D rigidb;

    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();

        StartCoroutine(LaunchMovement());

    }

    public void ResetBall(){
        rigidb.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);
        number_of_hit = 0;
        
    }

    public IEnumerator LaunchMovement(){
        ResetBall();
        number_of_hit = 0;
        yield return new WaitForSeconds(1);
        // If player 1 start is true, meaning player 1 is starting, the ball will move to the left
        if(player1_start == true){
            MoveBall(new Vector2(-1, 0));
        // Second player, we send ball to the right
        }else{
            MoveBall(new Vector2(1, 0));
        }
    
    }

    public void MoveBall(Vector2 direction_of_ball){

        direction_of_ball = direction_of_ball.normalized;
        // The more hit you get, the more fast the ball is
        float currentSpeed = startSpeed + (number_of_hit * extraSpeed);


        rigidb.velocity = direction_of_ball * currentSpeed;
    }

    public void increaseHitCount(){
        if (number_of_hit * extraSpeed < maxExtraSpeed){
            number_of_hit ++;
        }
    }

}
