using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageBasedText : MonoBehaviour
{
	public string EnglishText;

	public string GermanText;
 


	public void Start()
	{
		if (PlayerPrefs.GetString("Lang", "") == "En")
		{
		//	this.gameObject.GetComponent<Text>().text = EnglishText;

			this.gameObject.GetComponent<TMP_Text>().text = EnglishText;
		}
		else if (PlayerPrefs.GetString("Lang", "") == "Sp")
		{//
		//	this.gameObject.GetComponent<Text>().text = GermanText;
			this.gameObject.GetComponent<TMP_Text>().text = GermanText;

		}
		else if (PlayerPrefs.GetString("Lang", "") == "") 
		{
			PlayerPrefs.SetString("Lang", "En");
		//	this.gameObject.GetComponent<Text>().text = EnglishText;
			this.gameObject.GetComponent<TMP_Text>().text = EnglishText;

		}
	}


	public void switchText(string lang)
	{
		if (lang == "En")
		{
		//	this.gameObject.GetComponent<Text>().text = EnglishText;

			this.gameObject.GetComponent<TMP_Text>().text = EnglishText;
			


		} 
		else if (lang == "Sp") 
		{
		//	this.gameObject.GetComponent<Text>().text = GermanText;
			this.gameObject.GetComponent<TMP_Text>().text = GermanText;

		}

	}

}
