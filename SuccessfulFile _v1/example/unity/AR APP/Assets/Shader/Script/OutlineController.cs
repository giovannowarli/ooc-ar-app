using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    private MeshRenderer renderer;

    public float maxOutlineWidth;

    public Color outlineColor;


    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();

    }

    public void ShowOutline()
    {
        Debug.Log("Masuk");
        foreach(var mat in renderer.materials)
        {
            mat.SetFloat("_Outline", maxOutlineWidth);
            mat.SetColor("_OutlineColor", outlineColor);
        }
        
    }

    public void HideOutline()
    {
        foreach (var mat in renderer.materials)
        {
            mat.SetFloat("_Outline", 0f);
        }
    }

}
