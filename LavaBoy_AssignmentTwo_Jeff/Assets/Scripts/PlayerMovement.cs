using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Rigidbody2D playerRiBo;

    private float playerSpeed;
    private float playerJumpForce;
    private bool playerCanJump;
    private bool playerHitWall;
    private float currentSpeed;
    private bool canMoveRight = true;
    private bool canMoveLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = playerData.pSpeed;
        currentSpeed = playerSpeed;
        playerJumpForce = playerData.pJumpForce;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.D) && canMoveRight)
            {
                transform.position += transform.right * (Time.deltaTime * currentSpeed);
            }

            if (Input.GetKey(KeyCode.A) && canMoveLeft)
            {
                transform.position -= transform.right * (Time.deltaTime * currentSpeed);
            }

        if (Input.GetButtonDown("Jump") && playerCanJump)
        {
            playerRiBo.AddForce(Vector2.up * playerJumpForce);
        }

        if (Input.GetKey(KeyCode.P))
        {
            playerRiBo.gravityScale = -3;
            playerJumpForce = -playerJumpForce;
        }
        if (Input.GetKey(KeyCode.O))
        {
            playerRiBo.gravityScale = 3;
            playerJumpForce = playerJumpForce * 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" && collision.transform.position.x < transform.position.x + 960)
        {
            canMoveRight = false;
        }
        if (collision.gameObject.tag == "Wall" && collision.transform.position.x > transform.position.x + 960)
        {
            canMoveLeft = false;
        }


    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "SolidGround")
        {
            playerCanJump = true;
            Debug.Log("Touching Ground");
            Debug.Log(collision.transform.position.x);
            Debug.Log(transform.position.x + 960);
            Debug.Log(collision.transform.position.y);
            Debug.Log(transform.position.y + 540);
        }
        if (collision.gameObject.name == "Wall")
        {
            playerHitWall = true;
            Debug.Log("Touching WALL");
            Debug.Log(collision.transform.position.x);
            Debug.Log(transform.position.x + 960);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerCanJump = false;
        Debug.Log("NOT Touching Ground");

       if (collision.gameObject.tag == "Wall" && collision.transform.position.x < transform.position.x + 960)
        {
            canMoveRight = true;
        }
        if (collision.gameObject.tag == "Wall" && collision.transform.position.x > transform.position.x + 960)
        {
            canMoveLeft = true;
        }
    }
}
