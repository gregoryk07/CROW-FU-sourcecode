using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleVisibility : MonoBehaviour
{
    public void ToggleVisibility(GameObject _Object)
    {
        _Object.SetActive(!_Object.active);
    }
}
