using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SetSelection : MonoBehaviour
{
	public UnityEvent onclickproduct;
	public void SetSelectionbyObjectName(GameObject homeobject) 
	{
		PlayerPrefs.SetString("ObjectName", homeobject.name);
		onclickproduct.Invoke();
	}
}
