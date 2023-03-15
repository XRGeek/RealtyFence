using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSizeManager : MonoBehaviour
{
    public GameObject _parentObject;

    public void OnMouseClick()
    {
      
        string name = gameObject.name;

        for (int i = 0; i < _parentObject.transform.childCount; i++)
        {
            GameObject childObj = _parentObject.transform.GetChild(i).gameObject;

            if (childObj.name == name)
            {
                childObj.transform.GetChild(2).gameObject.SetActive(true);
                //childObj.GetComponent<Image>().sprite = biggerimg;
            }
            else
            {
                childObj.transform.GetChild(2).gameObject.SetActive(false);
                //childObj.GetComponent<Image>().sprite = smallerimg;
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
    }

}
