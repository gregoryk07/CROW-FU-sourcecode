using System;
using UnityEngine;

public class debug : MonoBehaviour
{
    public bool DontDestroy = false;

    [Serializable]
    public struct TimeD
    {
        public float currentTime, currentTimeScale, currentDeltaTime;
    }
    [Serializable]
    public struct MouseD
    {
        public Vector2 mousePosition;
        public Vector2 scaleValue;
        public Vector2 scaledMousePosition;
    }

    public TimeD TimeDebug;
    public MouseD MouseDebug;

    private void Awake()
    {
        if (DontDestroy)
        {
            DontDestroyOnLoad(this);
        }
    }

    private void Update()
    {
        TimeDebug.currentDeltaTime = Time.deltaTime;
        TimeDebug.currentTime = Time.time;
        TimeDebug.currentTimeScale = Time.timeScale;
        MouseDebug.mousePosition = Input.mousePosition;
        MouseDebug.scaledMousePosition = MouseDebug.mousePosition / MouseDebug.scaleValue;
    }

}
