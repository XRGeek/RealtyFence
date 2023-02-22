using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Levelmanager : MonoBehaviour
{

	public GameObject[] horizontals;
	public GameObject[] Verticals;



	public void LoadAR() 
	{
		foreach (GameObject x in horizontals) 
		{
			if (PlayerPrefs.GetString("ObjectName", "") == x.name) 
			{
		      Invoke("LoadARHorizonntal", 2.5f);
				return;
			}
		}
		foreach (GameObject x in Verticals)
		{
			if (PlayerPrefs.GetString("ObjectName", "") == x.name)
			{
				Invoke("LoadARVertical", 2.5f);				
				return;
			}

		}
	}


	public void LoadARHorizonntal()
	{
		SceneManager.LoadScene(2);
	}


	public void LoadARVertical()
	{
		SceneManager.LoadScene(3);
	}

}
