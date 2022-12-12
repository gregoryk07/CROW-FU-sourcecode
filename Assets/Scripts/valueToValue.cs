using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class valueToValue : MonoBehaviour
{
    public Slider sliderFloat;
    public Slider sliderInt;
    

    // Update is called once per frame
    void Update()
    {
        sliderInt.value = sliderFloat.value-0.49f;
    }
}
