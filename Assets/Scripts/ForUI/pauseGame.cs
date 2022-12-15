using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour
{
    public bool doStopTime = true;
    public GameObject pauseMenu, mainMenu, gameUI;
    public GameObject[] otherUIPanels;
    public bool canPause = true;
    bool isPaused = false;
    float timeAtPause = 1;

    private void Awake()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                if (canPause)
                {
                    Pause();
                    Debug.Log("Paused by user.");
                }
                else
                {
                    Debug.Log("User attempted to pause but canPause is set to false...");
                }
            }
            else
            {
                Resume();
                Debug.Log("Unpaused by user.");
            }
        }

        pauseMenu.SetActive(isPaused);
        
    }

    public void Pause()
    {
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        timeAtPause = Time.timeScale;
        if (doStopTime)
        {
            Time.timeScale = 0;
        }
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
        timeAtPause = Time.timeScale;
        
    }
    public void Resume()
    {
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (doStopTime)
        {
            Time.timeScale = 1;
        }
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
        if(otherUIPanels.Length != 0)
        {
            for (int i = 0; i < otherUIPanels.Length; i++)
            {
                otherUIPanels[i].SetActive(false);
            }
        }
    }

    public void GoToMenu()
    {
        curSaveInfo.instance.SaveGame();
        LevelLoader.instance.LoadLevel(1);
    }

    public void Quit()
    {
        curSaveInfo.instance.SaveGame();
        Application.Quit();
    }
    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            Pause();
        }
    }

}
