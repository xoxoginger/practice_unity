using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player; //позиция игрока

    private void Start() //полуясаем инвентарь нашего игрока
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem() //возвращает объект на сцену
    {
        Vector2 playerPos = new Vector2(player.position.x + 3, player.position.y - 5); //насколько далеко от игрока выкинется айтем
        Instantiate(item, playerPos, Quaternion.identity); //(какой айтем, где, сохранение исходного вращения предмета)
    }
}
