using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //нужна, чтобы диалог видел текст, который мы укажем(в ней находится класс Text)

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;

    public Animator boxAnim;
    public Animator startAnim;

    //сздадим очередь предлжений
    private Queue<string> sentences;
    
    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        boxAnim.SetBool("boxopen", true);
        startAnim.SetBool("startopen", false);

        nameText.text = dialogue.name; //укажем имя перса
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); //ставим каждое предложение в очередь
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0) //если предложений в очереди больше нет
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue(); //удаляем из очереди

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        boxAnim.SetBool("boxopen", false);
    }

}
