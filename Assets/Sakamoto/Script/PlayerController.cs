using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Playerontroller : MonoBehaviour
{
    [SerializeField] int PlayerMaxHp;
    [SerializeField] int PlayerHp;
    [SerializeField] int PlayerAttack;
    [SerializeField] float MoveSpeed = 5;
    [SerializeField] int PlayerLevel;
    [SerializeField] float PlayerExperience;
    [SerializeField] float KnockBack;


    private Rigidbody2D rb;






    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Application.targetFrameRate = 30;

    }


    void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {

        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime;//横矢印入力を値で返し変数「moveX」に格納 フレームレート調整しスピードとレベルアップで画面停止するためにtime.deltaTime使用

        float moveY = Input.GetAxis("Vertical") * Time.deltaTime;//縦矢印入力を値で返し変数「tateyajirushi」に格納 フレームレート調整しスピードとレベルアップで画面停止するためにtime.deltaTime使用
        rb.velocity = new Vector2(moveX * MoveSpeed, moveY * MoveSpeed);

        // void OnCollisionEnter2D(Collision2D other)
        // {
        //     Rigidbody2D enemyRb = other.gameObject.GetComponent<Rigidbody2D>();
        //     Vector2 enemyDir = enemyRb.velocity.normalized;
        //     rb.AddForce(enemyDir * KnockBack, ForceMode2D.Impulse);
        //     Debug.Log("ダメージ");






        // }
    }
}
