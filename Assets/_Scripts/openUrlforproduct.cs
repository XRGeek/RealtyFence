using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openUrlforproduct : MonoBehaviour
{
	public string Url="";


	public void openUrl() 
	{
#if UNITY_IOS
Url= Url+ "?utm_campaign=ar_apple&utm_medium=referal&utm_source=ar-app";
#endif

#if UNITY_ANDROID
		Url = Url + "?utm_campaign=ar_android&utm_medium=referal&utm_source=ar-app";
#endif





		Application.OpenURL(Url);
	}










}
