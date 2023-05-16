using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        playerData.pHealthCurrent = playerData.pHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData.pHealthCurrent > playerData.pHealthMax)
        {
            playerData.pHealthCurrent = playerData.pHealthMax;
        }

        if (playerData.pHealthCurrent <= playerData.pHealthMax && playerData.pHealthCurrent > playerData.pHealthSolid)
        {
            playerData.pHealthCurrent -= (Time.deltaTime * playerData.pHealthReductionSpeed);
            //Debug.Log(playerData.pHealthCurrent);
        }
        else if (playerData.pHealthCurrent <= playerData.pHealthSolid)
        {
            playerData.pHealthCurrent = playerData.pHealthMax;
            transform.position = playerData.pStartPosition;
            Debug.Log("You are Dead");
        }
        
        healthText.text = "" + Mathf.Floor(playerData.pHealthCurrent) + "F";
    }
}
