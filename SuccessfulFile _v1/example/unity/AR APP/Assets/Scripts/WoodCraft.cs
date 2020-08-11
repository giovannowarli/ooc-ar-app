using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WoodCraft
{
    public int id;
    public string productName;
    public string material;
    public int price;
    public string dimensions;


    public WoodCraft(int _id, string _productName, string _material, int _price, string _dimensions)
    {
        id = _id;
        productName = _productName;
        material = _material;
        price = _price;
        dimensions = _dimensions;

    }

}
