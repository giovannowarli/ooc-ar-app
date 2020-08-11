using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField]
    GameObject scan;

    [SerializeField]
    GameObject visualize;

    [SerializeField]
    GameObject welcome;



    public void GoToScanLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToVisualizeLevel()
    {

        SceneManager.LoadScene(2);
    }

    public void ScanSelect()
    {
        WelcomeInactive();
        scan.SetActive(true);
    }

    public void ScanBack()
    {
        scan.SetActive(false);
        WelcomeActive();
    }

    public void VisualizeSelect()
    {
        WelcomeInactive();
        visualize.SetActive(true);
    }

    public void VisualizeBack()
    {
        visualize.SetActive(false);
        WelcomeActive();
    }

    public void WelcomeActive()
    {
        welcome.SetActive(true);
    }

    public void WelcomeInactive()
    {
        welcome.SetActive(false);
    }

}
