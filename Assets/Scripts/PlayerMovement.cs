using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum Difficulty { Easy, Normal, Difficult, Impossible}
    private Difficulty difficulty;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;
    [SerializeField] private bool aiVsAiMode = false;

   // Base speed of the racket
    [SerializeField] private float baseSpeed;
    [SerializeField] private float speedIncrement;
    private int number_of_hit = 0;
    [SerializeField] private float reactionTime = 0.5f; // Adjustable reaction time

    private Rigidbody2D rigidb;
    private Vector2 playerMove;
    

    // Start is called before the first frame update
    void Start()
    {

        if(isAI){
            PlayerPrefs.SetString("isAI", "True");
        }else{
            PlayerPrefs.SetString("isAI", "False");
        }
        
        rigidb = GetComponent<Rigidbody2D>();
        SetDifficultyFromPrefs();
        SetDifficultyParameters();
        BallMovement.OnBallHit += UpdateRacketSpeed;

    }

    void OnDestroy()
    {
        BallMovement.OnBallHit -= UpdateRacketSpeed; // Unsubscribe from the event
    }

    private void SetDifficultyFromPrefs()
    {
        string difficultyString = PlayerPrefs.GetString("Difficulty", "Normal");
        switch (difficultyString)
        {
            case "Easy":
                difficulty = Difficulty.Easy;
                break;
            case "Normal":
                difficulty = Difficulty.Normal;
                break;
            case "Difficult":
                difficulty = Difficulty.Difficult;
                break;
            case "Impossible":
                difficulty = Difficulty.Impossible;
                break;
            default:
                difficulty = Difficulty.Normal;
                break;
        }
    }

    private void SetDifficultyParameters()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                baseSpeed = isAI ? 2.8f : 15f;
                speedIncrement = isAI ? 0.03f : 0.1f;
                reactionTime = 0.5f;
                break;
            case Difficulty.Normal:
                baseSpeed = isAI ? 5.5f : 17f;
                speedIncrement = isAI ? 0.05f : 0.2f;
                reactionTime = 0.3f;
                break;
            case Difficulty.Difficult:
                baseSpeed = isAI ? 10f : 15f;
                speedIncrement = isAI ? 0.08f : 0.3f;
                reactionTime = 0.2f;
                break;
            case Difficulty.Impossible:
                baseSpeed = isAI ? 60f : 50f;
                speedIncrement = isAI ? 0.05f : 0.3f;
                reactionTime = 0.1f;
                break;
        }
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
        playerMove = (playerPosition - rigidb.position);
        // Update the player's position
        rigidb.MovePosition(playerPosition);
        
    }
        
    private void AIMove()
    {
        if(aiVsAiMode){

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
        else{
            
            // Here we calculate a prediction of the ball position based on its velocity and the reaction time of AI
            Vector2 predictedBallPosition = (Vector2)ball.transform.position + ball.GetComponent<Rigidbody2D>().velocity * reactionTime;


            // We tweak the reaction time based on ball distance
            float adjustedReactionTime = Mathf.Clamp(reactionTime / Vector2.Distance(predictedBallPosition, transform.position), 0.1f, reactionTime);

            // We now caculate the direction of the AI towards to predicted ball position
            Vector2 directionToBall = ((Vector2)predictedBallPosition - (Vector2)transform.position).normalized;


            // We adjust the AI move based on the prediction of the ball position
            playerMove = new Vector2(0, Mathf.Clamp(directionToBall.y, -1f, 1f));

            // We apply the reaction time adjusted
            StartCoroutine(DelayedAIMove(adjustedReactionTime));
        }

    }

    private IEnumerator DelayedAIMove(float delay)
    {
        yield return new WaitForSeconds(delay);
        rigidb.velocity = playerMove * (baseSpeed + number_of_hit * speedIncrement);
    }


    private void FixedUpdate()
    {
        if(aiVsAiMode){
            rigidb.velocity = playerMove * (baseSpeed + number_of_hit * speedIncrement);
        }
        else
        {
            if(!isAI){
                rigidb.velocity = playerMove * (baseSpeed + number_of_hit * speedIncrement);
            }
        }
    }

    private void UpdateRacketSpeed(int numberOfHits)
    {
        number_of_hit = numberOfHits;
    }


}
