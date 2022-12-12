using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainLevelLoader : MonoBehaviour
{
    public int sceneIndex = 1;
    public Slider slider;

    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        StartCoroutine(LoadAsychronously(sceneIndex));
    }
    IEnumerator LoadAsychronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;    

            yield return null;
        }
    }
}
