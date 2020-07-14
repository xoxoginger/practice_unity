using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull; //заполнен ли тот или иной слот
    public GameObject[] slots; //слоты
    public GameObject inventory;
    private bool inventoryOn; //включен ли инвентарь

    private void Start()
    {
        inventoryOn = false;
    }

    public void Bagback()
    {
        if(inventoryOn == false)
        {
            inventoryOn = true;
            inventory.SetActive(true); //активируем сам объект
        }
        else if (inventoryOn == true)
        {
            inventoryOn = false;
            inventory.SetActive(false);
        }
    }
}
