using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public float pHealth;
    public float pCurrentDirection;
    public float pSpeed;
    public float pJumpForce;
    public GameObject pAmmo;

    public void ShowDebug()
    {
        Debug.Log("<color=green>Player Current Health: </color>" + pHealth);
    }
}
