using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class languageManager : MonoBehaviour
{
    public static languageManager instance;
    public TMP_Dropdown dropdown;
    public int plPL = 1, enUS = 2;

    private void Start()
    {
        if (translateManager.instance.plPL == true)
        {
            dropdown.value = plPL;
        }
        else
        {
            dropdown.value = enUS;
        }
    }
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
    // Update is called once per frame
    void Update()
    {
        if(dropdown.value == 0)
        {
            SetLanguageToPL();
        }
        if(dropdown.value == 1)
        {
            SetLanguageToEnUS();
        }
    }
    public void SetLanguageToPL()
    {
        translateManager.instance.plPL = true;
        translateManager.instance.enUS = false;
    }
    public void SetLanguageToEnUS()
    {
        translateManager.instance.plPL = false;
        translateManager.instance.enUS = true;
    }
}
