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
        float positionY = (ballposition.y - racketPosition.y) / racketHeight;
        if(collision.gameObject.name == "Player Racket 1"){
            positionX = 1;
        }else{
            positionX = -1;
        }

        ballMovement.increasetHitCount();
        ballMovement.MoveBall(new Vector2(positionX, positionY));

    }
 
    private void OnCollisionDetect(Collision2D collision){
        if(collision.gameObject.name == "Player Racket 1" || collision.gameObject.name == "Racket 2"){
            Bounce(collision);
        }
    }
}
