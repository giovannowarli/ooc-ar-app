using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{


    public Text productName, material, price, dimensions;

    [SerializeField]
    private GameObject objectInfo;

    [SerializeField]
    private GameObject instantiateButton;

    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private GameObject woodcraftPanel;

    [SerializeField]
    private GameObject galleryButton;

    public GameObject GalleryButton
    {
        get
        {
            return galleryButton;
        }
        set
        {
            galleryButton = value;
        }
    }

    [SerializeField]
    private GameObject options;


    public void panelOpener()
    {
        if (menuPanel != null)
        {
            Animator animator = menuPanel.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("Open");
                animator.SetBool("Open", !isOpen);
            }
        }

    }

    public void woodCraftPanel()
    {

        Animator animator = woodcraftPanel.GetComponent<Animator>();

        bool isOpen = animator.GetBool("Open");
        animator.SetBool("Open", !isOpen);

    }



    public void closeMenus()
    {
        menuPanel.GetComponent<Animator>().SetBool("Open", false);
        woodcraftPanel.GetComponent<Animator>().SetBool("Open", false);

    }

    public void GalleryMoveMid()
    {
        Animator animator = galleryButton.GetComponent<Animator>();
        animator.SetBool("Open", true);

    }

    public void GalleryBackToOri()
    {
        Animator animator = galleryButton.GetComponent<Animator>();
        animator.SetBool("Open", false);

    }


    public void ObjectInfoOpen()
    {
        Animator animator = objectInfo.GetComponent<Animator>();
        animator.SetBool("Open", true);
    }

    public void ObjectInfoClose()
    {
        Animator animator = objectInfo.GetComponent<Animator>();
        animator.SetBool("Open", false);
    }

    public void OpenOptions()
    {
        options.SetActive(true);
    }

    public void CloseOptions()
    {
        options.SetActive(false);
    }

    public void BackToHome()
    {
        SceneManager.LoadScene(0);
    }

}
