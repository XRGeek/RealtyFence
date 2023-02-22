using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class favourite : MonoBehaviour
{/*
    public GameObject ambiancee;
    public GameObject  appolionn;
    public GameObject Aress;
    public GameObject beethovenn;
    public GameObject Chronoss;
    public GameObject Galaa;
    public GameObject Hauptmannn;
    public GameObject Helioss;
    public GameObject Hemess;
    public GameObject Humboltt;
    public GameObject kastnerr;
    public GameObject lasizee;
    public GameObject lessingg;
    public GameObject marss; 
    public GameObject marsxl;
    public GameObject mozartt;
    public GameObject neptunn;
    public GameObject nuoroo;
    public GameObject plutoo;
    public GameObject poseidonn;
    public GameObject saturnn;
    public GameObject schillerr;

    public static int ambiance = 0;
    public static int appolion = 0;
    public static int Ares = 0;
    public static int beethoven = 0;
    public static int Chronos = 0;
    public static int Gala = 0;
    public static int Hauptmann = 0;
    public static int Helios = 0;
    public static int Hemes = 0;
    public static int Humbolt = 0;
    public static int kastner = 0;
    public static int lasize = 0;
    public static int lessing = 0;
    public static int mars = 0;
    public static int mozart = 0;
    public static int neptun = 0;
    public static int nuoro= 0;
    public static int pluto = 0;
    public static int poseidon = 0;
    public static int saturn = 0;
    public static int schiller = 0;
    public static int marsx = 0;

    // Start is called before the first frame update
    void Start()
    {
        ambiance = PlayerPrefs.GetInt("ambiance", 0);
        appolion = PlayerPrefs.GetInt("appolion", 0);
        Ares = PlayerPrefs.GetInt("ares", 0);
        beethoven = PlayerPrefs.GetInt("beethoven", 0);
        Chronos = PlayerPrefs.GetInt("chronos", 0);
        Gala = PlayerPrefs.GetInt("gala", 0);
        Hauptmann = PlayerPrefs.GetInt("hauptmann", 0);
        Helios = PlayerPrefs.GetInt("helios", 0);
        Hemes = PlayerPrefs.GetInt("hemes", 0);
        Humbolt = PlayerPrefs.GetInt("humbolt", 0);
        kastner = PlayerPrefs.GetInt("kastner", 0);
        lasize = PlayerPrefs.GetInt("lasize", 0);
        lessing = PlayerPrefs.GetInt("lessing", 0);
        mars = PlayerPrefs.GetInt("mars", 0);
        mozart = PlayerPrefs.GetInt("mozart", 0);
        neptun = PlayerPrefs.GetInt("neptun", 0);
        nuoro = PlayerPrefs.GetInt("nuoro", 0);
        pluto = PlayerPrefs.GetInt("pluto", 0);
        poseidon = PlayerPrefs.GetInt("poseidon", 0);
        saturn = PlayerPrefs.GetInt("saturn", 0);
        schiller = PlayerPrefs.GetInt("schiller", 0);
        marsx = PlayerPrefs.GetInt("marsx", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(ambiance==1)
        {
            ambiancee.SetActive(true);
        }

        if (appolion == 1)
        {
            appolionn.SetActive(true);
        }
        if (Ares == 1)
        {
            Aress.SetActive(true);
        }
        if (beethoven == 1)
        {
            beethovenn.SetActive(true);
        }
        if (Chronos == 1)
        {
            Chronoss.SetActive(true);
        }
        if (Gala == 1)
        {
            Galaa.SetActive(true);
        }
        if (Hauptmann == 1)
        {
           Hauptmannn.SetActive(true);
        }
        if (Helios == 1)
        {
            Helioss.SetActive(true);
        }
        if (Hemes == 1)
        {
            Hemess.SetActive(true);
        }
        if (Humbolt == 1)
        {
            Humboltt.SetActive(true);
        }
        if (kastner == 1)
        {
            kastnerr.SetActive(true);
        }
        if (lasize == 1)
        {
            lasizee.SetActive(true);
        }
        if (lessing == 1)
        {
            lessingg.SetActive(true);
        }
        if (mars == 1)
        {
            marss.SetActive(true);
        }
        if (mozart == 1)
        {
            mozartt.SetActive(true);
        }
        if (neptun == 1)
        {
            neptunn.SetActive(true);
        }
        if (nuoro == 1)
        {
            nuoroo.SetActive(true);
        }
        if (pluto == 1)
        {
            plutoo.SetActive(true);
        }
        if (poseidon == 1)
        {
            poseidonn.SetActive(true);
        }
        if (saturn == 1)
        {
            saturnn.SetActive(true);
        }
        if (schiller == 1)
        {
            schillerr.SetActive(true);
        }


        if (marsx == 1)
        {
            marsxl.SetActive(true);
        }



    }




    public void ambienceee()
    {
        ambiance = 1;
        PlayerPrefs.SetInt("ambiance", ambiance);
        PlayerPrefs.Save();
    }

    public void Appolionnn()
    {
        appolion = 1;
        PlayerPrefs.SetInt("appolion", ambiance);
        PlayerPrefs.Save();
    }
    public void areses()
    {
        Ares = 1;
        PlayerPrefs.SetInt("ares", ambiance);
        PlayerPrefs.Save();
    }
    public void beethovend()
    {
        beethoven = 1;
        PlayerPrefs.SetInt("beethoven", ambiance);
        PlayerPrefs.Save();
    }
    public void chronosd()
    {
        Chronos = 1;
        PlayerPrefs.SetInt("chronos", ambiance);
        PlayerPrefs.Save();
    }
    public void galad()
    {
        Gala = 1;
        PlayerPrefs.SetInt("gala", ambiance);
        PlayerPrefs.Save();
    }
    public void hauptmaned()
    {
        Hauptmann = 1;
        PlayerPrefs.SetInt("hauptmann", ambiance);
        PlayerPrefs.Save();
    }

    public void heliosed()
    {
        Helios = 1;
        PlayerPrefs.SetInt("helios", ambiance);
        PlayerPrefs.Save();
    }
    public void ambienceee()
    {
        ambiance = 1;
        PlayerPrefs.SetInt("ambiance", ambiance);
        PlayerPrefs.Save();
    }
    public void ambienceee()
    {
        ambiance = 1;
        PlayerPrefs.SetInt("ambiance", ambiance);
        PlayerPrefs.Save();
    }
    public void ambienceee()
    {
        ambiance = 1;
        PlayerPrefs.SetInt("ambiance", ambiance);
        PlayerPrefs.Save();
    }
    public void ambienceee()
    {
        ambiance = 1;
        PlayerPrefs.SetInt("ambiance", ambiance);
        PlayerPrefs.Save();
    }
    public void ambienceee()
    {
        ambiance = 1;
        PlayerPrefs.SetInt("ambiance", ambiance);
        PlayerPrefs.Save();
    }
    public void ambienceee()
    {
        ambiance = 1;
        PlayerPrefs.SetInt("ambiance", ambiance);
        PlayerPrefs.Save();
    }









    */
}
