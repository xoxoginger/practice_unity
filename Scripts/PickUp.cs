using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory; //инвентарь
    public GameObject slotButton; //объект предмета, который будет лежать в слоте
    public int id;

    private void Start() //полуясаем инвентарь нашего игрока
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other) //работает, когда игрок взаимодействует с предметом, который отправится в инвентарь
    {
        //если предмет коснулся объекта с тегом player
        if(other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++) //проверяет слоты инвентаря на заполненность, чтобы в 1 слоте лежал 1 предмет
            {
                if(inventory.isFull[i] == false) //если слот пустой
                {
                    inventory.isFull[i] = true; //то мы его заполняем
                    //создаем объект в текущем слоте
                    Instantiate(slotButton, inventory.slots[i].transform); //(какой именно объект, в каком именно слоте)
                    //объект в рюкзаке, значит на локации обычной он исчезает, поэтому мы его уничтожаем
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

}
