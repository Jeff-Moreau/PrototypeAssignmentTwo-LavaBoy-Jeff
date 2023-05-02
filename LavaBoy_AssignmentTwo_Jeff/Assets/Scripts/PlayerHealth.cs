using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    private float playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerData.pHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
