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

    private int number_of_hit = 0;
    private Rigidbody2D rigidb;

    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();

        StartCoroutine(LaunchMovement());

    }

    public IEnumerator LaunchMovement(){

        number_of_hit = 0;
        yield return new WaitForSeconds(1);
        MoveBall(new Vector2(-1, 0));
    }

    public void MoveBall(Vector2 direction_of_ball){

        direction_of_ball = direction_of_ball.normalized;
        // The more hit you get, the more fast the ball is
        float currentSpeed = startSpeed + (number_of_hit * extraSpeed);
        Debug.Log("speed: "+ currentSpeed);
        Debug.Log("hit : "+ number_of_hit);


        rigidb.velocity = direction_of_ball * currentSpeed;
    }

    public void increaseHitCount(){
        if (number_of_hit * extraSpeed < maxExtraSpeed){
            number_of_hit ++;
        }
    }

}
