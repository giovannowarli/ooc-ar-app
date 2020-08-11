using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManagerIT : MonoBehaviour
{

    public void BackToHome()
    {
        SceneManager.LoadScene(0);
    }
}
