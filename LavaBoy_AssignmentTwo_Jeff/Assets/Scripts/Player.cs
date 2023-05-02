using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private float playerHealth;
    [SerializeField] private bool showDebugs = false;

    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerData.pHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (showDebugs)
        {
            playerData.ShowDebug();
        }
    }
}
