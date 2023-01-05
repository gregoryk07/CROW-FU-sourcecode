using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using TMPro;
/*using UnityEngine.UIElements;*/
using UnityEngine.UI;

public class ShopMenager : MonoBehaviour
{
	[SerializeField] private TMP_Text buyButtonTxt;
	[SerializeField] private Image buyButton;
	[SerializeField] private TMP_Text moneyAmount;
	[SerializeField] private TMP_Text info;
	[SerializeField] private TMP_Text[] PricesText;
	[SerializeField] private TMP_Text[] LvlText;
	[SerializeField] private string[] ItemsInfo;
	[SerializeField] private float[] prices;
	[SerializeField] private int[] currentLevel;
	[SerializeField] private int ChosenItem;
	[SerializeField] private float money;
	
    // Start is called before the first frame update
    void Start()
    {
        buyButtonTxt.enabled = false;
		buyButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmount.text = money.ToString();
		for(int i = 0 ; i < PricesText.Length ; i++)
		{
			PricesText[i].text = prices[i].ToString();
		}
		for(int i = 0 ; i < LvlText.Length ; i++)
		{
			LvlText[i].text = "Level: " + currentLevel[i].ToString();
		}
    }
	
	public void OnItemClick(int item)
    {
		ChosenItem = item;
        info.text = ItemsInfo[item];
		buyButtonTxt.enabled = true;
		buyButton.enabled = true;
    }
	
	public void OnBuyClick()
    {
		if(money >= prices[ChosenItem])
		{
			money -= prices[ChosenItem];
			currentLevel[ChosenItem] += 1;
		}
    }
}