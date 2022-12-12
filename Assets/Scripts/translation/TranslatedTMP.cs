using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TranslatedTMP : MonoBehaviour
{
    //only use with static texts
    public TMP_Text text;
    public string plPL;
    public string enUS;

    private void Awake()
    {
        if(text == null)
        {
            text = GetComponent<TMP_Text>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (translateManager.instance.plPL)
        {
            if(plPL.Length > 0)
            {
                text.text = plPL;
            }
            else
            {
                text.text = enUS;
            }
                
        }
        else if (translateManager.instance.enUS)
        {
            text.text = enUS;
        }
        else
        {
            text.text = enUS;
        }
    }
}
