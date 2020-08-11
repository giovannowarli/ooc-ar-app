using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{

    [SerializeField]
    private GameObject scanMenu;

    [SerializeField]
    private GameObject objectInfoPanel;

    [SerializeField]
    private GameObject[] arObjectsToPlace;

    [SerializeField]
    private Camera _arCamera;

    [SerializeField]
    private GameObject moreInfoPanel;

    ItemList _itemList;

    public Text productName, material, price, dimensions;






    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager _trackedImageManager;

    private void Awake()
    {
        _trackedImageManager = FindObjectOfType <ARTrackedImageManager>();

        _itemList = GetComponent<ItemList>();


        foreach(GameObject arObject in arObjectsToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            spawnedPrefabs.Add(arObject.name, newARObject);

        }
    }

    private void OnEnable()
    {
        _trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        _trackedImageManager.trackedImagesChanged -= ImageChanged;        
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnedPrefabs[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;

        GameObject prefab = spawnedPrefabs[name];
        prefab.transform.position = position;
        prefab.SetActive(true);
        foreach (WoodCraft i in _itemList.woodCraft)
        {
            if (i.productName == prefab.name && prefab.activeSelf)
            {
                productName.text = i.productName;
                dimensions.text = i.dimensions;
                material.text = i.material;
                price.text = i.price.ToString();

            }
        }
        DetectObject();

        foreach (GameObject go in spawnedPrefabs.Values)
        {
            if(go.name != name)
            {
                go.SetActive(false);
                UndetectObject();

            }
        }
    }

    private void DetectObject()
    {
        Animator animator = objectInfoPanel.GetComponent<Animator>();
        animator.SetBool("Open", true);
        scanMenu.SetActive(false);


    }

    private void UndetectObject()
    {
        Animator animator = objectInfoPanel.GetComponent<Animator>();
        animator.SetBool("Open", false);
        scanMenu.SetActive(true);
    }

    public void CloseMoreInfo()
    {
        Animator animator = moreInfoPanel.GetComponent<Animator>();
        animator.SetBool("Open", false);
    }

    public void OpenMoreInfo()
    {
        Animator animator = moreInfoPanel.GetComponent<Animator>();
        animator.SetBool("Open", true);
    }
}
