using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Rigidbody2D playerRiBo;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJumpForce;
    private float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = playerData.pSpeed;
        currentSpeed = playerSpeed;
        playerJumpForce = playerData.pJumpForce;
        //playerRiBo = playerData.pRigidBody;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * currentSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * currentSpeed;
        }

        if (Input.GetButtonDown("Jump"))
        {
            playerRiBo.AddForce(Vector2.up * playerJumpForce);
        }
    }
}
