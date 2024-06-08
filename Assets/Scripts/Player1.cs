using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody2D rigidb;
    private Vector2 playerMove;
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("isAI", "False");
        rigidb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        PlayerMove();
    }

    public void PlayerMove(){
        float directionY = Input.GetAxisRaw("Vertical");

        playerMove = new Vector2(0, directionY).normalized;
    }
        
    private void FixedUpdate(){
        rigidb.velocity = playerMove * speed;
    }

}
