using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainSceneGracefully : MonoBehaviour
{
	public void MainScene()
	{
		Invoke("PreviousScene", 2f);
	}

	public void PreviousScene() 
	{

		SceneManager.LoadScene(1);
	}
}
