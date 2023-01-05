using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayAdvancementInfo : MonoBehaviour
{
    public int AdvancementId = 0;
    public TMP_Text advancementText;
    public TMP_Text advancementDescription;
    public TMP_Text advancementDate;
    public Image advancementImage, PreciseImage;
    public Sprite lockedIcon;
    public GameObject showMorePanel;
    public TMP_Text PreciseName, PreciseDesc, PreciseDate, PreciseHidden;
    public bool alreadyTriggeredd;
    public bool isOk;

    string advText, advDesc, advDate;

    // Update is called once per frame
    void Update()
    {
        isOk = (AdvancementId < AdvancementManager.instance.AdvancementName.Length);
        if (isOk)
        {

            advText = AdvancementManager.instance.AdvancementName[AdvancementId];
            advDesc = AdvancementManager.instance.AdvancementDesc[AdvancementId];
            advDate = AdvancementManager.instance.AdvancementDate[AdvancementId];

            if (AdvancementManager.instance.alreadyTriggered[AdvancementId])
            {
                alreadyTriggeredd = true;
                advancementImage.sprite = AdvancementManager.instance.AdvancementIcon[AdvancementId];
                advancementDate.text = advDate;
                advancementDescription.text = advDesc;
                advancementText.text = advText;
            }
            else
            {
                alreadyTriggeredd = false;
                advancementImage.sprite = lockedIcon;
                if (AdvancementManager.instance.hiddenAdvancement[AdvancementId])
                {
                    advancementText.text = "Advancement Locked";
                    advancementDescription.text = "";
                    advancementDate.text = "Didn't unlock yet";

                }
                else
                {
                    advancementDescription.text = advDesc;
                    advancementText.text = advText;
                    advancementDate.text = "Didn't unlock yet";
                }
            }
        }
        else
        {
            advancementDate.text = "";
            advancementDescription.text = "";
            advancementText.text = "Advancement Not Found!";
            advancementImage.sprite = lockedIcon;
        }
    }
    public void ShowMore()
    {
        showMorePanel.SetActive(true);
        if (isOk)
        {
            PreciseImage.sprite = AdvancementManager.instance.AdvancementIcon[AdvancementId];
            PreciseDate.text = AdvancementManager.instance.AdvancementDate[AdvancementId];
            PreciseDesc.text = AdvancementManager.instance.AdvancementDesc[AdvancementId];
            PreciseName.text = AdvancementManager.instance.AdvancementName[AdvancementId];
            if (AdvancementManager.instance.hiddenAdvancement[AdvancementId])
            {
                PreciseHidden.text = "Hidden";
            }
            else
            {
                PreciseHidden.text = "Visible";
            }

        }
        else
        {
            advancementImage.sprite = lockedIcon;
            PreciseDate.text = "Didn't unlock yet";
            if (alreadyTriggeredd)
            {
                PreciseName.text = "Advancement Locked";
                PreciseDate.text = "";
                PreciseDesc.text = "";
                PreciseHidden.text = "Hidden";

            }
            else
            {
                PreciseName.text = advText;
                PreciseDate.text =advDate;
                PreciseDesc.text = advDesc;
                PreciseHidden.text = "visible";
            }
        }
    }
}
