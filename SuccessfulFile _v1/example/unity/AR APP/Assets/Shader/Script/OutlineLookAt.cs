using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineLookAt : MonoBehaviour
{
    public Camera cam;

    private OutlineController prevController;

    private OutlineController currentController;

    private PlacementObject selectedObject;



    private void Update()
    {
        HandleLookAtRay();
    }

    private void HandleLookAtRay()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = cam.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (touch.phase == TouchPhase.Began)
            {

                if (Physics.Raycast(ray, out hit))
                {
                    
                  selectedObject = hit.transform.root.GetComponent<PlacementObject>();

                        PlacementObject[] allOtherObjects = FindObjectsOfType<PlacementObject>();

                        foreach (PlacementObject placedObject in allOtherObjects)
                        {
                            placedObject.Selected = selectedObject == placedObject;
                            if (placedObject.Selected)
                            {
                                //Debug.Log(placedObject.name);
                                //placedObject.transform.GetComponent<OutlineController>().ShowOutline();
                            }
                            else
                            {
                                //placedObject.transform.GetComponent<OutlineController>().HideOutline();
                            }

                        }
                }
                else
                {
                    PlacementObject[] allOtherObjects = FindObjectsOfType<PlacementObject>();

                    foreach (PlacementObject placedObject in allOtherObjects)
                    {
                        placedObject.Selected = false;
                    }
                }
            }
        }
    }

    private void ShowOutline()
    {
        
        if(currentController != null)
        {
            currentController.ShowOutline();
        }
    }

    private void HideOutline()
    {
        if (currentController != null)
        {
            prevController.HideOutline();
            prevController = null;
        }
    }
}
