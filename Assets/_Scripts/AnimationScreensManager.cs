using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScreensManager : MonoBehaviour
{
	[SerializeField] Animator hudanim;
	public string curentscreen;



	private void Start()
	{

		var identifier = SystemInfo.deviceModel;

#if UNITY_IPHONE
		if (identifier.StartsWith("iPhone"))
		{
			// iPhone logic
			TransitionToScreen("Main");

		}
		else if (identifier.StartsWith("iPad"))
		{
			// iPad logic
			TransitionToScreen("Main1");

		}
#endif
#if UNITY_ANDROID
		TransitionToScreen("Main");
#endif



	}
	public void TransitionToScreen(string screenname) 
	{
		string toscreen = screenname;
		var identifier = SystemInfo.deviceModel;
		if (screenname == "Main")
		{
			if (identifier.StartsWith("iPad"))
			{
				toscreen = "Main1";

			}
		}

	
		hudanim.SetBool(curentscreen, false);
		hudanim.SetBool(toscreen, true);
		curentscreen = toscreen;
	}

}
