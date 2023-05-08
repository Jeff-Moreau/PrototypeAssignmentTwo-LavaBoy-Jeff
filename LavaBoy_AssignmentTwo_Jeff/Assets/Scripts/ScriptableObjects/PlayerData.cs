using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(menuName = "Player Data", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public float pHealthMax = 2200;
    public float pHealthSolid = 1800;
    public float pHealthCurrent;
    public float pCurrentDirection;
    public float pSpeed = 6;
    public float pSpeedCurrent;
    public float pJumpForce;
    public float pHealthReductionSpeed = 3;
    public GameObject pAmmo;
    public Vector3 pStartPosition;
    public float pShotTimer;

    public void ShowDebug()
    {
        Debug.Log("<color=green>Player Current Health: </color>" + pHealthCurrent);
    }
}
