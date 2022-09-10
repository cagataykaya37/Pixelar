using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    public float moveSpeed;
    public float jump;
    float xMove;
    public bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        //{
        //    playerRB.velocity = new Vector2(playerRB.velocity.x, jump);
        //    //playerRB.AddForce (new Vector2(0,2) * jump);  - çalýþmadý      
        //    isGrounded = false;
        //}


    }

    private void FixedUpdate()
    {
        //xMove = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2(xMove * moveSpeed, playerRB.velocity.y);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "SurfaceBox")
        {
            isGrounded = true;
        }

    }


    public void Jump()
    {
        if (isGrounded) 
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jump);
            SoundManage.PlayAudio("jump");
            //playerRB.AddForce (new Vector2(0,2) * jump);  - çalýþmadý      
            isGrounded = false;
        }
        
    }

    public void LeftMove() 
    {
        xMove = -1;
    }

    public void RightMove()
    {
        xMove = 1;
    }

    public void StopMove() 
    {
        xMove = 0;
    }

}
    



