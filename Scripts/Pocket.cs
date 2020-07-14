using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    private Inventory inventory; //инвентарь
    public int i; //переменная, отвечающая за номер слота


    private void Start() //полуясаем инвентарь нашего игрока
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if(transform.childCount <= 0) //childCount - объекты, находящиеся внутри слота
        {
            inventory.isFull[i] = false; //если их нет, то слот пустой
        }
    }

    public void DropItem()
    {
        foreach(Transform child in transform) //для каждого объекта в слоте
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject); //уничтожаем объект из инвентаря
        }
    }
}
