using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenager : MonoBehaviour
{
	[SerializeField] private GameObject canvas;
	[SerializeField] private int nr;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnMouseOver()
    {
        /*if (Input.GetMouseButtonDown(1))
        {
            canvas.GetComponent<ShopMenager>().RightClicked(nr);
			
        }
		Debug.Log("MouseOver");*/
    }
}
