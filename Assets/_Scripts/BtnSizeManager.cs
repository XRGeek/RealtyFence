using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSizeManager : MonoBehaviour
{
    public GameObject _parentObject;
    public  ScrollRect ScrollView;

    string check;
    private void Start()
    {
        ScrollView.horizontalNormalizedPosition = 100f;


        check = PlayerPrefs.GetString("ObjectName", "");
        if (gameObject.name == check)
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
            Debug.Log("here");
        }
        else
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            Debug.Log("there");
        }



    }

    public void OnMouseClick()
    {
        string name = gameObject.name;

        for (int i = 0; i < _parentObject.transform.childCount; i++)
        {
            GameObject childObj = _parentObject.transform.GetChild(i).gameObject;

            if (childObj.name == name)
            {
                childObj.transform.GetChild(3).gameObject.SetActive(true);
                //childObj.GetComponent<Image>().sprite = biggerimg;
            }
            else
            {
                childObj.transform.GetChild(3).gameObject.SetActive(false);
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
    }

}
