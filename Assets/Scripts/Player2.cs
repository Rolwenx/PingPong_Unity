using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private Rigidbody2D rigidb;
    private Vector2 playerMove;

    public enum Difficulty { Easy, Normal, Difficult, Impossible}
    private Difficulty difficulty;
    private int number_of_hit = 0;
    [SerializeField] private float baseSpeed;
    [SerializeField] private float speedIncrement;
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("isAI", "False");
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
                baseSpeed = 15f;
                speedIncrement = 0.1f;
                break;
            case Difficulty.Normal:
                baseSpeed = 17f;
                speedIncrement = 0.2f;
                break;
            case Difficulty.Difficult:
                baseSpeed = 15f;
                speedIncrement = 0.3f;
                break;
            case Difficulty.Impossible:
                baseSpeed = 50f;
                speedIncrement = 0.3f;
                break;
        }
    }

    void Update(){
        PlayerMove();
    }

    public void PlayerMove(){
        float directionY = Input.GetAxisRaw("Vertical2");

        playerMove = new Vector2(0, directionY).normalized;
    }
        
    private void FixedUpdate(){
        rigidb.velocity = playerMove * (baseSpeed + number_of_hit * speedIncrement);
    }

    private void UpdateRacketSpeed(int numberOfHits)
    {
        number_of_hit = numberOfHits;
    }
}
