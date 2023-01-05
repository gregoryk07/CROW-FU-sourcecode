using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class advancementTrigger : MonoBehaviour
{
    public void TriggerAdvancement(int id)
    {
        AdvancementManager.instance.TriggerAdvancement(id);
    }
}
