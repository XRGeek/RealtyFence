using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DanielLochner.Assets.SimpleScrollSnap;

public class BtnSizeManager : MonoBehaviour
{
   
    public GameObject _parentObject;
    string check;
    public SimpleScrollSnap SimpleScrollSnap;

    private void Start()
    {
        check = PlayerPrefs.GetString("ObjectName", "");
        if (gameObject.name == check)
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(true);

           // int index = transform.GetSiblingIndex();

            //SimpleScrollSnap.instance.startingPanel = index;

            //Debug.Log(index);
        }
        else
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
        
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
