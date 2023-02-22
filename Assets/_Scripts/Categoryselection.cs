using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Categoryselection : MonoBehaviour
{

	public TMP_Text T_horizontal;
	public TMP_Text T_vertical;
	public Image I_glowfire;
	public Image I_xylnax;


	public enum category
	{
		horizontal,  vertical,  glowfire , xylnax
	}
	public productdetail[] products; 

	public void OpenCategoryorProduct(category cat) 
	{
	T_horizontal.gameObject.SetActive(false);
	 T_vertical.gameObject.SetActive(false);
	I_glowfire.gameObject.SetActive(false);
	 I_xylnax.gameObject.SetActive(false);
	Debug.Log(cat);

		foreach (productdetail x in products) 
		{
			x.gameObject.SetActive(false);
		if (cat == category.horizontal) 
			{
				T_horizontal.gameObject.SetActive(true);
				if (x.ishorizontal) 
				{
					x.gameObject.SetActive(true);
				}
			}
			else if (cat == category.vertical)
			{
				T_vertical.gameObject.SetActive(true);
				if (x.isvertical)
				{
					x.gameObject.SetActive(true);
				}


			}
			else if (cat == category.glowfire)
			{
				I_glowfire.gameObject.SetActive(true);
				if (x.isglowfire)
				{
					x.gameObject.SetActive(true);
				}


			}
			else if (cat == category.xylnax)
			{
				I_xylnax.gameObject.SetActive(true);
				if (x.isxaralynx)
				{
					x.gameObject.SetActive(true);
				}

			}
		}

	}
}
