using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public enum Difficulty { Easy, Normal, Difficult, Impossible}
    private Difficulty difficulty;

    [SerializeField] private float startSpeed;
    [SerializeField] private float extraSpeed;
    // So that when ball hits, it gains speed and it isn't just continues.
    //[SerializeField] private float extraSpeed;
    // This is used to constrain the increase in speed beyond the initial startSpeed.
    //[SerializeField] private float maxExtraSpeed;
    public bool player1_start = true;
    private float currentSpeed;

    private int number_of_hit = 0;
    private Rigidbody2D rigidb;

    // Event to notify when the ball is hit
    public delegate void BallHit(int numberOfHits);
    public static event BallHit OnBallHit;


    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();
        SetDifficultyFromPrefs();
        SetDifficultyParameters();
        StartCoroutine(LaunchMovement());


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
                startSpeed = 10f;
                extraSpeed = 0.1f;
                break;
            case Difficulty.Normal:
                startSpeed = 12f;
                extraSpeed = 0.2f;
                break;
            case Difficulty.Difficult:
                startSpeed = 20f;
                extraSpeed = 0.3f;
                break;
            case Difficulty.Impossible:
                startSpeed = 30f;
                extraSpeed = 0.8f;
                break;
        }
    }

    public void ResetBall(){
        currentSpeed = startSpeed;
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
        currentSpeed = startSpeed + (number_of_hit * extraSpeed);

        rigidb.velocity = direction_of_ball * currentSpeed;
    }

    public void increaseHitCount()
    {
        number_of_hit++;
        OnBallHit?.Invoke(number_of_hit); // Trigger the event with the number of hits
    }

    void Update(){
        Debug.Log(currentSpeed);
    }
}
