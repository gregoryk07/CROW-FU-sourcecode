using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeDebug : MonoBehaviour
{
    public float TimeScale, DeltaTime, CurrentTime;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update()
    {
        TimeScale = Time.timeScale;
        DeltaTime = Time.deltaTime;
        CurrentTime = Time.time;
    }
    
}
