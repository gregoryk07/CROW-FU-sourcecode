using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class valueToText : MonoBehaviour
{
    public float offset = 80f;
    public Slider slider;
    public TMP_Text text;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        x = slider.value + offset;
        text.text = x.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        x = slider.value + offset;
        text.text = x.ToString("F1");
    }
}
