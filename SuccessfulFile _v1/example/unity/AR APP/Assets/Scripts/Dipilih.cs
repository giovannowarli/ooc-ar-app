using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dipilih : MonoBehaviour
{
    [SerializeField]
    bool isSelected;

    public bool Selected
    {
        get
        {
            return isSelected;
        }
        set
        {
            isSelected = value;
        }
    }
}
