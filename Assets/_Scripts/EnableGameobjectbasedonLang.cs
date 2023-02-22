using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameobjectbasedonLang : MonoBehaviour
{

    public GameObject Englishobj;

    public GameObject Germanobj;
    // Start is called before the first frame update
    void Start()
    {
		if (PlayerPrefs.GetString("Lang", "") == "En")
		{
			Englishobj.SetActive(true);
			Germanobj.SetActive(false);
		}
		else if (PlayerPrefs.GetString("Lang", "") == "Sp")
		{
			Englishobj.SetActive(false);
			Germanobj.SetActive(true);
		}
		else if (PlayerPrefs.GetString("Lang", "") == "")
		{

			Englishobj.SetActive(true);
			Germanobj.SetActive(false);
		}
	}

	public void switchobj(string lang)
	{
		if (lang == "En")
		{

			Englishobj.SetActive(true);
			Germanobj.SetActive(false);
		}
		else if (lang == "Sp")
		{

			Englishobj.SetActive(false);
			Germanobj.SetActive(true);
		}

	}
}
