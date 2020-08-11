using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject notifButton;

    [SerializeField]
    private GameObject wishListButton;

    [SerializeField]
    private GameObject personalButton;

    [SerializeField]
    private GameObject contactIcon;

    [SerializeField]
    private GameObject aboutIcon;

    public void MenuController()
    {
        Debug.Log("clicked");
        Animator animatorNotif = notifButton.GetComponent<Animator>();
        Animator animatorWishList = wishListButton.GetComponent<Animator>();
        Animator animatorPersonal = personalButton.GetComponent<Animator>();
        Animator animatorContact = contactIcon.GetComponent<Animator>();
        Animator animatorAbout = aboutIcon.GetComponent<Animator>();

        bool getBool = animatorNotif.GetBool("Open");

        if (getBool == false)
        {
            SetActiveObjects(true);
        }
        else
        {
            Invoke("DeactivateObjects", 0.2f);
            
        }

        animatorNotif.SetBool("Open", !getBool);
        animatorWishList.SetBool("Open", !getBool);
        animatorPersonal.SetBool("Open", !getBool);
        animatorContact.SetBool("Open", !getBool);
        animatorAbout.SetBool("Open", !getBool);

        
    }

    public void SetActiveObjects(bool isActive)
    {
        notifButton.SetActive(isActive);
        wishListButton.SetActive(isActive);
        personalButton.SetActive(isActive);
        contactIcon.SetActive(isActive);
        aboutIcon.SetActive(isActive);
    }

    public void DeactivateObjects()
    {
        notifButton.SetActive(false);
        wishListButton.SetActive(false);
        personalButton.SetActive(false);
        contactIcon.SetActive(false);
        aboutIcon.SetActive(false);
    }

    public void ChangeScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        } else if(scene.buildIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void LoadNewScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
