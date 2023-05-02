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
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * (Time.deltaTime * currentSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * (Time.deltaTime * currentSpeed);
        }

        if (Input.GetButtonDown("Jump") && playerCanJump)
        {
            playerRiBo.AddForce(Vector2.up * playerJumpForce);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "SolidGround")
        {
            playerCanJump = true;
            Debug.Log("Touching Ground");
        }
        if (collision.gameObject.name == "Wall")
        {
            playerHitWall = true;
            Debug.Log("Touching WALL");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerCanJump = false;
        Debug.Log("NOT Touching Ground");
    }
}
