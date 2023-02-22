using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    public List<GameObject> Models;


    public void SelectObjectbyname(string name) 
    {
        foreach (GameObject x in Models)
        {
            if (x.gameObject.name == name)
            {
                x.gameObject.SetActive(true);
            }
            else 
            {
                x.gameObject.SetActive(false);
            }

        }
     }
}
