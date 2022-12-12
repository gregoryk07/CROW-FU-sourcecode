using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElements : MonoBehaviour
{
    public static UIElements instance;
    public Slider healthSlider, KiPowerSlider;
    // Start is called before the first frame update
    void Awake()
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
        
    }
}
