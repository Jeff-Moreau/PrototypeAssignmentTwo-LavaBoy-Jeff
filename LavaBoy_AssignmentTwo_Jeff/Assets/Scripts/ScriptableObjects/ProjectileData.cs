using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile Data", fileName = "ProjectileData")]
public class ProjectileData : ScriptableObject
{
    public float projectileSpeed;
    public int projectileDamage;
}
