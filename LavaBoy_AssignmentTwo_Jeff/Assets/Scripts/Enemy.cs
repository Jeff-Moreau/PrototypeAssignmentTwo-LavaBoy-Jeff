using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    [SerializeField] PlayerData playerData;
    [SerializeField] GameObject thePlayer;

    [SerializeField] public float enemyHealth;

    private float moveSpeed;
    private Vector3 myPosition;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        moveSpeed = 0;
        enemyHealth = enemyData.eHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        myPosition = new Vector3(transform.position.x, transform.position.y, 0);
        float move = moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, playerData.pCurrentPosition) <= 5.5f)
        {
            Debug.Log(Vector3.Distance(playerData.pCurrentPosition, transform.position));
            moveSpeed = 5;
            transform.position = Vector3.MoveTowards(myPosition, playerData.pCurrentPosition, move);
        }
        else if (Vector3.Distance(transform.position, playerData.pCurrentPosition) >= 5.5f)
        {
            transform.position = Vector3.MoveTowards(myPosition, initialPosition, move);
            moveSpeed = 3;
        }
        else if (myPosition.x == initialPosition.x)
        {
            myPosition = initialPosition;
            moveSpeed = 0;
        }
    }
}
