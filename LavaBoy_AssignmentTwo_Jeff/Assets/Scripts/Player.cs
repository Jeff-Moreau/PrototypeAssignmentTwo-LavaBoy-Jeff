using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Transform lavaSpitSpawn;
    [SerializeField] private bool showDebugs = false;

    private GameObject lavaSpit;
    private float playerHealth;
    private Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerData.pHealth;
        lavaSpit = playerData.pAmmo;
    }

    // Update is called once per frame
    void Update()
    {

        if (showDebugs)
        {
            playerData.ShowDebug();
            Debug.Log("Player Current Position: " + currentPosition);
        }
    }
}
