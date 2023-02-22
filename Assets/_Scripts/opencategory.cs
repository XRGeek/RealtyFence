using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opencategory : MonoBehaviour
{
    public Categoryselection catselection;

 

    [SerializeField]
    public void openbycategory(int cat) 
        {
            catselection.OpenCategoryorProduct((Categoryselection.category) cat);
        }

}
