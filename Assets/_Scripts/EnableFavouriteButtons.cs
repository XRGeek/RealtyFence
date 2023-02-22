using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableFavouriteButtons : MonoBehaviour
{
    public List<GameObject> AllButtons;
    public ScrollRect scroll;
    Vector2 doubleSize;

    public GameObject Textforempty;
    private void Start()
	{
        doubleSize = scroll.content.sizeDelta;

    }



	public void CheckandEnablethatFvaouriteButton() 
    {
        int count = 0;
        foreach(GameObject x in AllButtons) 
        {
            Debug.Log("comparing " + x.name + "value is " + PlayerPrefs.GetString("" + x.name));
            if (PlayerPrefs.GetString("" + x.name) == "Favourite")
            {
                count++;
                x.SetActive(true);
            }
            else 
            {
                x.SetActive(false);
            }

        }
        if (count == 0)
        {
            Textforempty.SetActive(true);
        }
        else 
        {
            Textforempty.SetActive(false);

        }
        float z =(float) count / 2.0f;

        int y =(int)  Mathf.Ceil(z);
        scroll.content.sizeDelta = new Vector2(doubleSize.x, +doubleSize.y * y);

    }
}
