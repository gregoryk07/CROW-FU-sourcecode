using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Advancement : MonoBehaviour
{
    public Sprite icon;
    new public string name;
    public string description;
    public Color color;
    public Image background;
    public Image iconImage;
    public float showTime;
    public TMP_Text TMP_name;
    public TMP_Text TMP_desc;
    public float startTime;
    public float showingTime;
    public float posY;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.unscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        TMP_name.text = name;
        TMP_desc.text = description;
        background.color = color;
        iconImage.sprite = icon;
        if(startTime + showTime < Time.unscaledTime)
        {
            Destroy(this.gameObject);
        }
    }
}
