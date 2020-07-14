using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; //скорость игрока
    public float jumpForce; //сила прыжка
    private float moveInput; //для считывания движения вправо/влево

    public Joystick joystick;

    private Rigidbody2D rb; //

    private bool facingRight = true;

    private bool isGrounded; //приземлился ли игрок
    public Transform feetPos; //позиция ног игрока
    public float checkRadius; //радиус, насколько близко игрок к земле
    public LayerMask whatIsGround; //что такое земля? (указать слой, от которого игрок будет отталкиваться)

    private Animator anim; //аниматор игрока

    private void Start() //инициализация всякой х
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); //получить компонент для игрока
    }

    private void FixedUpdate() //производит действие каждый кадр, когда мы находимся в игре
    {
        //moveInput = Input.GetAxis("Horizontal"); //input по горизонтальной оси, когда мы движемся вправо или влево
        moveInput = joystick.Horizontal;
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); //пропишем скорость компонента по rigitbody
        if (facingRight == false && moveInput > 0) //идем вправо
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0) //идем влево
        {
            Flip();
        }
        if(moveInput == 0)
        {
            anim.SetBool("isRunning", false); //если игрок не двигается, то условие в аниматоре == false
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }

    private void Update()
    {
        float verticalMove = joystick.Vertical;

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround); //приземление игрока - какой-то физический круг

        if(isGrounded == true && verticalMove >= .5f) //Input.GetKeyDown(KeyCode.Space)) //если мы приземлились и нажали пробел, то мы прыгаем
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOff");
        }

        if(isGrounded == true) //если находимся на хемле, то не прыгаем
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }
    void Flip() //чтобы игрок, когда идет, смотрел в разные стороны
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

        //чтобы игрок снова поворачивался при анимации
        //костыль

        /*if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }*/
    }
}
