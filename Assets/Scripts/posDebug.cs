using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posDebug : MonoBehaviour
{
    public Vector3 position;

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
    }
}
