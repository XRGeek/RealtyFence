using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ProductDetails
{  
    public string title;
    public string Details;
    public string Details1;
    public string Details2;

}


public class SetDetailsPannel : MonoBehaviour
{
    public List<ProductDetails> English_Products;
    public List<ProductDetails> German_Products;



    public Sprite[] product_Image;
    public Sprite[] product_provider;
    public string[] urlsfor_UTM;
    public int[] provider;

    public Image ProductsImages;
    public Image Productsprovider;
    public TMP_Text txt_title;
    public TMP_Text txt_details;
    public TMP_Text txt_details1;
    public TMP_Text txt_details2;

    public GameObject Heart;
    public openUrlforproduct ourlf;
    public void SetProductDetailswithindex(int index) 
    {
        ProductsImages.sprite = product_Image[index];
        Productsprovider.sprite = product_provider[provider[index]];
        ourlf.Url = urlsfor_UTM[index];
        if (PlayerPrefs.GetString("Lang", "") == "En")
        {
            txt_title.text = English_Products[index].title;
            txt_details.text = English_Products[index].Details;
            txt_details1.text = English_Products[index].Details1;
            txt_details2.text = English_Products[index].Details2;
          //  Instantiate(English_Products[index].heart, new Vector3(-18.12f, -8.219971f, 0), Quaternion.identity);
        }
        else if(PlayerPrefs.GetString("Lang", "") == "Sp")
        {
            txt_title.text = German_Products[index].title;
            txt_details.text = German_Products[index].Details;
            txt_details1.text = German_Products[index].Details1;
            txt_details2.text = German_Products[index].Details2;

        }
        Heart.GetComponent<AddToFavourite>().FavouriteObjectname = English_Products[index].title;

    }

        
  








}
