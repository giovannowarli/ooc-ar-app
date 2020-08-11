using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _uiManager;

    [SerializeField]
    private GameObject selectionMenu;

    [SerializeField]
    private GameObject mainMenu;

    private string location = "Assets/Prefabs/";

    GameObject imHere;

    [SerializeField]
    private GameObject placementIndicator;

    private ARPlaneManager _arPlaneManager;

    [SerializeField]
    private GameObject arObj;

    public GameObject ArObj
    {
        get
        {
            return arObj;
        }

        set
        {
            arObj = value;
        }
    }

    [SerializeField]
    private Camera arCamera;

    private ARRaycastManager _arRaycastManager;

    private Vector2 touchPosition = default;

    private PlacementObject selectedObject;

    private Pose pose1;

    [SerializeField]
    private GameObject instantiateMe;

    public GameObject InstantiateMe
    {
        get
        {
            return instantiateMe;
        }
        set
        {
            instantiateMe = value;
        }
    }

    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        _arPlaneManager = GetComponent<ARPlaneManager>();
       

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;


            //if (IsPointerOverUI(touch)) return;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;


                if (Physics.Raycast(ray, out hitObject))
                {

                    selectedObject = hitObject.transform.root.GetComponent<PlacementObject>();

                    if (selectedObject != null)
                    {
                        UnityMessageManager.Instance.SendMessageToFlutter(hitObject.transform.root.name);
                        SelectObject();
                    } else
                    {
                        UnityMessageManager.Instance.SendMessageToFlutter("No Object Selected");
                        DeselectObject();

                    }

                }
                else
                {
                    DeselectObject();
                }

            }

        }


        CrosshairCalculation();

        if (_arRaycastManager.Raycast(touchPosition, _hits, TrackableType.PlaneWithinPolygon))
        {
            Touch touch = Input.GetTouch(0);
            Pose pose = _hits[0].pose;

            if(touch.phase == TouchPhase.Moved) //move object
            {
                if (Input.touchCount == 1)
                {
                    if (selectedObject.Selected)
                    {
                        selectedObject.transform.position = pose.position;
                        //selectedObject.transform.rotation = pose.rotation;
                    }
                }
            } 

        }

    }

            //    if (touch.phase == TouchPhase.Began)//instantiate object
            //{
            //    if (Input.touchCount == 1)
            //    {
            //        if (selectedObject == null)
            //        {
            //            selectedObject = Instantiate(arObj, pose.position, pose.rotation).GetComponent<PlacementObject>();
            //        }
            //    }
            //}
            //else


    void DeselectObject()
    {
        PlacementObject[] allOtherObjects = FindObjectsOfType<PlacementObject>();

        foreach (PlacementObject placedObject in allOtherObjects)
        {
            placedObject.Selected = false;
        }
        DisableARPlane();
    }

    public void ObjectSelection(GameObject arObject)
    {
        arObj = arObject;
        //OpenMainMenu();
        EnableARPlane();
        instantiateMe.gameObject.SetActive(true);
    }


    bool IsPointerOverUI (Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }


    void CrosshairCalculation()
    {
        Vector3 origin = arCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f,0));
        Ray rayTarget = arCamera.ScreenPointToRay(origin);

        if (_arRaycastManager.Raycast(rayTarget, _hits, TrackableType.PlaneWithinPolygon))
        {
            pose1 = _hits[0].pose;
            if (arObj == null)
            {
                placementIndicator.transform.position = new Vector3(1000f, 1000f, 0);

            }
            else
            {
                placementIndicator.transform.position = pose1.position;
                placementIndicator.transform.eulerAngles = new Vector3(90, 0, 0);
            }
            
        }
    }

    void summonPrefab()
    {
        selectedObject = Instantiate(arObj, pose1.position, pose1.rotation).GetComponent<PlacementObject>();
        arObj = null;
        if(!arObj)
        {
            instantiateMe.gameObject.SetActive(false);
        }
        DisableARPlane();
    }

  
    void SelectObject()
    {
        DeselectObject();
        PlacementObject[] allOtherObjects = FindObjectsOfType<PlacementObject>();
        foreach (PlacementObject placedObject in allOtherObjects)
        {
           
            placedObject.Selected = selectedObject == placedObject;
            
            if (placedObject.Selected)
            {
                EnableARPlane();
                ItemList itemList = _uiManager.GetComponent<ItemList>();
                //foreach(WoodCraft i in itemList.woodCraft)
                //{
                //    if (i.productName+ "(Clone)" == placedObject.name)
                //    {
                //        PanelManager panelManager = _uiManager.GetComponent<PanelManager>();
                //        panelManager.productName.text = i.productName;
                //        panelManager.dimensions.text = i.dimensions;
                //        panelManager.material.text = i.material;
                //        panelManager.price.text = i.price.ToString();

                //    }
                //}

            }

        }
    }

    public void DeleteObject()
    {
        PlacementObject[] allOtherObjects = FindObjectsOfType<PlacementObject>();
        foreach (PlacementObject placedObject in allOtherObjects)
        {
            placedObject.Selected = selectedObject == placedObject;
            //placedObject.transform.GetChild(0).gameObject.SetActive(placedObject.Selected);

        }

        if (selectedObject.Selected)
        {
            Destroy(selectedObject.gameObject);
            //OpenMainMenu();
        }
        DisableARPlane();
    }

    void EnableARPlane()
    {
        foreach(ARPlane plane in _arPlaneManager.trackables)
        {
            plane.gameObject.SetActive(true);
        }
    }

    void DisableARPlane()
    {
        foreach (ARPlane plane in _arPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }


    private async void Get(string label)
    {

        imHere = await Addressables.InstantiateAsync(location + label + ".prefab", pose1.position, pose1.rotation).Task;

        selectedObject = imHere.GetComponent<PlacementObject>();

        DisableARPlane();


        if (imHere != null)
            {
                UnityMessageManager.Instance.SendMessageToFlutter(location.ToString());
            }
            else
            {
                UnityMessageManager.Instance.SendMessageToFlutter("nothing here");
            }
    }


    public void InstantiateThis(string message)
    {
        Get(message);
    }

}
