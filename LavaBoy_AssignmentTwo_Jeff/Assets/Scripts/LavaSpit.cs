using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSpit : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private ProjectileData projectileData;
    [SerializeField] private Rigidbody2D lavaRigidBody;

    private float lavaSpeed;
    private Vector3 mousePos;
    private Vector3 lavaSpitDirection;
    private Vector3 lavaSpitRotation;
    private float rotation;

    // Start is called before the first frame update
    void Start()
    {
        lavaSpeed = projectileData.projectileSpeed;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lavaSpitDirection = mousePos - transform.position;
        lavaSpitRotation = transform.position - mousePos;
        lavaRigidBody.velocity = new Vector2(lavaSpitDirection.x, lavaSpitDirection.y).normalized * lavaSpeed;
        rotation = Mathf.Atan2(lavaSpitRotation.y, lavaSpitRotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 0)
        {
            Destroy(gameObject);
        }
    }
}
