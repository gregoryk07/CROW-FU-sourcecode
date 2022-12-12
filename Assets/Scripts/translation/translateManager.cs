using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateManager : MonoBehaviour
{
    public static translateManager instance;
    public bool plPL, enUS;


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
        DontDestroyOnLoad(this.gameObject);
        if (Application.systemLanguage == SystemLanguage.Polish)
        {
            plPL = true;
            enUS = false;
        }
        else
        {
            enUS = true;
            plPL = false;
        }
    }
}
