using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //это нужно для сохранения

public class Dialogue
{
    public string name;
    [TextArea(2, 7)] //минимальное кол-во строк и максимальное, кот будет использоваться в нашем пр-ве, где будем писать диалог
    public string[] sentences;
}
