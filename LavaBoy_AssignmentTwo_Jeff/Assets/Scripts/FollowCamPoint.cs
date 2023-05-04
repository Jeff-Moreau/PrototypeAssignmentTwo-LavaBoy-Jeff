using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamPoint : MonoBehaviour
{

    private float xLock;
    // Start is called before the first frame update
    void Start()
    {
        xLock = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(xLock, transform.position.y, 0);
    }
}
