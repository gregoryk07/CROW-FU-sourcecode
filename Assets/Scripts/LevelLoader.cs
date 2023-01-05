using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    public GameObject LoadingScreen;
    public Slider slider;
    public TMP_Text progresstext;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }
    public void LoadLevel(int sceneIndex)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadAsychronously(sceneIndex));
    }
    IEnumerator LoadAsychronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;    
            progresstext.text = (progress / 100f).ToString() + "%";

            yield return null;
        }
    }
}
