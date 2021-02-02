using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject inventory;
    private bool inventoryOn;
    // Start is called before the first frame update
    void Start()
    {
        inventoryOn = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Chest()
    {
        if (inventoryOn == false)
        {
            inventoryOn = true;
            inventory.SetActive(true);

        }
        else if (inventoryOn == true)
        {
            inventoryOn = false;
            inventory.SetActive(false);
        }
    }
}
