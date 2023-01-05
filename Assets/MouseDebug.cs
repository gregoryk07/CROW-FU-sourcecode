using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDebug : MonoBehaviour
{
    public Vector2 mousePos;
    public float timesSth = 1f;

    private void Update()
    {
        mousePos = new Vector2((Input.mousePosition.x - (Screen.width/2)) * timesSth, (Input.mousePosition.y - (Screen.height/2)) * timesSth);
    }
}
