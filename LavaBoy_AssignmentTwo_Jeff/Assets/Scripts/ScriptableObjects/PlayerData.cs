using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public float pHealth;
    public float pCurrentDirection;
    //public Rigidbody2D pRigidBody;
    public float pSpeed;
    public float pJumpForce;

    public void ShowDebug()
    {
        Debug.Log("<color=green>Player Current Health: </color>" + pHealth);
    }
}
