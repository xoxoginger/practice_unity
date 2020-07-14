using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//скрипт отвечает за то, чтобы диалог вылетал только тогда, когда мы находимся рядом с персонажем
public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;

    public void OnTriggerEnter2D(Collider2D other) //работает, когда входим в зону персонажа
    {
        startAnim.SetBool("startopen", true);
    }

    public void OnTriggerExit2D(Collider2D other) //работает, когда выходим из зону персонажа
    {
        startAnim.SetBool("startopen", false);
        dm.EndDialogue();
    }
}
