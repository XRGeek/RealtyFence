using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Lean.Touch;
[RequireComponent(typeof(ARRaycastManager))]


public class placementcontrolller : MonoBehaviour
{

    public GameObject gameobjectToCreate;
    public GameObject HUD;
   
    public bool movemode = false;
    public bool rotatemode = true;
    public bool Pinchmode = false;
    public bool Lockmode = false;

    public Toggle T_movemode;
    public Toggle T_rotatemode;
    public Toggle T_Pinchmode;
    public Toggle T_LockMode;


    public void Setmovemode(bool mode) 
    {
        movemode = mode;
    }

    public void SetRotatemode(bool mode)
    {
        rotatemode = mode;
    }


    public void SetPinchmode(bool mode)
    {
        Pinchmode = mode;
       
    }

    public void SetLockMode(bool mode)
    {
        Lockmode = mode;


    }

    public GameObject Placedprefab
    {
        get
        {
            return gameobjectToCreate;
        }
        set 
        {
            gameobjectToCreate = value;
        }
    }

    ARRaycastManager arRaycastManager;

    // Start is called before the first frame update
    void Start()
    {
        arRaycastManager = gameObject.GetComponent<ARRaycastManager>();
        name = PlayerPrefs.GetString("ObjectName", "");
        {
            ChangePrefabSelection(name);
        }

        PlaceObject();
    }

    public void PlaceObject()
    {
        GameObject parentObj = gameobjectToCreate;

        for (int i = 0; i < parentObj.transform.childCount; i++)
        {
            GameObject childObj = parentObj.transform.GetChild(i).gameObject;

            if (childObj.name == name)
            {
                childObj.SetActive(true);
            }
            else
            {
                childObj.SetActive(false);
            }
        }
    }


    public void SelectModel(GameObject currentModel)
    {
        for (int i = 0; i < Placedprefab.transform.childCount; i++)
        {
            GameObject childObj = Placedprefab.transform.GetChild(i).gameObject;

            if (childObj.name == currentModel.name)
            {
                childObj.SetActive(true);
            }
            else
            {
                childObj.SetActive(false);
            }
        }
    }
    bool TryGetTouchPosition(out Vector2 touchposition) 
    {
        if (Input.touchCount > 0)
        { touchposition = Input.GetTouch(0).position;
            return true;
        }
        {
            touchposition = default;
            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (!instantiated)
        {
            Placedprefab = Instantiate(Placedprefab);
            instantiated = true;
        }
       
#endif

        if (!TryGetTouchPosition(out Vector2 touchposition)) 
            return;
            
        //enable and disable rotate mode based on Toggle value      
        if(instantiated)
        Placedprefab.GetComponent<LeanTwistRotateAxis>().enabled = rotatemode;
        Placedprefab.GetComponent<LeanPinchScale>().enabled = Pinchmode;
        Placedprefab.GetComponent<PlacementObject>().Locked = Lockmode;




        if (arRaycastManager.Raycast(touchposition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon)) 
        {
            var hitpose = hits[0].pose;
            if (!instantiated && !IsPointerOverUIObject())
            {
                Placedprefab = Instantiate(Placedprefab, hitpose.position, hitpose.rotation);
                instantiated = true;
                HUD.SetActive(false);
                gameObject.GetComponent<ARPlaneManager>().enabled = false;
                gameObject.GetComponent<ARPointCloudManager>().enabled = false;
                foreach (ARPlane plane in gameObject.GetComponent<ARPlaneManager>().trackables)
                {
                    plane.gameObject.SetActive(false);
                }
                foreach (ARPointCloud point in gameObject.GetComponent<ARPointCloudManager>().trackables)
                {
                    point.gameObject.SetActive(false);
                }
            }
            else if (instantiated &&  movemode && !rotatemode  &&  !IsPointerOverUIObject()) 
            {
                  Placedprefab.transform.position = hitpose.position;
                  Debug.Log("hit to replace");
            }
          
        }
    }
    bool instantiated = false;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // UI Ignoring Code Snipet

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
    public void ChangePrefabSelection(string name)
    {
        GameObject loadedGameObject = Resources.Load<GameObject>($"Prefabscheck/{"SpawnItems"}");
        if (loadedGameObject != null)
        {
            gameobjectToCreate = loadedGameObject;
            Debug.Log($"Game object with name {name} was loaded");
        }
        else
        {
            Debug.Log($"Unable to find a game object with name {name}");
        }
    }
}
