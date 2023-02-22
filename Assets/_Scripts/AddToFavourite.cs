using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddToFavourite : MonoBehaviour
{
    public string FavouriteObjectname = "";
    public Image buttonimage;

    public Sprite Favouritesprite;

    public Sprite NotFavouritesprite;

    public GameObject particleObject;
    public void Start()
    {
        ///PlayerPrefs.DeleteAll();
        Debug.Log("Deletedprefs");
        Checkobject();

      
    }

    public void Checkobject()
    {
        Debug.Log("checking");
        if (PlayerPrefs.GetString("" + FavouriteObjectname) == "Favourite")
        {
            buttonimage.sprite = Favouritesprite;
        }
        else if (PlayerPrefs.GetString("" + FavouriteObjectname) == "NotFavourite")
        {
            buttonimage.sprite = NotFavouritesprite;
         }
        else if (PlayerPrefs.GetString("" + FavouriteObjectname) == "")
        {
            PlayerPrefs.SetString("" + FavouriteObjectname, "NotFavourite");
            buttonimage.sprite = NotFavouritesprite;
        }
    }


    public void SetObjectOffAfterTime() 
    {
        Invoke("Disableparticle",1.0f);   
    }
    public void Disableparticle() 
    {
        particleObject.SetActive(false);
    }



    public void CheckFavouriteadded() 
    {
        Debug.Log("checking and flippping");

        if (PlayerPrefs.GetString("" + FavouriteObjectname) == "Favourite") 
        {
            PlayerPrefs.SetString("" + FavouriteObjectname, "NotFavourite");
            buttonimage.sprite = NotFavouritesprite;
            buttonimage.color = Color.white;
            Debug.Log("Added "+ FavouriteObjectname +" to not favourites");
        }
        else 
        {
            PlayerPrefs.SetString("" + FavouriteObjectname, "Favourite");
            buttonimage.sprite = Favouritesprite;
            buttonimage.color = Color.white;
           Debug.Log("Added " + FavouriteObjectname + " to favourites");
        }
    }
}
