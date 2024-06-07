using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{

    public BallMovement ballMovement;

    private void Bounce(Collision2D collision){
        // We get the position of the ball
        Vector3 ballposition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        // This will allow us to know which part of the racket we are hitting
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if(collision.gameObject.name == "Player Racket 1"){
            positionX = 1;
        }else{
            positionX = -1;
        }

        float positionY = (ballposition.y - racketPosition.y) / racketHeight;
        ballMovement.increaseHitCount();
        ballMovement.MoveBall(new Vector2(positionX, positionY));

    }
 
    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("hi");
        if(collision.gameObject.name == "Player Racket 1" || collision.gameObject.name == "Racket 2"){
            Bounce(collision);
        }
    }
}
