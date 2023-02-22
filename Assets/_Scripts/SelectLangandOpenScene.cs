using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLangandOpenScene : MonoBehaviour
{
	public Dropdown LangDropdown;
	public TMP_Text SelectlangText;
	public TMP_Text continueText;
	public GameObject Loadingpart;
	void Awake()
	{
		if (PlayerPrefs.GetString("Lang", "") == "En")
		{
			LangDropdown.value = 0;
		}
		else if (PlayerPrefs.GetString("Lang", "") == "Sp")
		{
			LangDropdown.value = 1;
		}
		else if (PlayerPrefs.GetString("Lang", "") == "")
		{
			LangDropdown.value = 0;
			LangDropdown.onValueChanged.Invoke(0);
		}	
		
	
	}

	public void loadskipscene()
	{
		if (PlayerPrefs.GetString("Languageset", "") != "")
		{
			Loadingpart.SetActive(true);
			loadnextscene();
		}
		
	}


	public void loadnextscene() 
	{
		if (LangDropdown.value == 0)
		{
			PlayerPrefs.SetString("Lang", "En");
		}
		else if (LangDropdown.value == 1)
		{
			PlayerPrefs.SetString("Lang", "Sp");
		}
		Invoke("NextScene", 2f);
	}
	public void NextScene()
	{
		PlayerPrefs.SetString("Languageset", "true");
		
		SceneManager.LoadScene(1);
	}


	public void changeText(int selection)
	{
		switch (selection) 
		{
			case 0:
		SelectlangText.GetComponent<LanguageBasedText>().switchText("En");
				continueText.GetComponent<LanguageBasedText>().switchText("En");
				break;
			case 1:
		SelectlangText.GetComponent<LanguageBasedText>().switchText("Sp");
				continueText.GetComponent<LanguageBasedText>().switchText("Sp");
				break;
		}
	}

	
}
