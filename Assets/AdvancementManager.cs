using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvancementManager : MonoBehaviour
{
    [HideInInspector] public static AdvancementManager instance;
    public float AdvancementShowTime = 5f;
    public GameObject AdvancementPrefab;
    public Sprite[] AdvancementIcon;
    public string[] AdvancementName = { "defaultName" };
    public string[] AdvancementDesc = { "defaultDescription" };
    public Color[] BackgroundColor = { new Color(0, 0, 0, 255) };

    // Start is called before the first frame update
    void Start()
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
    }

    public void TriggerAdvancement(int id)
    {
        if (id < AdvancementName.Length)
        {
            GameObject _advanc_G = Instantiate(AdvancementPrefab);
            Advancement _advanc = _advanc_G.GetComponent<Advancement>();
            _advanc.name = AdvancementName[id];
            _advanc.description = AdvancementDesc[id];
            _advanc.icon = AdvancementIcon[id];
            _advanc.color = BackgroundColor[id];
        }
        else
        {
            Debug.LogWarning($"Advancement id out of range! ({id} out of {AdvancementName.Length})");
        }
    }
}
