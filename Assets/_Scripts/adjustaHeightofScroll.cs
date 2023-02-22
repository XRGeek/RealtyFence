using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class adjustaHeightofScroll : MonoBehaviour
{
	public 	Vector2 singleSize;



	public ScrollRect scroll;

	private void Start()
	{
		singleSize = scroll.content.sizeDelta;
	}

	private void Update()
	{
		//UpdateRectSize();
	}
	public void UpdateRectSize()
	{
		int c = 0;

		for (int i = 0; i < scroll.content.childCount; i++) 
		{
			if (scroll.content.GetChild(i).gameObject.activeInHierarchy) 
			{
				c++;
			}
		}

		Debug.Log("Active children are " + c);
		int y =	(int) Mathf.Ceil((float) (c / 2.0f));
		scroll.content.sizeDelta = new Vector2(singleSize.x, +singleSize.y * y);
	}

}
