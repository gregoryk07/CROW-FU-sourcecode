using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public Transform creditsGameObject;
    public float scrollSpeed = 10f;
    public float upYPos;
    public float downYPos;
    bool didScroll = false;
    public KeyCode skipButton = KeyCode.Escape;
    // Start is called before the first frame update
    void Start()
    {
        creditsGameObject.localPosition = new Vector3(creditsGameObject.localPosition.x, upYPos, creditsGameObject.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (creditsGameObject.position.y < downYPos)
        {
            creditsGameObject.position += new Vector3(0, scrollSpeed * Time.fixedUnscaledDeltaTime, 0);
        }
        else
        {
            if (!didScroll)
            {
                Debug.Log("Done scrolling credits!");
            }
        }
        if (Input.GetKeyDown(skipButton))
        {
            LevelLoader.instance.LoadLevel(1);
        }
    }
}
