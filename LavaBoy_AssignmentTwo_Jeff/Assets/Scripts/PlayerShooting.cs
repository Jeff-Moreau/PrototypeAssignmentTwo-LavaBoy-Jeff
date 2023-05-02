using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private ProjectileData projectileData;
    [SerializeField] private Transform lavaSpitSpawn;

    private GameObject lavaSpit;
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        lavaSpit = playerData.pAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float zAxisRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, zAxisRotation);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(lavaSpit, lavaSpitSpawn.position, Quaternion.identity);
        }
    }
}
