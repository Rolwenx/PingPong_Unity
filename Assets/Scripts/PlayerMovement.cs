using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum Difficulty { Easy, Normal, Difficult, Impossible}
    private Difficulty difficulty;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;

   // Base speed of the racket
    [SerializeField] private float baseSpeed;
    [SerializeField] private float speedIncrement;
    private int number_of_hit = 0;

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
                break;
            case Difficulty.Normal:
                baseSpeed = isAI ? 5.5f : 17f;
                speedIncrement = isAI ? 0.05f : 0.2f;
                break;
            case Difficulty.Difficult:
                baseSpeed = isAI ? 10f : 15f;
                speedIncrement = isAI ? 0.08f : 0.3f;
                break;
            case Difficulty.Impossible:
                baseSpeed = isAI ? 60f : 50f;
                speedIncrement = isAI ? 0.05f : 0.3f;
                break;
        }
    }

    void Update(){

        if(isAI){
            AIMove();
            Debug.Log("AI speed: " + rigidb.velocity.magnitude);

        }
        else{
            PlayerMove();
            Debug.Log("player: " + rigidb.velocity.magnitude);
        }

    }


    public void PlayerMove(){
        // Get the position of the mouse in screen space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Set the y-coordinate of the player's position to match the y-coordinate of the mouse position
        Vector2 playerPosition = new Vector2(transform.position.x, mousePosition.y);
        // Calculate the direction towards the mouse
        // Calculate the direction towards the mouse
        playerMove = (playerPosition - rigidb.position);
        // Update the player's position
        rigidb.MovePosition(playerPosition);
        
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
    private void FixedUpdate()
    {
        rigidb.velocity = playerMove * (baseSpeed + number_of_hit * speedIncrement);
    }

    private void UpdateRacketSpeed(int numberOfHits)
    {
        number_of_hit = numberOfHits;
    }


}
