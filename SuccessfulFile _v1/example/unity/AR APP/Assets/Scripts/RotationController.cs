using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationY;
    private float rotateSpeedModifier = 0.1f;
    private PlacementObject selectedObject;


    

    private void Update()
    {
        if(Input.touchCount == 2)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                selectedObject = GetComponent<PlacementObject>();

                if (selectedObject.Selected)
                {
                    rotationY = Quaternion.Euler(0f, -touch.deltaPosition.x * rotateSpeedModifier, 0f);
                    transform.rotation = rotationY * transform.rotation;
                }
          
            }
        }
    }
}
