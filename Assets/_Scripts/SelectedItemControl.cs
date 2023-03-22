using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedItemControl : MonoBehaviour
{
    public GameObject[] uiButtons;
    public int selectedIndex;
    string check;

    void Start()
    {
        check = PlayerPrefs.GetString("ObjectName", "");

        for (int i = 0; i < uiButtons.Length; i++)
        {
            if (uiButtons[i].name == check)
            {
                selectedIndex = transform.GetSiblingIndex();
                for (int j = 0; j < selectedIndex; j++)
                {
                    if (uiButtons[i].name == check)
                    {
                        uiButtons[i].transform.SetAsFirstSibling();
                    }

                }
            }
        }

      
    }
}
