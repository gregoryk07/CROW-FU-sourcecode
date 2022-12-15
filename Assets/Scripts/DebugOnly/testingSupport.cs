using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testingSupport : MonoBehaviour
{
    public GameObject langManager;
    // Start is called before the first frame update
   void Awake()
    {
        langManager = GameObject.Find("Translation");
        if(langManager == null)
        {
            Debug.Log("Key feature no found :/. Returning to startLoader level...");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync(0);
        }
    }

        // Update is called once per frame
    void Update()
    {
        langManager = GameObject.Find("Translation");
    }
}
