using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reorientatMainCamera : MonoBehaviour
{
    GameObject ManCam;
    private void Start()
    {
        ManCam = Camera.main.gameObject;
        ReorientAtMainCam();
     }
    public void ReorientAtMainCam()
    {
        this.transform.LookAt(ManCam.transform);
        Transform T = this.transform;
        Quaternion R = T.rotation;
        R.eulerAngles = new Vector3(0, this.transform.rotation.eulerAngles.y, 0);
        T.rotation = R;
    }
}