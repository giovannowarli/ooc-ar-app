using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class ImageTracking2 : MonoBehaviour
{

    [SerializeField]
    private GameObject scanIntro;

    [SerializeField]
    private GameObject scanIndicator;

    public Text productName, material, price, dimensions;

    public Text productPrimary, productPrice;

    [SerializeField]
    GameObject objectFound;

    [SerializeField]
    GameObject moreInfo;




    private ARTrackedImageManager _arTrackedImageManager;

    [SerializeField]
    private GameObject[] arObjectsToPlace;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

    private void Awake()
    {
        _arTrackedImageManager = GetComponent<ARTrackedImageManager>();

        foreach (GameObject arObject in arObjectsToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            arObjects.Add(arObject.name, newARObject);
        }
    }


    private void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    private void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }


    private void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateARImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateARImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            arObjects[trackedImage.name].SetActive(false);
            
        }
    }

    void UpdateARImage(ARTrackedImage trackedImage)
    {
        AssignGameObject(trackedImage.referenceImage.name, trackedImage.transform.position);
    }

    void AssignGameObject (string name, Vector3 newPosition)
    {
        if(arObjectsToPlace != null)
        {
            GameObject goARObject = arObjects[name];
            goARObject.SetActive(true);


            if (goARObject.activeSelf)
            {
                scanIntro.SetActive(false);
                scanIndicator.SetActive(false);
                ItemList _itemList = GetComponent<ItemList>();

                foreach(WoodCraft i in _itemList.woodCraft)
                {
                    if(goARObject.name == i.productName)
                    {
                        productName.text = i.productName;
                        productPrimary.text = i.productName;
                        price.text = i.price.ToString();
                        productPrice.text = i.price.ToString();
                        material.text = i.material;
                        dimensions.text = i.dimensions;
                    }
                }

                ObjectFound();
                
            }


            goARObject.transform.position = newPosition;
            foreach (GameObject go in arObjects.Values)
            {
                if(go.name != name)
                {
                    go.SetActive(false);
                }
            }
        }
    }

    void ObjectFound()
    {
        Animator animator = objectFound.GetComponent<Animator>();
        animator.SetBool("Open", true);
    }

    public void MoreInfo()
    {
        Animator animator = moreInfo.GetComponent<Animator>();
        animator.SetBool("Open", true);
    }

    public void CloseMoreInfo()
    {
        Animator animator = moreInfo.GetComponent<Animator>();
        animator.SetBool("Open", false);
    }
}


