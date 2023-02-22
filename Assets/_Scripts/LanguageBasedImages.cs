using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageBasedImages : MonoBehaviour
{
	public Sprite EnglishSprite;
	public Sprite GermanSprite;



	public void Start()
	{
		if (PlayerPrefs.GetString("Lang", "") == "En")
		{
			this.gameObject.GetComponent<Image>().sprite = EnglishSprite;
		}
		else if (PlayerPrefs.GetString("Lang", "") == "Sp")
		{
			this.gameObject.GetComponent<Image>().sprite = GermanSprite;
		}
		else if (PlayerPrefs.GetString("Lang", "") == "")
		{
			PlayerPrefs.SetString("Lang", "En");
			this.gameObject.GetComponent<Image>().sprite = EnglishSprite;
		}
	}


	public void switchText(string lang)
	{
		if (lang == "En")
		{
			this.gameObject.GetComponent<Image>().sprite = EnglishSprite;
		}
		else if (lang == "Sp")
		{
			this.gameObject.GetComponent<Image>().sprite = GermanSprite;
		}

	}

}
