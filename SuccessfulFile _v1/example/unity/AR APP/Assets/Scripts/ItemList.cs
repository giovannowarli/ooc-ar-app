using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{

    public WoodCraft[] woodCraft = new WoodCraft[4];

    // Start is called before the first frame update
    void Awake()
    {
        woodCraft[0] = new WoodCraft(0, "Mahogany Tray", "Solid Mahogany", 115000, "25 x 30 x 5 cm");
        woodCraft[1] = new WoodCraft(1, "Mikaela Tray", "Solid Mahogany", 115000, "25 x 30 x 5 cm");
        woodCraft[2] = new WoodCraft(2, "Hexagon Plate", "Solid Mahogany", 115000, "25 x 30 x 5 cm");
        woodCraft[3] = new WoodCraft(3, "Cookie Plate", "Solid Mahogany", 115000, "25 x 30 x 5 cm");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
