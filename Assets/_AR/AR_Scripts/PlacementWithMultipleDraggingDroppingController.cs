using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacementWithMultipleDraggingDroppingController : MonoBehaviour
{
	[SerializeField]
	private GameObject placedPrefab;

	[SerializeField]
	private Camera arCamera;

	private PlacementObject[] placedObjects;

	private Vector2 touchPosition = default;

	private ARRaycastManager arRaycastManager;

	private bool onTouchHold = false;

	// public GameObject PlaceAfterAR;

	public GameObject RemoveAfterAR;

	private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

	private PlacementObject lastSelectedObject;

	bool oneTime = true;
	bool itemSelected = true;

	int counter = 0;


	private GameObject PlacedPrefab
	{
		get
		{
			return placedPrefab;
		}
		set
		{
			placedPrefab = value;
		}
	}


	void Awake()
	{

		arRaycastManager = GetComponent<ARRaycastManager>();
	}


	public void ChangePrefabSelection(string name)
	{
		GameObject loadedGameObject = Resources.Load<GameObject>($"Prefabs/{name}");
		if (loadedGameObject != null)
		{
			PlacedPrefab = loadedGameObject;
			Debug.Log($"Game object with name {name} was loaded");
			itemSelected = true;
		}
		else
		{
			Debug.Log($"Unable to find a game object with name {name}");
		}

	}

	void Update()
	{

		if (!itemSelected)
			return;

		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			touchPosition = touch.position;

			if (touch.phase == TouchPhase.Began && !IsPointerOverUIObject())
			{

				Ray ray = arCamera.ScreenPointToRay(touch.position);
				RaycastHit hitObject;
				if (Physics.Raycast(ray, out hitObject))
				{
					lastSelectedObject = hitObject.transform.GetComponent<PlacementObject>();
					if (lastSelectedObject != null)
					{

						PlacementObject[] allOtherObjects = FindObjectsOfType<PlacementObject>();
						foreach (PlacementObject placementObject in allOtherObjects)
						{
							placementObject.Selected = placementObject == lastSelectedObject;
						}
					}
				}
			}

			if (touch.phase == TouchPhase.Ended)
			{
				lastSelectedObject.Selected = false;
			}
		}

		if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
		{
			Pose hitPose = hits[0].pose;

			if (lastSelectedObject == null)
			{
				lastSelectedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation).GetComponent<PlacementObject>();

				itemSelected = false;
				counter++;

				if (oneTime == true)
				{

					ChangePrefabSelection(PlayerPrefs.GetString("ObjectName"));
					oneTime = false;
				}

				if (counter == 2)
				{
					RemoveAfterAR.SetActive(false);
					gameObject.GetComponent<ARPlaneManager>().enabled = false;
				//	arRaycastManager.enabled = false;

				}
			}
			else
			{
				if (lastSelectedObject.Selected)
				{
					lastSelectedObject.transform.position = hitPose.position;
					lastSelectedObject.transform.rotation = hitPose.rotation;
				}
			}
		}
	}
	// UI Ignoring Code Snipet

	private bool IsPointerOverUIObject()
	{
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

		return results.Count > 0;
	}


}