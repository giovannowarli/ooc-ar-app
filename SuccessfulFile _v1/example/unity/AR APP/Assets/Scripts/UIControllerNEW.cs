using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControllerNEW : MonoBehaviour
{

    [SerializeField]
    private GameObject scanBtn;

    [SerializeField]
    private GameObject visualizeButton;

    [SerializeField]
    private GameObject browseButton;

    [SerializeField]
    private GameObject startButton;

    [SerializeField]
    private GameObject closeButton;



    public void StartButton ()
    {
        scanBtn.SetActive(true);
        visualizeButton.SetActive(true);
        browseButton.SetActive(true);

        Animator animatorScan = scanBtn.GetComponent<Animator>();
        Animator animatorVisualize = visualizeButton.GetComponent<Animator>();
        Animator animatorBrowse = browseButton.GetComponent<Animator>();

        animatorScan.SetBool("Open", true);
        animatorVisualize.SetBool("Open", true);
        animatorBrowse.SetBool("Open", true);
        startButton.SetActive(false);
        closeButton.SetActive(true);
    }


    public void CloseButton()
    {


        Animator animatorScan = scanBtn.GetComponent<Animator>();
        Animator animatorVisualize = visualizeButton.GetComponent<Animator>();
        Animator animatorBrowse = browseButton.GetComponent<Animator>();

        animatorScan.SetBool("Open", false);
        animatorVisualize.SetBool("Open", false);
        animatorBrowse.SetBool("Open", false);

        Invoke("CloseDelay", 0.2f);
        
    }

    void CloseDelay()
    {
        closeButton.SetActive(false);
        scanBtn.SetActive(false);
        visualizeButton.SetActive(false);
        browseButton.SetActive(false);
        startButton.SetActive(true);
    }

    public void GoScanScreen()
    {
        SceneManager.LoadScene(1);
    }

    public void GoVisualizeScreen()
    {
        SceneManager.LoadScene(2);
    }
}
