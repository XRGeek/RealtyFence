using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callAnumber : MonoBehaviour
{
	public void CallKaminlicht() 
	{
		Debug.Log("Trying to call");
		Application.OpenURL("tel://+493060989778");
	}
}
