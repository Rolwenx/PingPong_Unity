using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{

    public BallMovement ballMovement;
    public ScoreManagement score;

    public GameObject hit_music;
    private SFXSlider sfxSlider;

    private void Start()
    {
        sfxSlider = FindObjectOfType<SFXSlider>(); // Find and store the SFXSlider script
    }



    private void Bounce(Collision2D collision){
        // We get the position of the ball
        Vector3 ballposition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        // This will allow us to know which part of the racket we are hitting
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if(collision.gameObject.name == "Racket 1"){
            positionX = 1;
        }else{
            positionX = -1;
        }

        float positionY = (ballposition.y - racketPosition.y) / racketHeight;
        // If ball get dead center position
        if(positionY == 0){
            positionY = 0.25f;
        }

        ballMovement.increaseHitCount();
        ballMovement.MoveBall(new Vector2(positionX, positionY));


    }
 
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Racket 1" || collision.gameObject.name == "Racket 2"){
            Bounce(collision);

        }
        if(collision.gameObject.name == "Left Border"){
           score.Player2Scores();
           // Since player 2 Scored, player 1 will be the one to start the game next time
           ballMovement.player1_start = true;
           StartCoroutine(ballMovement.LaunchMovement());
        }
        if(collision.gameObject.name == "Right Border"){
            score.Player1Scores();
            // Since player 1 Scored, player 2 will be the one to start the game next time
            ballMovement.player1_start = false;
            StartCoroutine(ballMovement.LaunchMovement());
        }

        // Create the hit music object
        GameObject hitMusicObj = Instantiate(hit_music, transform.position, transform.rotation);
        // Get the AudioSource component from the hit music object
        AudioSource hitMusicAudioSource = hitMusicObj.GetComponent<AudioSource>();
        // If the hit music audio source exists and the SFXSlider script is found
        if (hitMusicAudioSource != null && sfxSlider != null)
        {
            // Set the volume of the hit music audio source based on the stored SFX volume
            hitMusicAudioSource.volume = sfxSlider.getVolume();
        }
        
    }


}
