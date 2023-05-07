using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Rigidbody2D playerRiBo;

    private bool playerCanJump;
    private bool playerOnGround;
    private bool playerHitWall;
    private bool canMoveRight = true;
    private bool canMoveLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        playerData.pSpeedCurrent = playerData.pSpeed;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.D) && canMoveRight)
            {
                transform.position += transform.right * (Time.deltaTime * playerData.pSpeedCurrent);
            }

            if (Input.GetKey(KeyCode.A) && canMoveLeft)
            {
                transform.position -= transform.right * (Time.deltaTime * playerData.pSpeedCurrent);
            }

        if (Input.GetButtonDown("Jump") && playerCanJump)
        {
            playerRiBo.AddForce(Vector2.up * playerData.pJumpForce);
        }

        if (Input.GetMouseButtonDown(1) && playerRiBo.gravityScale >= 3 && playerOnGround)
        {
            playerRiBo.gravityScale = -3;
        }

        if (playerRiBo.gravityScale <= 0)
        {
            playerRiBo.gravityScale += Time.deltaTime;
        }
        else if (playerRiBo.gravityScale >=0 && playerRiBo.gravityScale < 3)
        {
            playerRiBo.gravityScale = 3;
        }

        if (playerData.pHealthCurrent <= 2100 && playerData.pHealthCurrent > 2000)
        {
            playerData.pSpeedCurrent = playerData.pSpeed - (playerData.pSpeed * 0.1f);
        }
        else if (playerData.pHealthCurrent <= 2000 && playerData.pHealthCurrent > 1900)
        {
            playerData.pSpeedCurrent = playerData.pSpeed - (playerData.pSpeed * 0.225f);
        }
        else if (playerData.pHealthCurrent <= 1900 && playerData.pHealthCurrent > 1850)
        {
            playerData.pSpeedCurrent = playerData.pSpeed - (playerData.pSpeed * 0.35f);
        }
        else if (playerData.pHealthCurrent <= 1850)
        {
            playerData.pSpeedCurrent = playerData.pSpeed - (playerData.pSpeed * 0.5f);
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
            playerOnGround = true;
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
        playerOnGround = false;
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
